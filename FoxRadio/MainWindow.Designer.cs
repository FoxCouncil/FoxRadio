namespace FoxRadio
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            startBtn = new Button();
            stopBtn = new Button();
            connectionLabel = new Label();
            statusStrip = new StatusStrip();
            messageToolStripStatusLabel = new ToolStripStatusLabel();
            sloganToolStripStatusLabel = new ToolStripStatusLabel();
            audioBitrateToolStripStatusLabel = new ToolStripStatusLabel();
            metadataGroupBox = new GroupBox();
            pictureBox = new PictureBox();
            genreLinkLabel = new LinkLabel();
            genreMetaLabel = new Label();
            albumLinkLabel = new LinkLabel();
            artistLinkLabel = new LinkLabel();
            titleLinkLabel = new LinkLabel();
            albumMetaLabel = new Label();
            artistMetaLabel = new Label();
            titleMetaLabel = new Label();
            stationsComboBox = new ComboBox();
            stationsLabel = new Label();
            errorRateLabel = new Label();
            errorRateProgressBar = new ProgressBar();
            errorRateValueLabel = new Label();
            signalProgressBar = new ProgressBar();
            signalValueLabel = new Label();
            signalLabel = new Label();
            statusStrip.SuspendLayout();
            metadataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // startBtn
            // 
            startBtn.Location = new Point(12, 12);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(112, 34);
            startBtn.TabIndex = 0;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // stopBtn
            // 
            stopBtn.Location = new Point(130, 12);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(112, 34);
            stopBtn.TabIndex = 1;
            stopBtn.Text = "Stop";
            stopBtn.UseVisualStyleBackColor = true;
            stopBtn.Click += stopBtn_Click;
            // 
            // connectionLabel
            // 
            connectionLabel.AutoSize = true;
            connectionLabel.Location = new Point(248, 17);
            connectionLabel.Name = "connectionLabel";
            connectionLabel.Size = new Size(228, 25);
            connectionLabel.TabIndex = 2;
            connectionLabel.Text = "This is a wonderful Text Box";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(24, 24);
            statusStrip.Items.AddRange(new ToolStripItem[] { messageToolStripStatusLabel, sloganToolStripStatusLabel, audioBitrateToolStripStatusLabel });
            statusStrip.Location = new Point(0, 328);
            statusStrip.Name = "statusStrip";
            statusStrip.RenderMode = ToolStripRenderMode.Professional;
            statusStrip.Size = new Size(974, 32);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip1";
            // 
            // messageToolStripStatusLabel
            // 
            messageToolStripStatusLabel.BorderStyle = Border3DStyle.Sunken;
            messageToolStripStatusLabel.Name = "messageToolStripStatusLabel";
            messageToolStripStatusLabel.Size = new Size(117, 25);
            messageToolStripStatusLabel.Text = "FOXX Radio |";
            // 
            // sloganToolStripStatusLabel
            // 
            sloganToolStripStatusLabel.Name = "sloganToolStripStatusLabel";
            sloganToolStripStatusLabel.Size = new Size(232, 25);
            sloganToolStripStatusLabel.Text = "My Amazing Radio Station |";
            // 
            // audioBitrateToolStripStatusLabel
            // 
            audioBitrateToolStripStatusLabel.Font = new Font("Consolas", 10F, FontStyle.Bold, GraphicsUnit.Point);
            audioBitrateToolStripStatusLabel.ForeColor = Color.Green;
            audioBitrateToolStripStatusLabel.Name = "audioBitrateToolStripStatusLabel";
            audioBitrateToolStripStatusLabel.Size = new Size(76, 25);
            audioBitrateToolStripStatusLabel.Text = "0 kbps";
            // 
            // metadataGroupBox
            // 
            metadataGroupBox.Controls.Add(pictureBox);
            metadataGroupBox.Controls.Add(genreLinkLabel);
            metadataGroupBox.Controls.Add(genreMetaLabel);
            metadataGroupBox.Controls.Add(albumLinkLabel);
            metadataGroupBox.Controls.Add(artistLinkLabel);
            metadataGroupBox.Controls.Add(titleLinkLabel);
            metadataGroupBox.Controls.Add(albumMetaLabel);
            metadataGroupBox.Controls.Add(artistMetaLabel);
            metadataGroupBox.Controls.Add(titleMetaLabel);
            metadataGroupBox.Location = new Point(12, 91);
            metadataGroupBox.Name = "metadataGroupBox";
            metadataGroupBox.Size = new Size(950, 172);
            metadataGroupBox.TabIndex = 4;
            metadataGroupBox.TabStop = false;
            metadataGroupBox.Text = "Metadata";
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox.BackColor = SystemColors.ControlDark;
            pictureBox.Location = new Point(11, 30);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(130, 130);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 8;
            pictureBox.TabStop = false;
            // 
            // genreLinkLabel
            // 
            genreLinkLabel.AutoSize = true;
            genreLinkLabel.Location = new Point(219, 135);
            genreLinkLabel.Name = "genreLinkLabel";
            genreLinkLabel.Size = new Size(136, 25);
            genreLinkLabel.TabIndex = 7;
            genreLinkLabel.TabStop = true;
            genreLinkLabel.Text = "Fantastic Genre!";
            // 
            // genreMetaLabel
            // 
            genreMetaLabel.AutoSize = true;
            genreMetaLabel.Location = new Point(151, 135);
            genreMetaLabel.Name = "genreMetaLabel";
            genreMetaLabel.Size = new Size(62, 25);
            genreMetaLabel.TabIndex = 6;
            genreMetaLabel.Text = "Genre:";
            genreMetaLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // albumLinkLabel
            // 
            albumLinkLabel.AutoSize = true;
            albumLinkLabel.Location = new Point(219, 100);
            albumLinkLabel.Name = "albumLinkLabel";
            albumLinkLabel.Size = new Size(136, 25);
            albumLinkLabel.TabIndex = 5;
            albumLinkLabel.TabStop = true;
            albumLinkLabel.Text = "The Best Album";
            // 
            // artistLinkLabel
            // 
            artistLinkLabel.AutoSize = true;
            artistLinkLabel.Location = new Point(219, 65);
            artistLinkLabel.Name = "artistLinkLabel";
            artistLinkLabel.Size = new Size(152, 25);
            artistLinkLabel.TabIndex = 4;
            artistLinkLabel.TabStop = true;
            artistLinkLabel.Text = "Some Great Artist";
            // 
            // titleLinkLabel
            // 
            titleLinkLabel.AutoSize = true;
            titleLinkLabel.Location = new Point(219, 30);
            titleLinkLabel.Name = "titleLinkLabel";
            titleLinkLabel.Size = new Size(91, 25);
            titleLinkLabel.TabIndex = 3;
            titleLinkLabel.TabStop = true;
            titleLinkLabel.Text = "Song Title";
            // 
            // albumMetaLabel
            // 
            albumMetaLabel.AutoSize = true;
            albumMetaLabel.Location = new Point(144, 100);
            albumMetaLabel.Name = "albumMetaLabel";
            albumMetaLabel.Size = new Size(69, 25);
            albumMetaLabel.TabIndex = 2;
            albumMetaLabel.Text = "Album:";
            albumMetaLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // artistMetaLabel
            // 
            artistMetaLabel.AutoSize = true;
            artistMetaLabel.Location = new Point(155, 65);
            artistMetaLabel.Name = "artistMetaLabel";
            artistMetaLabel.Size = new Size(58, 25);
            artistMetaLabel.TabIndex = 1;
            artistMetaLabel.Text = "Artist:";
            artistMetaLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // titleMetaLabel
            // 
            titleMetaLabel.AutoSize = true;
            titleMetaLabel.Location = new Point(165, 30);
            titleMetaLabel.Name = "titleMetaLabel";
            titleMetaLabel.Size = new Size(48, 25);
            titleMetaLabel.TabIndex = 0;
            titleMetaLabel.Text = "Title:";
            titleMetaLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // stationsComboBox
            // 
            stationsComboBox.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point);
            stationsComboBox.FormattingEnabled = true;
            stationsComboBox.Location = new Point(93, 52);
            stationsComboBox.Name = "stationsComboBox";
            stationsComboBox.Size = new Size(869, 29);
            stationsComboBox.TabIndex = 5;
            // 
            // stationsLabel
            // 
            stationsLabel.AutoSize = true;
            stationsLabel.Location = new Point(8, 54);
            stationsLabel.Name = "stationsLabel";
            stationsLabel.Size = new Size(79, 25);
            stationsLabel.TabIndex = 6;
            stationsLabel.Text = "Stations:";
            // 
            // errorRateLabel
            // 
            errorRateLabel.AutoSize = true;
            errorRateLabel.Location = new Point(8, 266);
            errorRateLabel.Name = "errorRateLabel";
            errorRateLabel.Size = new Size(94, 25);
            errorRateLabel.TabIndex = 7;
            errorRateLabel.Text = "Error Rate:";
            // 
            // errorRateProgressBar
            // 
            errorRateProgressBar.Location = new Point(156, 266);
            errorRateProgressBar.Name = "errorRateProgressBar";
            errorRateProgressBar.Size = new Size(806, 25);
            errorRateProgressBar.TabIndex = 8;
            // 
            // errorRateValueLabel
            // 
            errorRateValueLabel.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point);
            errorRateValueLabel.Location = new Point(97, 269);
            errorRateValueLabel.Name = "errorRateValueLabel";
            errorRateValueLabel.Size = new Size(61, 25);
            errorRateValueLabel.TabIndex = 9;
            errorRateValueLabel.Text = "100%";
            errorRateValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // signalProgressBar
            // 
            signalProgressBar.Location = new Point(156, 296);
            signalProgressBar.MarqueeAnimationSpeed = 0;
            signalProgressBar.Name = "signalProgressBar";
            signalProgressBar.Size = new Size(806, 25);
            signalProgressBar.Step = 1;
            signalProgressBar.TabIndex = 11;
            // 
            // signalValueLabel
            // 
            signalValueLabel.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point);
            signalValueLabel.Location = new Point(97, 299);
            signalValueLabel.Name = "signalValueLabel";
            signalValueLabel.Size = new Size(61, 25);
            signalValueLabel.TabIndex = 12;
            signalValueLabel.Text = "100%";
            signalValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // signalLabel
            // 
            signalLabel.AutoSize = true;
            signalLabel.Location = new Point(38, 298);
            signalLabel.Name = "signalLabel";
            signalLabel.Size = new Size(64, 25);
            signalLabel.TabIndex = 10;
            signalLabel.Text = "Signal:";
            signalLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 360);
            Controls.Add(signalProgressBar);
            Controls.Add(signalValueLabel);
            Controls.Add(signalLabel);
            Controls.Add(errorRateProgressBar);
            Controls.Add(errorRateValueLabel);
            Controls.Add(errorRateLabel);
            Controls.Add(stationsLabel);
            Controls.Add(stationsComboBox);
            Controls.Add(metadataGroupBox);
            Controls.Add(statusStrip);
            Controls.Add(connectionLabel);
            Controls.Add(stopBtn);
            Controls.Add(startBtn);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1000, 420);
            MinimumSize = new Size(1000, 420);
            Name = "MainWindow";
            Text = "FoxRadio | github.com/FoxCouncil/FoxRadio";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            metadataGroupBox.ResumeLayout(false);
            metadataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startBtn;
        private Button stopBtn;
        private Label connectionLabel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel messageToolStripStatusLabel;
        private ToolStripStatusLabel audioBitrateToolStripStatusLabel;
        private GroupBox metadataGroupBox;
        private Label albumMetaLabel;
        private Label artistMetaLabel;
        private Label titleMetaLabel;
        private LinkLabel albumLinkLabel;
        private LinkLabel artistLinkLabel;
        private LinkLabel titleLinkLabel;
        private ComboBox stationsComboBox;
        private Label stationsLabel;
        private LinkLabel genreLinkLabel;
        private Label genreMetaLabel;
        private ToolStripStatusLabel sloganToolStripStatusLabel;
        private PictureBox pictureBox;
        private Label errorRateLabel;
        private ProgressBar errorRateProgressBar;
        private Label errorRateValueLabel;
        private ProgressBar signalProgressBar;
        private Label signalValueLabel;
        private Label signalLabel;
    }
}