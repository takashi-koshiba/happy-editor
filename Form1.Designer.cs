
namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上に追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下に追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.やり直すToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputSubtitleButton = new System.Windows.Forms.Button();
            this.SubtitletextBox = new System.Windows.Forms.TextBox();
            this.videoSpeedLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字幕を開くToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.設定ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.字幕の遅延ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.モードToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開始終了終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ノーマルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.言語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.アラビア語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.英語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ドイツ語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.スペイン語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.フランス語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日本語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ロシア語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中国語ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.AxVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxVLCPlugin21)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView1.ContextMenuStrip = this.contextMenuStrip;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_AfterLabelEdit);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            this.listView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView1_KeyPress);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // columnHeader7
            // 
            resources.ApplyResources(this.columnHeader7, "columnHeader7");
            // 
            // columnHeader8
            // 
            resources.ApplyResources(this.columnHeader8, "columnHeader8");
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加ToolStripMenuItem,
            this.編集ToolStripMenuItem,
            this.削除ToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.やり直すToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // 追加ToolStripMenuItem
            // 
            this.追加ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上に追加ToolStripMenuItem,
            this.下に追加ToolStripMenuItem});
            this.追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            resources.ApplyResources(this.追加ToolStripMenuItem, "追加ToolStripMenuItem");
            // 
            // 上に追加ToolStripMenuItem
            // 
            this.上に追加ToolStripMenuItem.Name = "上に追加ToolStripMenuItem";
            resources.ApplyResources(this.上に追加ToolStripMenuItem, "上に追加ToolStripMenuItem");
            this.上に追加ToolStripMenuItem.Click += new System.EventHandler(this.上に追加ToolStripMenuItem_Click);
            // 
            // 下に追加ToolStripMenuItem
            // 
            this.下に追加ToolStripMenuItem.Name = "下に追加ToolStripMenuItem";
            resources.ApplyResources(this.下に追加ToolStripMenuItem, "下に追加ToolStripMenuItem");
            this.下に追加ToolStripMenuItem.Click += new System.EventHandler(this.下に追加ToolStripMenuItem_Click);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            resources.ApplyResources(this.編集ToolStripMenuItem, "編集ToolStripMenuItem");
            this.編集ToolStripMenuItem.Click += new System.EventHandler(this.編集ToolStripMenuItem_Click);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            resources.ApplyResources(this.削除ToolStripMenuItem, "削除ToolStripMenuItem");
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            resources.ApplyResources(this.redoToolStripMenuItem, "redoToolStripMenuItem");
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.元に戻すToolStripMenuItem_Click);
            // 
            // やり直すToolStripMenuItem
            // 
            this.やり直すToolStripMenuItem.Name = "やり直すToolStripMenuItem";
            resources.ApplyResources(this.やり直すToolStripMenuItem, "やり直すToolStripMenuItem");
            this.やり直すToolStripMenuItem.Click += new System.EventHandler(this.やり直すToolStripMenuItem_Click);
            // 
            // InputSubtitleButton
            // 
            resources.ApplyResources(this.InputSubtitleButton, "InputSubtitleButton");
            this.InputSubtitleButton.Name = "InputSubtitleButton";
            this.InputSubtitleButton.UseVisualStyleBackColor = true;
            this.InputSubtitleButton.Click += new System.EventHandler(this.InputSubtitleButton_Click);
            this.InputSubtitleButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputSubtitleButton_KeyDown);
            // 
            // SubtitletextBox
            // 
            resources.ApplyResources(this.SubtitletextBox, "SubtitletextBox");
            this.SubtitletextBox.Name = "SubtitletextBox";
            // 
            // videoSpeedLabel
            // 
            resources.ApplyResources(this.videoSpeedLabel, "videoSpeedLabel");
            this.videoSpeedLabel.Name = "videoSpeedLabel";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.設定ToolStripMenuItem,
            this.モードToolStripMenuItem,
            this.toolStripMenuItem1,
            this.言語ToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くToolStripMenuItem,
            this.字幕を開くToolStripMenuItem,
            this.保存ToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            resources.ApplyResources(this.ファイルToolStripMenuItem, "ファイルToolStripMenuItem");
            // 
            // 開くToolStripMenuItem
            // 
            this.開くToolStripMenuItem.Name = "開くToolStripMenuItem";
            resources.ApplyResources(this.開くToolStripMenuItem, "開くToolStripMenuItem");
            this.開くToolStripMenuItem.Click += new System.EventHandler(this.開くToolStripMenuItem_Click);
            // 
            // 字幕を開くToolStripMenuItem
            // 
            this.字幕を開くToolStripMenuItem.Name = "字幕を開くToolStripMenuItem";
            resources.ApplyResources(this.字幕を開くToolStripMenuItem, "字幕を開くToolStripMenuItem");
            this.字幕を開くToolStripMenuItem.Click += new System.EventHandler(this.字幕を開くToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            resources.ApplyResources(this.保存ToolStripMenuItem, "保存ToolStripMenuItem");
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem1,
            this.字幕の遅延ToolStripMenuItem});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            resources.ApplyResources(this.設定ToolStripMenuItem, "設定ToolStripMenuItem");
            // 
            // 設定ToolStripMenuItem1
            // 
            this.設定ToolStripMenuItem1.Name = "設定ToolStripMenuItem1";
            resources.ApplyResources(this.設定ToolStripMenuItem1, "設定ToolStripMenuItem1");
            this.設定ToolStripMenuItem1.Click += new System.EventHandler(this.設定ToolStripMenuItem1_Click);
            // 
            // 字幕の遅延ToolStripMenuItem
            // 
            this.字幕の遅延ToolStripMenuItem.Name = "字幕の遅延ToolStripMenuItem";
            resources.ApplyResources(this.字幕の遅延ToolStripMenuItem, "字幕の遅延ToolStripMenuItem");
            this.字幕の遅延ToolStripMenuItem.Click += new System.EventHandler(this.字幕の遅延ToolStripMenuItem_Click);
            // 
            // モードToolStripMenuItem
            // 
            this.モードToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開始終了終了ToolStripMenuItem,
            this.ノーマルToolStripMenuItem});
            this.モードToolStripMenuItem.Name = "モードToolStripMenuItem";
            resources.ApplyResources(this.モードToolStripMenuItem, "モードToolStripMenuItem");
            // 
            // 開始終了終了ToolStripMenuItem
            // 
            this.開始終了終了ToolStripMenuItem.Checked = true;
            this.開始終了終了ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.開始終了終了ToolStripMenuItem.Name = "開始終了終了ToolStripMenuItem";
            resources.ApplyResources(this.開始終了終了ToolStripMenuItem, "開始終了終了ToolStripMenuItem");
            this.開始終了終了ToolStripMenuItem.Click += new System.EventHandler(this.開始終了終了ToolStripMenuItem_Click);
            // 
            // ノーマルToolStripMenuItem
            // 
            this.ノーマルToolStripMenuItem.Name = "ノーマルToolStripMenuItem";
            resources.ApplyResources(this.ノーマルToolStripMenuItem, "ノーマルToolStripMenuItem");
            this.ノーマルToolStripMenuItem.Click += new System.EventHandler(this.ノーマルToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // 言語ToolStripMenuItem
            // 
            this.言語ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.アラビア語ToolStripMenuItem,
            this.英語ToolStripMenuItem,
            this.ドイツ語ToolStripMenuItem,
            this.スペイン語ToolStripMenuItem,
            this.フランス語ToolStripMenuItem,
            this.日本語ToolStripMenuItem,
            this.ロシア語ToolStripMenuItem,
            this.中国語ToolStripMenuItem});
            this.言語ToolStripMenuItem.Name = "言語ToolStripMenuItem";
            resources.ApplyResources(this.言語ToolStripMenuItem, "言語ToolStripMenuItem");
            // 
            // アラビア語ToolStripMenuItem
            // 
            this.アラビア語ToolStripMenuItem.Name = "アラビア語ToolStripMenuItem";
            resources.ApplyResources(this.アラビア語ToolStripMenuItem, "アラビア語ToolStripMenuItem");
            this.アラビア語ToolStripMenuItem.Click += new System.EventHandler(this.アラビア語ToolStripMenuItem_Click);
            // 
            // 英語ToolStripMenuItem
            // 
            this.英語ToolStripMenuItem.Name = "英語ToolStripMenuItem";
            resources.ApplyResources(this.英語ToolStripMenuItem, "英語ToolStripMenuItem");
            this.英語ToolStripMenuItem.Click += new System.EventHandler(this.英語ToolStripMenuItem_Click);
            // 
            // ドイツ語ToolStripMenuItem
            // 
            this.ドイツ語ToolStripMenuItem.Name = "ドイツ語ToolStripMenuItem";
            resources.ApplyResources(this.ドイツ語ToolStripMenuItem, "ドイツ語ToolStripMenuItem");
            this.ドイツ語ToolStripMenuItem.Click += new System.EventHandler(this.ドイツ語ToolStripMenuItem_Click);
            // 
            // スペイン語ToolStripMenuItem
            // 
            this.スペイン語ToolStripMenuItem.Name = "スペイン語ToolStripMenuItem";
            resources.ApplyResources(this.スペイン語ToolStripMenuItem, "スペイン語ToolStripMenuItem");
            this.スペイン語ToolStripMenuItem.Click += new System.EventHandler(this.スペイン語ToolStripMenuItem_Click);
            // 
            // フランス語ToolStripMenuItem
            // 
            this.フランス語ToolStripMenuItem.Name = "フランス語ToolStripMenuItem";
            resources.ApplyResources(this.フランス語ToolStripMenuItem, "フランス語ToolStripMenuItem");
            this.フランス語ToolStripMenuItem.Click += new System.EventHandler(this.フランス語ToolStripMenuItem_Click);
            // 
            // 日本語ToolStripMenuItem
            // 
            this.日本語ToolStripMenuItem.Name = "日本語ToolStripMenuItem";
            resources.ApplyResources(this.日本語ToolStripMenuItem, "日本語ToolStripMenuItem");
            this.日本語ToolStripMenuItem.Click += new System.EventHandler(this.日本語ToolStripMenuItem_Click);
            // 
            // ロシア語ToolStripMenuItem
            // 
            this.ロシア語ToolStripMenuItem.Name = "ロシア語ToolStripMenuItem";
            resources.ApplyResources(this.ロシア語ToolStripMenuItem, "ロシア語ToolStripMenuItem");
            this.ロシア語ToolStripMenuItem.Click += new System.EventHandler(this.ロシア語ToolStripMenuItem_Click);
            // 
            // 中国語ToolStripMenuItem
            // 
            this.中国語ToolStripMenuItem.Name = "中国語ToolStripMenuItem";
            resources.ApplyResources(this.中国語ToolStripMenuItem, "中国語ToolStripMenuItem");
            this.中国語ToolStripMenuItem.Click += new System.EventHandler(this.中国語ToolStripMenuItem_Click);
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            resources.ApplyResources(this.ヘルプHToolStripMenuItem, "ヘルプHToolStripMenuItem");
            this.ヘルプHToolStripMenuItem.Click += new System.EventHandler(this.ヘルプHToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.SmallChange = 2;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trackBar1_KeyDown);
            // 
            // AxVLCPlugin21
            // 
            resources.ApplyResources(this.AxVLCPlugin21, "AxVLCPlugin21");
            this.AxVLCPlugin21.Name = "AxVLCPlugin21";
            this.AxVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxVLCPlugin21.OcxState")));
            this.AxVLCPlugin21.MediaPlayerPlaying += new System.EventHandler(this.AxVLCPlugin21_MediaPlayerPlaying_1);
            this.AxVLCPlugin21.MediaPlayerPaused += new System.EventHandler(this.AxVLCPlugin21_MediaPlayerPaused_1);
            this.AxVLCPlugin21.ClickEvent += new System.EventHandler(this.AxVLCPlugin21_ClickEvent_1);
            this.AxVLCPlugin21.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AxVLCPlugin21_PreviewKeyDown_1);
            // 
            // helpProvider1
            // 
            resources.ApplyResources(this.helpProvider1, "helpProvider1");
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AxVLCPlugin21);
            this.Controls.Add(this.SubtitletextBox);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.videoSpeedLabel);
            this.Controls.Add(this.InputSubtitleButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AxVLCPlugin21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button InputSubtitleButton;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.TextBox SubtitletextBox;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private System.Windows.Forms.Label videoSpeedLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem モードToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ノーマルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開始終了終了ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem 上に追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下に追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字幕を開くToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem やり直すToolStripMenuItem;
        private AxAXVLC.AxVLCPlugin2 AxVLCPlugin21;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 言語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem アラビア語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ドイツ語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem スペイン語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem フランス語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日本語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ロシア語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中国語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字幕の遅延ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 英語ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label2;
    }
}

