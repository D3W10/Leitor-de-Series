
namespace Leitor_de_Séries
{
    partial class homeScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(homeScreen));
            this.lvwItems = new System.Windows.Forms.ListView();
            this.cmsListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiReloadLV = new System.Windows.Forms.ToolStripMenuItem();
            this.ilListIcon = new System.Windows.Forms.ImageList(this.components);
            this.cmsTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiReloadTV = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReproduzir = new System.Windows.Forms.Button();
            this.btnApagar = new System.Windows.Forms.Button();
            this.tvwSeriesPlaylists = new System.Windows.Forms.TreeView();
            this.ilTreeIcon = new System.Windows.Forms.ImageList(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.tlpInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblInfoText = new System.Windows.Forms.Label();
            this.tlpSubInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblItemN = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblSizeValue = new System.Windows.Forms.Label();
            this.lblItemNValue = new System.Windows.Forms.Label();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.tlpNSeries = new System.Windows.Forms.TableLayoutPanel();
            this.lblNItems = new System.Windows.Forms.Label();
            this.cmsListView.SuspendLayout();
            this.cmsTreeView.SuspendLayout();
            this.tlpInfo.SuspendLayout();
            this.tlpSubInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.tlpNSeries.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwItems
            // 
            this.lvwItems.ContextMenuStrip = this.cmsListView;
            this.lvwItems.HideSelection = false;
            this.lvwItems.LargeImageList = this.ilListIcon;
            this.lvwItems.Location = new System.Drawing.Point(230, 39);
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(558, 302);
            this.lvwItems.TabIndex = 0;
            this.lvwItems.UseCompatibleStateImageBehavior = false;
            this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwItems_SelectedIndexChanged);
            // 
            // cmsListView
            // 
            this.cmsListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReloadLV});
            this.cmsListView.Name = "cmsListView";
            this.cmsListView.Size = new System.Drawing.Size(131, 26);
            this.cmsListView.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.cmsListView_Closed);
            this.cmsListView.Opening += new System.ComponentModel.CancelEventHandler(this.cmsListView_Opening);
            // 
            // tsmiReloadLV
            // 
            this.tsmiReloadLV.Image = global::Leitor_de_Séries.Properties.Resources.reload;
            this.tsmiReloadLV.Name = "tsmiReloadLV";
            this.tsmiReloadLV.Size = new System.Drawing.Size(130, 22);
            this.tsmiReloadLV.Text = "Recarregar";
            this.tsmiReloadLV.Click += new System.EventHandler(this.tsmiReloadLV_Click);
            // 
            // ilListIcon
            // 
            this.ilListIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilListIcon.ImageStream")));
            this.ilListIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.ilListIcon.Images.SetKeyName(0, "episode.png");
            this.ilListIcon.Images.SetKeyName(1, "song.png");
            // 
            // cmsTreeView
            // 
            this.cmsTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReloadTV});
            this.cmsTreeView.Name = "cmsTreeView";
            this.cmsTreeView.Size = new System.Drawing.Size(131, 26);
            // 
            // tsmiReloadTV
            // 
            this.tsmiReloadTV.Image = global::Leitor_de_Séries.Properties.Resources.reload;
            this.tsmiReloadTV.Name = "tsmiReloadTV";
            this.tsmiReloadTV.Size = new System.Drawing.Size(130, 22);
            this.tsmiReloadTV.Text = "Recarregar";
            this.tsmiReloadTV.Click += new System.EventHandler(this.tsmiReloadTV_Click);
            // 
            // btnReproduzir
            // 
            this.btnReproduzir.Enabled = false;
            this.btnReproduzir.Location = new System.Drawing.Point(688, 365);
            this.btnReproduzir.Name = "btnReproduzir";
            this.btnReproduzir.Size = new System.Drawing.Size(83, 23);
            this.btnReproduzir.TabIndex = 1;
            this.btnReproduzir.Text = "Reproduzir";
            this.btnReproduzir.UseVisualStyleBackColor = true;
            this.btnReproduzir.Click += new System.EventHandler(this.PlayItem);
            // 
            // btnApagar
            // 
            this.btnApagar.Enabled = false;
            this.btnApagar.Location = new System.Drawing.Point(688, 399);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(83, 23);
            this.btnApagar.TabIndex = 2;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.DeleteItem);
            // 
            // tvwSeriesPlaylists
            // 
            this.tvwSeriesPlaylists.ContextMenuStrip = this.cmsTreeView;
            this.tvwSeriesPlaylists.ImageIndex = 0;
            this.tvwSeriesPlaylists.ImageList = this.ilTreeIcon;
            this.tvwSeriesPlaylists.Location = new System.Drawing.Point(12, 54);
            this.tvwSeriesPlaylists.Name = "tvwSeriesPlaylists";
            this.tvwSeriesPlaylists.SelectedImageIndex = 0;
            this.tvwSeriesPlaylists.ShowLines = false;
            this.tvwSeriesPlaylists.ShowPlusMinus = false;
            this.tvwSeriesPlaylists.ShowRootLines = false;
            this.tvwSeriesPlaylists.Size = new System.Drawing.Size(197, 384);
            this.tvwSeriesPlaylists.TabIndex = 3;
            this.tvwSeriesPlaylists.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwSeriesPlaylists_AfterSelect);
            // 
            // ilTreeIcon
            // 
            this.ilTreeIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeIcon.ImageStream")));
            this.ilTreeIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTreeIcon.Images.SetKeyName(0, "serie.png");
            this.ilTreeIcon.Images.SetKeyName(1, "playlist.png");
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblName.Location = new System.Drawing.Point(12, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(159, 30);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Leitor de Séries";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpInfo
            // 
            this.tlpInfo.ColumnCount = 1;
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.34014F));
            this.tlpInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.65986F));
            this.tlpInfo.Controls.Add(this.lblInfoText, 0, 0);
            this.tlpInfo.Controls.Add(this.tlpSubInfo, 0, 1);
            this.tlpInfo.Location = new System.Drawing.Point(317, 356);
            this.tlpInfo.Name = "tlpInfo";
            this.tlpInfo.RowCount = 2;
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpInfo.Size = new System.Drawing.Size(352, 70);
            this.tlpInfo.TabIndex = 7;
            // 
            // lblInfoText
            // 
            this.lblInfoText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInfoText.AutoSize = true;
            this.lblInfoText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoText.Location = new System.Drawing.Point(3, 7);
            this.lblInfoText.Name = "lblInfoText";
            this.lblInfoText.Size = new System.Drawing.Size(157, 21);
            this.lblInfoText.TabIndex = 0;
            this.lblInfoText.Text = "Selecione um item!";
            // 
            // tlpSubInfo
            // 
            this.tlpSubInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpSubInfo.ColumnCount = 4;
            this.tlpSubInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.375F));
            this.tlpSubInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.625F));
            this.tlpSubInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlpSubInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tlpSubInfo.Controls.Add(this.lblItemN, 0, 0);
            this.tlpSubInfo.Controls.Add(this.lblSize, 2, 0);
            this.tlpSubInfo.Controls.Add(this.lblSizeValue, 3, 0);
            this.tlpSubInfo.Controls.Add(this.lblItemNValue, 1, 0);
            this.tlpSubInfo.Location = new System.Drawing.Point(0, 35);
            this.tlpSubInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSubInfo.Name = "tlpSubInfo";
            this.tlpSubInfo.RowCount = 1;
            this.tlpSubInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSubInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSubInfo.Size = new System.Drawing.Size(352, 35);
            this.tlpSubInfo.TabIndex = 1;
            // 
            // lblItemN
            // 
            this.lblItemN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemN.AutoSize = true;
            this.lblItemN.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemN.Location = new System.Drawing.Point(3, 11);
            this.lblItemN.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblItemN.Name = "lblItemN";
            this.lblItemN.Size = new System.Drawing.Size(72, 13);
            this.lblItemN.TabIndex = 0;
            this.lblItemN.Text = "Episódio Nº:";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSize.Location = new System.Drawing.Point(224, 11);
            this.lblSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(58, 13);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Tamanho:";
            // 
            // lblSizeValue
            // 
            this.lblSizeValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSizeValue.AutoSize = true;
            this.lblSizeValue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSizeValue.Location = new System.Drawing.Point(283, 11);
            this.lblSizeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblSizeValue.Name = "lblSizeValue";
            this.lblSizeValue.Size = new System.Drawing.Size(27, 13);
            this.lblSizeValue.TabIndex = 3;
            this.lblSizeValue.Text = "null";
            // 
            // lblItemNValue
            // 
            this.lblItemNValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblItemNValue.AutoSize = true;
            this.lblItemNValue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemNValue.Location = new System.Drawing.Point(77, 11);
            this.lblItemNValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblItemNValue.Name = "lblItemNValue";
            this.lblItemNValue.Size = new System.Drawing.Size(27, 13);
            this.lblItemNValue.TabIndex = 1;
            this.lblItemNValue.Text = "null";
            // 
            // pbStatus
            // 
            this.pbStatus.Image = global::Leitor_de_Séries.Properties.Resources.info;
            this.pbStatus.Location = new System.Drawing.Point(230, 356);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(70, 70);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStatus.TabIndex = 5;
            this.pbStatus.TabStop = false;
            // 
            // tlpNSeries
            // 
            this.tlpNSeries.ColumnCount = 1;
            this.tlpNSeries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNSeries.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNSeries.Controls.Add(this.lblNItems, 0, 0);
            this.tlpNSeries.Location = new System.Drawing.Point(230, 0);
            this.tlpNSeries.Margin = new System.Windows.Forms.Padding(0);
            this.tlpNSeries.Name = "tlpNSeries";
            this.tlpNSeries.RowCount = 1;
            this.tlpNSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNSeries.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpNSeries.Size = new System.Drawing.Size(558, 39);
            this.tlpNSeries.TabIndex = 8;
            // 
            // lblNItems
            // 
            this.lblNItems.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNItems.AutoSize = true;
            this.lblNItems.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNItems.Location = new System.Drawing.Point(316, 9);
            this.lblNItems.Margin = new System.Windows.Forms.Padding(0);
            this.lblNItems.Name = "lblNItems";
            this.lblNItems.Size = new System.Drawing.Size(242, 21);
            this.lblNItems.TabIndex = 0;
            this.lblNItems.Text = "Existem XX episódios disponíveis!";
            // 
            // homeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpNSeries);
            this.Controls.Add(this.tlpInfo);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tvwSeriesPlaylists);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.btnReproduzir);
            this.Controls.Add(this.lvwItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "homeScreen";
            this.Text = "Leitor de Séries";
            this.Load += new System.EventHandler(this.homeScreen_Load);
            this.cmsListView.ResumeLayout(false);
            this.cmsTreeView.ResumeLayout(false);
            this.tlpInfo.ResumeLayout(false);
            this.tlpInfo.PerformLayout();
            this.tlpSubInfo.ResumeLayout(false);
            this.tlpSubInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.tlpNSeries.ResumeLayout(false);
            this.tlpNSeries.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.Button btnReproduzir;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.ContextMenuStrip cmsTreeView;
        private System.Windows.Forms.ToolStripMenuItem tsmiReloadTV;
        private System.Windows.Forms.ContextMenuStrip cmsListView;
        private System.Windows.Forms.ToolStripMenuItem tsmiReloadLV;
        private System.Windows.Forms.TreeView tvwSeriesPlaylists;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.ImageList ilTreeIcon;
        private System.Windows.Forms.ImageList ilListIcon;
        private System.Windows.Forms.TableLayoutPanel tlpInfo;
        private System.Windows.Forms.Label lblInfoText;
        private System.Windows.Forms.TableLayoutPanel tlpSubInfo;
        private System.Windows.Forms.Label lblItemN;
        private System.Windows.Forms.Label lblItemNValue;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblSizeValue;
        private System.Windows.Forms.TableLayoutPanel tlpNSeries;
        private System.Windows.Forms.Label lblNItems;
    }
}

