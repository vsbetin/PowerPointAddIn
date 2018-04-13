namespace ChurchAddIn
{
    partial class BibleRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public BibleRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonButton rusNewButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibleRibbon));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.bibles = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.box2 = this.Factory.CreateRibbonBox();
            this.rusSinButton = this.Factory.CreateRibbonButton();
            this.box3 = this.Factory.CreateRibbonBox();
            this.engASVButton = this.Factory.CreateRibbonButton();
            this.engNIVButton = this.Factory.CreateRibbonButton();
            this.box4 = this.Factory.CreateRibbonBox();
            this.engKJVButton = this.Factory.CreateRibbonButton();
            this.engESVButton = this.Factory.CreateRibbonButton();
            this.box5 = this.Factory.CreateRibbonBox();
            this.ukrButton = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.addSlidesButton = this.Factory.CreateRibbonButton();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            rusNewButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.bibles.SuspendLayout();
            this.box1.SuspendLayout();
            this.box2.SuspendLayout();
            this.box3.SuspendLayout();
            this.box4.SuspendLayout();
            this.box5.SuspendLayout();
            this.group1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // rusNewButton
            // 
            rusNewButton.Image = global::ChurchAddIn.Properties.Resources.ru;
            rusNewButton.KeyTip = "T";
            rusNewButton.Label = "Русский Новый";
            rusNewButton.Name = "rusNewButton";
            rusNewButton.ScreenTip = "Русский новый перевод";
            rusNewButton.ShowImage = true;
            rusNewButton.SuperTip = "Библия";
            rusNewButton.Tag = "g";
            rusNewButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.rusNewButton_Click);
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.bibles);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "Church";
            this.tab1.Name = "tab1";
            // 
            // bibles
            // 
            this.bibles.Items.Add(this.box1);
            this.bibles.Label = "Bibles";
            this.bibles.Name = "bibles";
            // 
            // box1
            // 
            this.box1.Items.Add(this.box2);
            this.box1.Items.Add(this.box3);
            this.box1.Items.Add(this.box4);
            this.box1.Items.Add(this.box5);
            this.box1.Name = "box1";
            // 
            // box2
            // 
            this.box2.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box2.Items.Add(this.rusSinButton);
            this.box2.Items.Add(rusNewButton);
            this.box2.Name = "box2";
            // 
            // rusSinButton
            // 
            this.rusSinButton.Image = global::ChurchAddIn.Properties.Resources.ru;
            this.rusSinButton.Label = "Русский Синодальный";
            this.rusSinButton.Name = "rusSinButton";
            this.rusSinButton.ScreenTip = "Русский синодальный перевод";
            this.rusSinButton.ShowImage = true;
            this.rusSinButton.SuperTip = "Библия";
            this.rusSinButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.rusSinButton_Click);
            // 
            // box3
            // 
            this.box3.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box3.Items.Add(this.engASVButton);
            this.box3.Items.Add(this.engNIVButton);
            this.box3.Name = "box3";
            // 
            // engASVButton
            // 
            this.engASVButton.Image = ((System.Drawing.Image)(resources.GetObject("engASVButton.Image")));
            this.engASVButton.Label = "English ASV";
            this.engASVButton.Name = "engASVButton";
            this.engASVButton.ScreenTip = "American Standart Version";
            this.engASVButton.ShowImage = true;
            this.engASVButton.SuperTip = "Bible";
            this.engASVButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.engASVButton_Click);
            // 
            // engNIVButton
            // 
            this.engNIVButton.Image = ((System.Drawing.Image)(resources.GetObject("engNIVButton.Image")));
            this.engNIVButton.Label = "English NIV";
            this.engNIVButton.Name = "engNIVButton";
            this.engNIVButton.ScreenTip = "New International Version";
            this.engNIVButton.ShowImage = true;
            this.engNIVButton.SuperTip = "Bible";
            this.engNIVButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.engNIVButton_Click);
            // 
            // box4
            // 
            this.box4.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box4.Items.Add(this.engKJVButton);
            this.box4.Items.Add(this.engESVButton);
            this.box4.Name = "box4";
            // 
            // engKJVButton
            // 
            this.engKJVButton.Image = global::ChurchAddIn.Properties.Resources.uk;
            this.engKJVButton.Label = "English KJV";
            this.engKJVButton.Name = "engKJVButton";
            this.engKJVButton.ScreenTip = "King James Version";
            this.engKJVButton.ShowImage = true;
            this.engKJVButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.engKJVButton_Click);
            // 
            // engESVButton
            // 
            this.engESVButton.Image = global::ChurchAddIn.Properties.Resources.uk;
            this.engESVButton.Label = "English ESV";
            this.engESVButton.Name = "engESVButton";
            this.engESVButton.ScreenTip = "English Standart Version";
            this.engESVButton.ShowImage = true;
            this.engESVButton.SuperTip = "Bible";
            this.engESVButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.engESVButton_Click);
            // 
            // box5
            // 
            this.box5.BoxStyle = Microsoft.Office.Tools.Ribbon.RibbonBoxStyle.Vertical;
            this.box5.Items.Add(this.ukrButton);
            this.box5.Name = "box5";
            // 
            // ukrButton
            // 
            this.ukrButton.Image = global::ChurchAddIn.Properties.Resources.ua;
            this.ukrButton.Label = "Українська І.Огієнка";
            this.ukrButton.Name = "ukrButton";
            this.ukrButton.ScreenTip = "Український Переклад І.Огієнка";
            this.ukrButton.ShowImage = true;
            this.ukrButton.SuperTip = "Біблія";
            this.ukrButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ukrButton_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.addSlidesButton);
            this.group1.Label = "Add slides";
            this.group1.Name = "group1";
            // 
            // addSlidesButton
            // 
            this.addSlidesButton.Image = global::ChurchAddIn.Properties.Resources.Plus;
            this.addSlidesButton.Label = "Add new slides";
            this.addSlidesButton.Name = "addSlidesButton";
            this.addSlidesButton.ScreenTip = "Add new slides";
            this.addSlidesButton.ShowImage = true;
            this.addSlidesButton.SuperTip = "Select PowerPoint file to add after selected slide";
            this.addSlidesButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.addSlidesButton_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(300, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "PowerPoint |*.pptx;*.ppt";
            // 
            // BibleRibbon
            // 
            this.Name = "BibleRibbon";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Bible_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.bibles.ResumeLayout(false);
            this.bibles.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();
            this.box2.ResumeLayout(false);
            this.box2.PerformLayout();
            this.box3.ResumeLayout(false);
            this.box3.PerformLayout();
            this.box4.ResumeLayout(false);
            this.box4.PerformLayout();
            this.box5.ResumeLayout(false);
            this.box5.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup bibles;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ukrButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton rusSinButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton engESVButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box2;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton addSlidesButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton engKJVButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton engASVButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton engNIVButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box4;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box5;
    }

    partial class ThisRibbonCollection
    {
        internal BibleRibbon Bible
        {
            get { return this.GetRibbon<BibleRibbon>(); }
        }
    }
}
