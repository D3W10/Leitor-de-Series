
namespace Leitor_de_Séries
{
    partial class playerScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(playerScreen));
            this.vvPlayer = new LibVLCSharp.WinForms.VideoView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSeek = new System.Windows.Forms.Button();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.tlpOverlay = new System.Windows.Forms.TableLayoutPanel();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.vvPlayer)).BeginInit();
            this.tlpOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // vvPlayer
            // 
            this.vvPlayer.BackColor = System.Drawing.Color.Black;
            this.vvPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vvPlayer.Location = new System.Drawing.Point(0, 0);
            this.vvPlayer.MediaPlayer = null;
            this.vvPlayer.Name = "vvPlayer";
            this.vvPlayer.Size = new System.Drawing.Size(800, 450);
            this.vvPlayer.TabIndex = 9;
            this.vvPlayer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vvPlayer_KeyDown);
            this.vvPlayer.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.vvPlayer_PreviewKeyDown);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.BackgroundImage = global::Leitor_de_Séries.Properties.Resources.exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(743, 393);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 8;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSeek
            // 
            this.btnSeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSeek.BackColor = System.Drawing.Color.Black;
            this.btnSeek.BackgroundImage = global::Leitor_de_Séries.Properties.Resources.seek;
            this.btnSeek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeek.FlatAppearance.BorderSize = 0;
            this.btnSeek.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSeek.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeek.Location = new System.Drawing.Point(74, 396);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(35, 35);
            this.btnSeek.TabIndex = 7;
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Visible = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlayPause.BackColor = System.Drawing.Color.Black;
            this.btnPlayPause.BackgroundImage = global::Leitor_de_Séries.Properties.Resources.pause;
            this.btnPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPlayPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayPause.FlatAppearance.BorderSize = 0;
            this.btnPlayPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnPlayPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayPause.Location = new System.Drawing.Point(12, 388);
            this.btnPlayPause.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(50, 50);
            this.btnPlayPause.TabIndex = 5;
            this.btnPlayPause.UseVisualStyleBackColor = false;
            this.btnPlayPause.Visible = false;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // tlpOverlay
            // 
            this.tlpOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpOverlay.ColumnCount = 1;
            this.tlpOverlay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOverlay.Controls.Add(this.pbIcon, 0, 0);
            this.tlpOverlay.Location = new System.Drawing.Point(0, 0);
            this.tlpOverlay.Name = "tlpOverlay";
            this.tlpOverlay.RowCount = 1;
            this.tlpOverlay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpOverlay.Size = new System.Drawing.Size(800, 450);
            this.tlpOverlay.TabIndex = 10;
            this.tlpOverlay.Visible = false;
            // 
            // pbIcon
            // 
            this.pbIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbIcon.Image = global::Leitor_de_Séries.Properties.Resources.song;
            this.pbIcon.Location = new System.Drawing.Point(335, 160);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(130, 130);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // playerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSeek);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.tlpOverlay);
            this.Controls.Add(this.vvPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "playerScreen";
            this.Text = "Player";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.playerScreen_FormClosed);
            this.Shown += new System.EventHandler(this.playerScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.vvPlayer)).EndInit();
            this.tlpOverlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnSeek;
        private System.Windows.Forms.Button btnExit;
        private LibVLCSharp.WinForms.VideoView vvPlayer;
        private System.Windows.Forms.TableLayoutPanel tlpOverlay;
        private System.Windows.Forms.PictureBox pbIcon;
    }
}