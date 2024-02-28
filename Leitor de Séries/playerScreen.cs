using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace Leitor_de_Séries
{
    public partial class playerScreen : Form
    {
        private LibVLC libVLC;

        public List<string> playLocations = new List<string>();
        private int playIndex;
        private bool finished;

        public playerScreen()
        {
            InitializeComponent();

            Core.Initialize();
            libVLC = new LibVLC();
            playIndex = 0;

            GraphicsPath graphicsPathL = new GraphicsPath();
            GraphicsPath graphicsPathS = new GraphicsPath();
            GraphicsPath graphicsPathM = new GraphicsPath();
            graphicsPathL.AddEllipse(4, 4, btnPlayPause.Width - 9, btnPlayPause.Height - 9);
            graphicsPathS.AddEllipse(4, 4, btnSeek.Width - 9, btnSeek.Height - 9);
            graphicsPathM.AddEllipse(4, 4, btnExit.Width - 9, btnExit.Height - 9);
            btnPlayPause.Region = new Region(graphicsPathL);
            btnSeek.Region = new Region(graphicsPathS);
            btnExit.Region = new Region(graphicsPathM);
        }

        private void playerScreen_Shown(object sender, EventArgs e)
        {
            vvPlayer.MediaPlayer = new MediaPlayer(libVLC);
            vvPlayer.MediaPlayer.EnableMouseInput = false;
            vvPlayer.MediaPlayer.EndReached += new EventHandler<EventArgs>(SetFinish);

            WhatsNext();
        }

        private void WhatsNext()
        {
            if (playIndex == playLocations.Count)
                btnExit_Click(null, null);
            else
            {
                if ((playLocations[playIndex].EndsWith(".mp3") ? "music" : "episode") == "music")
                {
                    tlpOverlay.Visible = true;
                    btnPlayPause.Visible = true;
                    btnSeek.Visible = true;
                    btnExit.Visible = true;
                    btnPlayPause.BringToFront();
                    btnSeek.BringToFront();
                    btnExit.BringToFront();
                }
                else
                {
                    tlpOverlay.Visible = false;
                    btnPlayPause.Visible = false;
                    btnSeek.Visible = false;
                    btnExit.Visible = false;
                }
                vvPlayer.MediaPlayer.Play(new Media(libVLC, new Uri(playLocations[playIndex])));
                while (finished != true)
                    Wait(500);
                finished = false;
                WhatsNext();
            }
        }

        private void SetFinish(object sender, EventArgs e)
        {
            finished = true;
            playIndex++;
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (vvPlayer.MediaPlayer.IsPlaying)
            {
                vvPlayer.MediaPlayer.Pause();
                btnPlayPause.BackgroundImage = Properties.Resources.play;
            }
            else
            {
                vvPlayer.MediaPlayer.Play();
                btnPlayPause.BackgroundImage = Properties.Resources.pause;
            }
            vvPlayer.Focus();
        }

        private void btnSeek_Click(object sender, EventArgs e)
        {
            vvPlayer.MediaPlayer.Time -= 5000;
            vvPlayer.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void vvPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                btnPlayPause_Click(null, null);
            else if (e.KeyCode == Keys.Left)
                btnSeek_Click(null, null);
            else if (e.KeyCode == Keys.Right)
                vvPlayer.MediaPlayer.Time += 10000;
            else if (e.KeyCode == Keys.Escape)
                btnExit_Click(null, null);
            else if (e.KeyCode == Keys.C)
            {
                if (btnPlayPause.Visible || btnSeek.Visible || btnExit.Visible)
                {
                    btnPlayPause.Visible = false;
                    btnSeek.Visible = false;
                    btnExit.Visible = false;
                }
                else
                {
                    btnPlayPause.Visible = true;
                    btnSeek.Visible = true;
                    btnExit.Visible = true;
                }
            }
            vvPlayer.Focus();
        }

        private void vvPlayer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                e.IsInputKey = true;
        }

        private void playerScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            vvPlayer.MediaPlayer.Stop();
            vvPlayer.MediaPlayer.Dispose();
            libVLC.Dispose();
        }

        public void Wait(int milliseconds)
        {
            var timer = new Timer();
            if (milliseconds == 0 || milliseconds < 0)
                return;

            timer.Interval = milliseconds;
            timer.Enabled = true;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
            };

            while (timer.Enabled)
                Application.DoEvents();
        }
    }
}