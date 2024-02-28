using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leitor_de_Séries
{
    public partial class homeScreen : Form
    {
        public static DirectoryInfo filesFolder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + Properties.Settings.Default.appName);
        public static Regex getSeason = new Regex(@"(?<= - )Temporada \d+"), getCaption = new Regex(@"(?<= - )(.*)(?=\.)"), getEpNumber = new Regex(@"(?<=Episódio )\d+"), getSgNumber = new Regex(@"(?<=Música )\d+");

        public homeScreen()
        {
            InitializeComponent();
        }

        private void homeScreen_Load(object sender, EventArgs e)
        {
            if (!filesFolder.Exists)
                filesFolder.Create();
            ReloadTreeView();
            lblItemNValue.Text = "";
            lblSizeValue.Text = "";
        }

        private void ReloadTreeView()
        {
            int itemsCount = 0;
            InfoRemover();
            tvwSeriesPlaylists.Nodes.Clear();
            lvwItems.Items.Clear();
            foreach (DirectoryInfo serie in filesFolder.GetDirectories())
            {
                if (new FileInfo(serie.FullName + "\\type.txt").Exists == false)
                {
                    if (serie.GetFiles().Length != 0)
                    {
                        tvwSeriesPlaylists.Nodes.Add(serie.Name);
                        foreach (FileInfo episode in serie.GetFiles())
                        {
                            if (episode.Extension == ".mp4" || episode.Extension == ".mkv")
                                itemsCount++;
                        }
                    }
                }
                else if (File.ReadAllText(new FileInfo(serie.FullName + "\\type.txt").FullName) == "music")
                {
                    if (serie.GetFiles().Length > 1)
                    {
                        TreeNode treeNode = new TreeNode();
                        treeNode.Tag = "music";
                        treeNode.Text = serie.Name;
                        treeNode.ImageIndex = 1;
                        treeNode.SelectedImageIndex = 1;
                        tvwSeriesPlaylists.Nodes.Add(treeNode);
                    }
                }
            }
            lblNItems.Text = "Existem " + itemsCount + " episódios disponíveis!";
            if (itemsCount <= 10)
                lblNItems.ForeColor = Color.Orange;
            else
                lblNItems.ForeColor = Color.Black;
        }

        private void ReloadListView()
        {
            InfoRemover();
            lvwItems.Items.Clear();
            lvwItems.Groups.Clear();

            if (new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + Properties.Settings.Default.appName + "\\" + tvwSeriesPlaylists.SelectedNode.Text).GetFiles().Length == 0)
            {
                new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + Properties.Settings.Default.appName + "\\" + tvwSeriesPlaylists.SelectedNode.Text).Delete();
                ReloadTreeView();
                return;
            }

            foreach (FileInfo item in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + Properties.Settings.Default.appName + "\\" + tvwSeriesPlaylists.SelectedNode.Text).GetFiles())
            {
                ListViewGroup itemGroup = null;

                if ((item.Extension == ".mp4" || item.Extension == ".mkv" || item.Extension == ".mp3") && item.Name.Split(new[] { " - " }, StringSplitOptions.None).Length == 2)
                {
                    foreach (ListViewGroup group in lvwItems.Groups)
                    {
                        if (group.Header == getSeason.Match(item.Name).Value || group.Header == getCaption.Match(item.Name).Value)
                            itemGroup = group;
                    }

                    if (itemGroup == null)
                    {
                        itemGroup = new ListViewGroup();
                        itemGroup.Header = getSeason.Match(item.Name).Value != "" ? getSeason.Match(item.Name).Value : item.Name.Split(new[] { " - " }, StringSplitOptions.None)[1].Split('.')[0];
                        lvwItems.Groups.Add(itemGroup);
                    }

                    if (tvwSeriesPlaylists.SelectedNode.Tag == null)
                    {
                        ListViewItem episodeItem = new ListViewItem
                        {
                            Text = item.Name.Split(new[] { " - " }, StringSplitOptions.None)[0],
                            Tag = item.FullName,
                            ImageKey = item.Extension == ".mp3" ? "song.png" : "episode.png",
                            Group = itemGroup
                        };

                        lvwItems.Items.Add(episodeItem);
                    }
                    else if (tvwSeriesPlaylists.SelectedNode.Tag.ToString() == "music")
                    {
                        ListViewItem songItem = new ListViewItem
                        {
                            Text = item.Name.Split(new[] { " - " }, StringSplitOptions.None)[0],
                            Tag = item.FullName,
                            ImageKey = "song.png",
                            Group = itemGroup
                        };

                        lvwItems.Items.Add(songItem);
                    }
                }
            }

            foreach (ListViewGroup listViewGroup in lvwItems.Groups)
            {
                ListViewItem[] items = new ListViewItem[listViewGroup.Items.Count];
                listViewGroup.Items.CopyTo(items, 0);
                Array.Sort(items, new sortListViewItems());

                lvwItems.BeginUpdate();
                listViewGroup.Items.Clear();
                listViewGroup.Items.AddRange(items);
                lvwItems.EndUpdate();
            }

            ListViewGroup[] groups = new ListViewGroup[lvwItems.Groups.Count];
            lvwItems.Groups.CopyTo(groups, 0);
            Array.Sort(groups, new sortListViewGroups());
            
            lvwItems.BeginUpdate();
            lvwItems.Groups.Clear();
            lvwItems.Groups.AddRange(groups);
            lvwItems.EndUpdate();
        }

        private void cmsListView_Opening(object sender, CancelEventArgs e)
        {
            ToolStripMenuItem tsmiPlay = new ToolStripMenuItem(), tsmiRemove = new ToolStripMenuItem(), tsmiShuffle = new ToolStripMenuItem();
            tsmiPlay.Name = "tsmiPlay";
            tsmiPlay.Text = "Reproduzir";
            tsmiPlay.Image = Properties.Resources.play;
            tsmiPlay.Click += new EventHandler(PlayItem);
            tsmiRemove.Name = "tsmiRemove";
            tsmiRemove.Text = "Apagar";
            tsmiRemove.Image = Properties.Resources.exit;
            tsmiRemove.Click += new EventHandler(DeleteItem);
            tsmiShuffle.Name = "tsmiShuffle";
            tsmiShuffle.Text = "Aleatório";
            tsmiShuffle.Image = Properties.Resources.shuffle;
            tsmiShuffle.Click += new EventHandler(RandomItem);

            if (lvwItems.SelectedItems.Count != 0 || tvwSeriesPlaylists.SelectedNode.Tag != null)
                cmsListView.Items.AddRange(new ToolStripItem[] { new ToolStripSeparator() });

            if (lvwItems.SelectedItems.Count != 0)
            {
                cmsListView.Items.Add(tsmiPlay);
                cmsListView.Items.Add(tsmiRemove);
            }

            if (tvwSeriesPlaylists.SelectedNode.Tag != null)
                cmsListView.Items.Add(tsmiShuffle);
        }

        private void cmsListView_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (cmsListView.Items.Count > 1)
            {
                for (int i = cmsListView.Items.Count - 1; i >= 1; i--)
                    cmsListView.Items.Remove(cmsListView.Items[i]);
            }
        }

        private void tvwSeriesPlaylists_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ReloadListView();
        }

        public void tsmiReloadTV_Click(object sender, EventArgs e)
        {
            ReloadTreeView();
        }

        public void tsmiReloadLV_Click(object sender, EventArgs e)
        {
            ReloadListView();
        }

        private void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count != 0)
            {
                int arrayN = 0;
                double fileSize = new FileInfo(lvwItems.SelectedItems[0].Tag.ToString()).Length;
                string[] sizeNames = { "Bytes", "KB", "MB", "GB", "TB" };
                lblInfoText.Text = lvwItems.SelectedItems[lvwItems.SelectedItems.Count - 1].Text;
                if (lvwItems.SelectedItems[lvwItems.SelectedItems.Count - 1].ImageKey == "episode.png")
                    pbStatus.Image = Properties.Resources.episode;
                else
                    pbStatus.Image = Properties.Resources.song;
                lblItemNValue.Text = new FileInfo(lvwItems.SelectedItems[lvwItems.SelectedItems.Count - 1].Tag.ToString()).Name.Split(new[] { " - " }, StringSplitOptions.None)[1].Split('.')[0];
                while (fileSize >= 1024 && arrayN < sizeNames.Length - 1)
                {
                    arrayN++;
                    fileSize /= 1024;
                }
                lblSizeValue.Text = String.Format("{0:0.##} {1}", fileSize, sizeNames[arrayN]);
                btnReproduzir.Enabled = true;
                btnApagar.Enabled = true;
            }
            else
                InfoRemover();
        }

        private void InfoRemover()
        {
            pbStatus.Image = Properties.Resources.info;
            lblInfoText.Text = "Selecione um item!";
            lblItemNValue.Text = "";
            lblSizeValue.Text = "";
            btnReproduzir.Enabled = false;
            btnApagar.Enabled = false;
        }

        private void PlayItem(object sender, EventArgs e)
        {
            List<string> pLocations = new List<string>();

            for (int i = 0; i < lvwItems.SelectedItems.Count; i++)
                pLocations.Add(lvwItems.SelectedItems[i].Tag.ToString());

            playerScreen itemPlayer = new playerScreen
            {
                playLocations = pLocations,
            };
            itemPlayer.Show();
        }

        private void DeleteItem(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tens a certeza que queres apagar este episódio? Uma vez apagado será impossível recupera-lo!", Properties.Settings.Default.appName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                FileInfo fileToDelete = new FileInfo(lvwItems.SelectedItems[0].Tag.ToString());
                if (fileToDelete.Exists)
                {
                    fileToDelete.Delete();
                    ReloadListView();
                    InfoRemover();
                }
            }
        }

        private void RandomItem(object sender, EventArgs e)
        {
            List<ListViewItem> orderedItems = new List<ListViewItem>();
            List<string> shuffleItems = new List<string>();
            Random random = new Random();

            foreach (ListViewItem listViewItem in lvwItems.Items)
                orderedItems.Add(listViewItem);
            for (int i = 0; i < lvwItems.Items.Count; i++)
            {
                int randomIndex = random.Next(0, orderedItems.Count);
                shuffleItems.Add(orderedItems[randomIndex].Tag.ToString());
                orderedItems.RemoveAt(randomIndex);
            }

            playerScreen itemPlayer = new playerScreen
            {
                playLocations = shuffleItems,
            };
            itemPlayer.Show();
        }
    }

    public class sortListViewGroups : IComparer
    {
        public Regex getSeasonNumber = new Regex(@"(?<=Temporada )\d+");

        public int Compare(object x, object y)
        {
            int num1, num2, returnVal = -1;

            if (getSeasonNumber.Match(((ListViewGroup)x).Header).Value != "")
                num1 = Convert.ToInt32(getSeasonNumber.Match(((ListViewGroup)x).Header).Value);
            else
                num1 = 99;

            if (getSeasonNumber.Match(((ListViewGroup)y).Header).Value != "")
                num2 = Convert.ToInt32(getSeasonNumber.Match(((ListViewGroup)y).Header).Value);
            else
                num2 = 99;

            returnVal = num1.CompareTo(num2);
            return returnVal;
        }
    }

    public class sortListViewItems : IComparer
    {
        public int Compare(object x, object y)
        {
            int num1, num2, returnVal = -1;

            if (homeScreen.getEpNumber.Match(((ListViewItem)x).Tag.ToString()).Value != "")
                num1 = Convert.ToInt32(homeScreen.getEpNumber.Match(((ListViewItem)x).Tag.ToString()).Value);
            else if (homeScreen.getSgNumber.Match(((ListViewItem)x).Tag.ToString()).Value != "")
                num1 = Convert.ToInt32(homeScreen.getSgNumber.Match(((ListViewItem)x).Tag.ToString()).Value);
            else
                num1 = 99;

            if (homeScreen.getEpNumber.Match(((ListViewItem)y).Tag.ToString()).Value != "")
                num2 = Convert.ToInt32(homeScreen.getEpNumber.Match(((ListViewItem)y).Tag.ToString()).Value);
            else if (homeScreen.getSgNumber.Match(((ListViewItem)y).Tag.ToString()).Value != "")
                num2 = Convert.ToInt32(homeScreen.getSgNumber.Match(((ListViewItem)y).Tag.ToString()).Value);
            else
                num2 = 99;

            returnVal = num1.CompareTo(num2);
            return returnVal;
        }
    }
}