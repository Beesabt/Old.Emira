namespace emira.GUI
{
    partial class StatisticsSettingsPage
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
            this.pHeader = new System.Windows.Forms.Panel();
            this.lChartSettings = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lAxisTitle = new System.Windows.Forms.Label();
            this.lTextAlignment = new System.Windows.Forms.Label();
            this.lTextOrientation = new System.Windows.Forms.Label();
            this.gbAxes = new System.Windows.Forms.GroupBox();
            this.btnAxisTextColor = new System.Windows.Forms.Button();
            this.cbAxisUnderline = new System.Windows.Forms.CheckBox();
            this.cbAxisItalic = new System.Windows.Forms.CheckBox();
            this.cbAxisBold = new System.Windows.Forms.CheckBox();
            this.cbAxisFont = new System.Windows.Forms.ComboBox();
            this.cbAxisSize = new System.Windows.Forms.ComboBox();
            this.cbAxisYTextOrientation = new System.Windows.Forms.ComboBox();
            this.cbAxisXTextOrientation = new System.Windows.Forms.ComboBox();
            this.cbAxisYTextAlignment = new System.Windows.Forms.ComboBox();
            this.cbAxisXTextAlignment = new System.Windows.Forms.ComboBox();
            this.tbAxisYTitle = new System.Windows.Forms.TextBox();
            this.tbAxisXTitle = new System.Windows.Forms.TextBox();
            this.gbCommon = new System.Windows.Forms.GroupBox();
            this.btnCommonTextColor = new System.Windows.Forms.Button();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.cbCommonUnderline = new System.Windows.Forms.CheckBox();
            this.lColor = new System.Windows.Forms.Label();
            this.cbCommonItalic = new System.Windows.Forms.CheckBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.cbCommonBold = new System.Windows.Forms.CheckBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.cbCommonFont = new System.Windows.Forms.ComboBox();
            this.cbCommonSize = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pHeader.SuspendLayout();
            this.gbAxes.SuspendLayout();
            this.gbCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(184)))));
            this.pHeader.Controls.Add(this.lChartSettings);
            this.pHeader.Controls.Add(this.btnExit);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(670, 30);
            this.pHeader.TabIndex = 1;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // lChartSettings
            // 
            this.lChartSettings.AutoSize = true;
            this.lChartSettings.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lChartSettings.ForeColor = System.Drawing.Color.White;
            this.lChartSettings.Location = new System.Drawing.Point(0, 0);
            this.lChartSettings.Name = "lChartSettings";
            this.lChartSettings.Size = new System.Drawing.Size(141, 30);
            this.lChartSettings.TabIndex = 4;
            this.lChartSettings.Text = "Chart settings";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::emira.Properties.Resources.close_icon_white_26;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(184)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(620, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 30);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Axis X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Axis Y";
            // 
            // lAxisTitle
            // 
            this.lAxisTitle.AutoSize = true;
            this.lAxisTitle.Location = new System.Drawing.Point(21, 120);
            this.lAxisTitle.Name = "lAxisTitle";
            this.lAxisTitle.Size = new System.Drawing.Size(70, 18);
            this.lAxisTitle.TabIndex = 4;
            this.lAxisTitle.Text = "Axis Titel:";
            // 
            // lTextAlignment
            // 
            this.lTextAlignment.AutoSize = true;
            this.lTextAlignment.Location = new System.Drawing.Point(21, 168);
            this.lTextAlignment.Name = "lTextAlignment";
            this.lTextAlignment.Size = new System.Drawing.Size(108, 18);
            this.lTextAlignment.TabIndex = 5;
            this.lTextAlignment.Text = "Text Alignment:";
            // 
            // lTextOrientation
            // 
            this.lTextOrientation.AutoSize = true;
            this.lTextOrientation.Location = new System.Drawing.Point(21, 213);
            this.lTextOrientation.Name = "lTextOrientation";
            this.lTextOrientation.Size = new System.Drawing.Size(116, 18);
            this.lTextOrientation.TabIndex = 6;
            this.lTextOrientation.Text = "Text Orientation:";
            // 
            // gbAxes
            // 
            this.gbAxes.Controls.Add(this.btnAxisTextColor);
            this.gbAxes.Controls.Add(this.cbAxisUnderline);
            this.gbAxes.Controls.Add(this.cbAxisItalic);
            this.gbAxes.Controls.Add(this.cbAxisBold);
            this.gbAxes.Controls.Add(this.cbAxisFont);
            this.gbAxes.Controls.Add(this.cbAxisSize);
            this.gbAxes.Controls.Add(this.cbAxisYTextOrientation);
            this.gbAxes.Controls.Add(this.cbAxisXTextOrientation);
            this.gbAxes.Controls.Add(this.cbAxisYTextAlignment);
            this.gbAxes.Controls.Add(this.cbAxisXTextAlignment);
            this.gbAxes.Controls.Add(this.tbAxisYTitle);
            this.gbAxes.Controls.Add(this.lTextOrientation);
            this.gbAxes.Controls.Add(this.tbAxisXTitle);
            this.gbAxes.Controls.Add(this.lTextAlignment);
            this.gbAxes.Controls.Add(this.label1);
            this.gbAxes.Controls.Add(this.label2);
            this.gbAxes.Controls.Add(this.lAxisTitle);
            this.gbAxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbAxes.Location = new System.Drawing.Point(12, 220);
            this.gbAxes.Name = "gbAxes";
            this.gbAxes.Size = new System.Drawing.Size(646, 256);
            this.gbAxes.TabIndex = 7;
            this.gbAxes.TabStop = false;
            this.gbAxes.Text = "Axes";
            // 
            // btnAxisTextColor
            // 
            this.btnAxisTextColor.FlatAppearance.BorderSize = 0;
            this.btnAxisTextColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.btnAxisTextColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.btnAxisTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAxisTextColor.Image = global::emira.Properties.Resources.text_color_icon_color_24;
            this.btnAxisTextColor.Location = new System.Drawing.Point(407, 37);
            this.btnAxisTextColor.Name = "btnAxisTextColor";
            this.btnAxisTextColor.Size = new System.Drawing.Size(30, 30);
            this.btnAxisTextColor.TabIndex = 19;
            this.btnAxisTextColor.UseVisualStyleBackColor = true;
            this.btnAxisTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // cbAxisUnderline
            // 
            this.cbAxisUnderline.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbAxisUnderline.AutoSize = true;
            this.cbAxisUnderline.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(213)))), ((int)(((byte)(242)))));
            this.cbAxisUnderline.FlatAppearance.BorderSize = 0;
            this.cbAxisUnderline.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(213)))), ((int)(((byte)(242)))));
            this.cbAxisUnderline.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbAxisUnderline.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbAxisUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAxisUnderline.Image = global::emira.Properties.Resources.underline_icon_color_24;
            this.cbAxisUnderline.Location = new System.Drawing.Point(370, 37);
            this.cbAxisUnderline.Name = "cbAxisUnderline";
            this.cbAxisUnderline.Size = new System.Drawing.Size(30, 30);
            this.cbAxisUnderline.TabIndex = 17;
            this.cbAxisUnderline.UseVisualStyleBackColor = true;
            this.cbAxisUnderline.Click += new System.EventHandler(this.cbAxisUnderline_Click);
            this.cbAxisUnderline.MouseHover += new System.EventHandler(this.cbAxisUnderline_MouseHover);
            // 
            // cbAxisItalic
            // 
            this.cbAxisItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbAxisItalic.AutoSize = true;
            this.cbAxisItalic.FlatAppearance.BorderSize = 0;
            this.cbAxisItalic.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(213)))), ((int)(((byte)(242)))));
            this.cbAxisItalic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbAxisItalic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbAxisItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAxisItalic.Image = global::emira.Properties.Resources.italic_icon_color_24;
            this.cbAxisItalic.Location = new System.Drawing.Point(340, 37);
            this.cbAxisItalic.Name = "cbAxisItalic";
            this.cbAxisItalic.Size = new System.Drawing.Size(30, 30);
            this.cbAxisItalic.TabIndex = 16;
            this.cbAxisItalic.UseVisualStyleBackColor = true;
            // 
            // cbAxisBold
            // 
            this.cbAxisBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbAxisBold.AutoSize = true;
            this.cbAxisBold.FlatAppearance.BorderSize = 0;
            this.cbAxisBold.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(213)))), ((int)(((byte)(242)))));
            this.cbAxisBold.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbAxisBold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbAxisBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAxisBold.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAxisBold.Image = global::emira.Properties.Resources.bold_icon_color_24;
            this.cbAxisBold.Location = new System.Drawing.Point(310, 37);
            this.cbAxisBold.Name = "cbAxisBold";
            this.cbAxisBold.Size = new System.Drawing.Size(30, 30);
            this.cbAxisBold.TabIndex = 15;
            this.cbAxisBold.UseVisualStyleBackColor = true;
            // 
            // cbAxisFont
            // 
            this.cbAxisFont.FormattingEnabled = true;
            this.cbAxisFont.Location = new System.Drawing.Point(24, 39);
            this.cbAxisFont.Name = "cbAxisFont";
            this.cbAxisFont.Size = new System.Drawing.Size(220, 26);
            this.cbAxisFont.TabIndex = 13;
            // 
            // cbAxisSize
            // 
            this.cbAxisSize.FormattingEnabled = true;
            this.cbAxisSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.cbAxisSize.Location = new System.Drawing.Point(245, 39);
            this.cbAxisSize.Name = "cbAxisSize";
            this.cbAxisSize.Size = new System.Drawing.Size(60, 26);
            this.cbAxisSize.TabIndex = 12;
            // 
            // cbAxisYTextOrientation
            // 
            this.cbAxisYTextOrientation.FormattingEnabled = true;
            this.cbAxisYTextOrientation.Location = new System.Drawing.Point(407, 206);
            this.cbAxisYTextOrientation.Name = "cbAxisYTextOrientation";
            this.cbAxisYTextOrientation.Size = new System.Drawing.Size(220, 26);
            this.cbAxisYTextOrientation.TabIndex = 10;
            this.cbAxisYTextOrientation.SelectedIndexChanged += new System.EventHandler(this.cbAxisYTextOrientation_SelectedIndexChanged);
            this.cbAxisYTextOrientation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAxisYTextOrientation_KeyPress);
            // 
            // cbAxisXTextOrientation
            // 
            this.cbAxisXTextOrientation.FormattingEnabled = true;
            this.cbAxisXTextOrientation.Location = new System.Drawing.Point(146, 206);
            this.cbAxisXTextOrientation.Name = "cbAxisXTextOrientation";
            this.cbAxisXTextOrientation.Size = new System.Drawing.Size(220, 26);
            this.cbAxisXTextOrientation.TabIndex = 9;
            this.cbAxisXTextOrientation.SelectedIndexChanged += new System.EventHandler(this.cbAxisXTextOrientation_SelectedIndexChanged);
            this.cbAxisXTextOrientation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAxisXTextOrientation_KeyPress);
            // 
            // cbAxisYTextAlignment
            // 
            this.cbAxisYTextAlignment.FormattingEnabled = true;
            this.cbAxisYTextAlignment.Location = new System.Drawing.Point(407, 160);
            this.cbAxisYTextAlignment.Name = "cbAxisYTextAlignment";
            this.cbAxisYTextAlignment.Size = new System.Drawing.Size(220, 26);
            this.cbAxisYTextAlignment.TabIndex = 8;
            this.cbAxisYTextAlignment.SelectedIndexChanged += new System.EventHandler(this.cbAxisYTextAlignment_SelectedIndexChanged);
            this.cbAxisYTextAlignment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAxisYTextAlignment_KeyPress);
            // 
            // cbAxisXTextAlignment
            // 
            this.cbAxisXTextAlignment.FormattingEnabled = true;
            this.cbAxisXTextAlignment.Location = new System.Drawing.Point(146, 160);
            this.cbAxisXTextAlignment.Name = "cbAxisXTextAlignment";
            this.cbAxisXTextAlignment.Size = new System.Drawing.Size(220, 26);
            this.cbAxisXTextAlignment.TabIndex = 7;
            this.cbAxisXTextAlignment.SelectedIndexChanged += new System.EventHandler(this.cbAxisXTextAlignment_SelectedIndexChanged);
            this.cbAxisXTextAlignment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAxisXTextAlignment_KeyPress);
            // 
            // tbAxisYTitle
            // 
            this.tbAxisYTitle.Location = new System.Drawing.Point(407, 119);
            this.tbAxisYTitle.MaxLength = 100;
            this.tbAxisYTitle.Name = "tbAxisYTitle";
            this.tbAxisYTitle.Size = new System.Drawing.Size(220, 24);
            this.tbAxisYTitle.TabIndex = 6;
            this.tbAxisYTitle.TextChanged += new System.EventHandler(this.tbAxisYTitle_TextChanged);
            // 
            // tbAxisXTitle
            // 
            this.tbAxisXTitle.Location = new System.Drawing.Point(146, 119);
            this.tbAxisXTitle.MaxLength = 100;
            this.tbAxisXTitle.Name = "tbAxisXTitle";
            this.tbAxisXTitle.Size = new System.Drawing.Size(220, 24);
            this.tbAxisXTitle.TabIndex = 5;
            this.tbAxisXTitle.TextChanged += new System.EventHandler(this.tbAxisXTitle_TextChanged);
            // 
            // gbCommon
            // 
            this.gbCommon.Controls.Add(this.btnCommonTextColor);
            this.gbCommon.Controls.Add(this.cbColor);
            this.gbCommon.Controls.Add(this.cbCommonUnderline);
            this.gbCommon.Controls.Add(this.lColor);
            this.gbCommon.Controls.Add(this.cbCommonItalic);
            this.gbCommon.Controls.Add(this.tbTitle);
            this.gbCommon.Controls.Add(this.cbCommonBold);
            this.gbCommon.Controls.Add(this.lTitle);
            this.gbCommon.Controls.Add(this.cbCommonFont);
            this.gbCommon.Controls.Add(this.cbCommonSize);
            this.gbCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbCommon.Location = new System.Drawing.Point(12, 53);
            this.gbCommon.Name = "gbCommon";
            this.gbCommon.Size = new System.Drawing.Size(646, 161);
            this.gbCommon.TabIndex = 11;
            this.gbCommon.TabStop = false;
            this.gbCommon.Text = "Common";
            // 
            // btnCommonTextColor
            // 
            this.btnCommonTextColor.FlatAppearance.BorderSize = 0;
            this.btnCommonTextColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.btnCommonTextColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.btnCommonTextColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommonTextColor.Image = global::emira.Properties.Resources.text_color_icon_color_24;
            this.btnCommonTextColor.Location = new System.Drawing.Point(407, 31);
            this.btnCommonTextColor.Name = "btnCommonTextColor";
            this.btnCommonTextColor.Size = new System.Drawing.Size(30, 30);
            this.btnCommonTextColor.TabIndex = 25;
            this.btnCommonTextColor.UseVisualStyleBackColor = true;
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(71, 109);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(211, 26);
            this.cbColor.TabIndex = 11;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.cbColor_SelectedIndexChanged);
            this.cbColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbColor_KeyPress);
            // 
            // cbCommonUnderline
            // 
            this.cbCommonUnderline.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbCommonUnderline.AutoSize = true;
            this.cbCommonUnderline.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(213)))), ((int)(((byte)(242)))));
            this.cbCommonUnderline.FlatAppearance.BorderSize = 0;
            this.cbCommonUnderline.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(213)))), ((int)(((byte)(242)))));
            this.cbCommonUnderline.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbCommonUnderline.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbCommonUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCommonUnderline.Image = global::emira.Properties.Resources.underline_icon_color_24;
            this.cbCommonUnderline.Location = new System.Drawing.Point(370, 31);
            this.cbCommonUnderline.Name = "cbCommonUnderline";
            this.cbCommonUnderline.Size = new System.Drawing.Size(30, 30);
            this.cbCommonUnderline.TabIndex = 24;
            this.cbCommonUnderline.UseVisualStyleBackColor = true;
            // 
            // lColor
            // 
            this.lColor.AutoSize = true;
            this.lColor.Location = new System.Drawing.Point(21, 117);
            this.lColor.Name = "lColor";
            this.lColor.Size = new System.Drawing.Size(49, 18);
            this.lColor.TabIndex = 12;
            this.lColor.Text = "Color:";
            // 
            // cbCommonItalic
            // 
            this.cbCommonItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbCommonItalic.AutoSize = true;
            this.cbCommonItalic.FlatAppearance.BorderSize = 0;
            this.cbCommonItalic.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(213)))), ((int)(((byte)(242)))));
            this.cbCommonItalic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbCommonItalic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbCommonItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCommonItalic.Image = global::emira.Properties.Resources.italic_icon_color_24;
            this.cbCommonItalic.Location = new System.Drawing.Point(340, 31);
            this.cbCommonItalic.Name = "cbCommonItalic";
            this.cbCommonItalic.Size = new System.Drawing.Size(30, 30);
            this.cbCommonItalic.TabIndex = 23;
            this.cbCommonItalic.UseVisualStyleBackColor = true;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(71, 75);
            this.tbTitle.MaxLength = 150;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(556, 24);
            this.tbTitle.TabIndex = 11;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // cbCommonBold
            // 
            this.cbCommonBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbCommonBold.AutoSize = true;
            this.cbCommonBold.FlatAppearance.BorderSize = 0;
            this.cbCommonBold.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(213)))), ((int)(((byte)(242)))));
            this.cbCommonBold.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbCommonBold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.cbCommonBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCommonBold.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCommonBold.Image = global::emira.Properties.Resources.bold_icon_color_24;
            this.cbCommonBold.Location = new System.Drawing.Point(310, 31);
            this.cbCommonBold.Name = "cbCommonBold";
            this.cbCommonBold.Size = new System.Drawing.Size(30, 30);
            this.cbCommonBold.TabIndex = 22;
            this.cbCommonBold.UseVisualStyleBackColor = true;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(21, 78);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(39, 18);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Title:";
            // 
            // cbCommonFont
            // 
            this.cbCommonFont.FormattingEnabled = true;
            this.cbCommonFont.Location = new System.Drawing.Point(24, 33);
            this.cbCommonFont.Name = "cbCommonFont";
            this.cbCommonFont.Size = new System.Drawing.Size(220, 26);
            this.cbCommonFont.TabIndex = 21;
            // 
            // cbCommonSize
            // 
            this.cbCommonSize.FormattingEnabled = true;
            this.cbCommonSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.cbCommonSize.Location = new System.Drawing.Point(245, 33);
            this.cbCommonSize.Name = "cbCommonSize";
            this.cbCommonSize.Size = new System.Drawing.Size(60, 26);
            this.cbCommonSize.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Location = new System.Drawing.Point(381, 493);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(128, 493);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 40);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // StatisticsSettingsPage
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(670, 560);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbCommon);
            this.Controls.Add(this.gbAxes);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticsSettingsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StatisticsSettingsPage";
            this.Load += new System.EventHandler(this.StatisticsSettingsPage_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gbAxes.ResumeLayout(false);
            this.gbAxes.PerformLayout();
            this.gbCommon.ResumeLayout(false);
            this.gbCommon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label lChartSettings;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lAxisTitle;
        private System.Windows.Forms.Label lTextAlignment;
        private System.Windows.Forms.Label lTextOrientation;
        private System.Windows.Forms.GroupBox gbAxes;
        private System.Windows.Forms.ComboBox cbAxisYTextAlignment;
        private System.Windows.Forms.ComboBox cbAxisXTextAlignment;
        private System.Windows.Forms.TextBox tbAxisYTitle;
        private System.Windows.Forms.TextBox tbAxisXTitle;
        private System.Windows.Forms.ComboBox cbAxisYTextOrientation;
        private System.Windows.Forms.ComboBox cbAxisXTextOrientation;
        private System.Windows.Forms.GroupBox gbCommon;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Label lColor;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbAxisBold;
        private System.Windows.Forms.ComboBox cbAxisFont;
        private System.Windows.Forms.ComboBox cbAxisSize;
        private System.Windows.Forms.CheckBox cbAxisUnderline;
        private System.Windows.Forms.CheckBox cbAxisItalic;
        private System.Windows.Forms.Button btnAxisTextColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnCommonTextColor;
        private System.Windows.Forms.CheckBox cbCommonUnderline;
        private System.Windows.Forms.CheckBox cbCommonItalic;
        private System.Windows.Forms.CheckBox cbCommonBold;
        private System.Windows.Forms.ComboBox cbCommonFont;
        private System.Windows.Forms.ComboBox cbCommonSize;
    }
}