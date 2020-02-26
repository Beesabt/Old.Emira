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
            this.gbAxis = new System.Windows.Forms.GroupBox();
            this.cbAxisYTextOrientation = new System.Windows.Forms.ComboBox();
            this.cbAxisXTextOrientation = new System.Windows.Forms.ComboBox();
            this.cbAxisYTextAlignment = new System.Windows.Forms.ComboBox();
            this.cbAxisXTextAlignment = new System.Windows.Forms.ComboBox();
            this.tbAxisYTitle = new System.Windows.Forms.TextBox();
            this.tbAxisXTitle = new System.Windows.Forms.TextBox();
            this.gbCommon = new System.Windows.Forms.GroupBox();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.lColor = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.lTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pHeader.SuspendLayout();
            this.gbAxis.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(140, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Axis X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(401, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Axis Y";
            // 
            // lAxisTitle
            // 
            this.lAxisTitle.AutoSize = true;
            this.lAxisTitle.Location = new System.Drawing.Point(18, 55);
            this.lAxisTitle.Name = "lAxisTitle";
            this.lAxisTitle.Size = new System.Drawing.Size(70, 18);
            this.lAxisTitle.TabIndex = 4;
            this.lAxisTitle.Text = "Axis Titel:";
            // 
            // lTextAlignment
            // 
            this.lTextAlignment.AutoSize = true;
            this.lTextAlignment.Location = new System.Drawing.Point(18, 103);
            this.lTextAlignment.Name = "lTextAlignment";
            this.lTextAlignment.Size = new System.Drawing.Size(108, 18);
            this.lTextAlignment.TabIndex = 5;
            this.lTextAlignment.Text = "Text Alignment:";
            // 
            // lTextOrientation
            // 
            this.lTextOrientation.AutoSize = true;
            this.lTextOrientation.Location = new System.Drawing.Point(18, 148);
            this.lTextOrientation.Name = "lTextOrientation";
            this.lTextOrientation.Size = new System.Drawing.Size(116, 18);
            this.lTextOrientation.TabIndex = 6;
            this.lTextOrientation.Text = "Text Orientation:";
            // 
            // gbAxis
            // 
            this.gbAxis.Controls.Add(this.cbAxisYTextOrientation);
            this.gbAxis.Controls.Add(this.cbAxisXTextOrientation);
            this.gbAxis.Controls.Add(this.cbAxisYTextAlignment);
            this.gbAxis.Controls.Add(this.cbAxisXTextAlignment);
            this.gbAxis.Controls.Add(this.tbAxisYTitle);
            this.gbAxis.Controls.Add(this.lTextOrientation);
            this.gbAxis.Controls.Add(this.tbAxisXTitle);
            this.gbAxis.Controls.Add(this.lTextAlignment);
            this.gbAxis.Controls.Add(this.label1);
            this.gbAxis.Controls.Add(this.label2);
            this.gbAxis.Controls.Add(this.lAxisTitle);
            this.gbAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbAxis.Location = new System.Drawing.Point(12, 174);
            this.gbAxis.Name = "gbAxis";
            this.gbAxis.Size = new System.Drawing.Size(646, 193);
            this.gbAxis.TabIndex = 7;
            this.gbAxis.TabStop = false;
            this.gbAxis.Text = "Axis";
            // 
            // cbAxisYTextOrientation
            // 
            this.cbAxisYTextOrientation.FormattingEnabled = true;
            this.cbAxisYTextOrientation.Location = new System.Drawing.Point(404, 141);
            this.cbAxisYTextOrientation.Name = "cbAxisYTextOrientation";
            this.cbAxisYTextOrientation.Size = new System.Drawing.Size(220, 26);
            this.cbAxisYTextOrientation.TabIndex = 10;
            this.cbAxisYTextOrientation.SelectedIndexChanged += new System.EventHandler(this.cbAxisYTextOrientation_SelectedIndexChanged);
            this.cbAxisYTextOrientation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAxisYTextOrientation_KeyPress);
            // 
            // cbAxisXTextOrientation
            // 
            this.cbAxisXTextOrientation.FormattingEnabled = true;
            this.cbAxisXTextOrientation.Location = new System.Drawing.Point(143, 141);
            this.cbAxisXTextOrientation.Name = "cbAxisXTextOrientation";
            this.cbAxisXTextOrientation.Size = new System.Drawing.Size(220, 26);
            this.cbAxisXTextOrientation.TabIndex = 9;
            this.cbAxisXTextOrientation.SelectedIndexChanged += new System.EventHandler(this.cbAxisXTextOrientation_SelectedIndexChanged);
            this.cbAxisXTextOrientation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAxisXTextOrientation_KeyPress);
            // 
            // cbAxisYTextAlignment
            // 
            this.cbAxisYTextAlignment.FormattingEnabled = true;
            this.cbAxisYTextAlignment.Location = new System.Drawing.Point(404, 95);
            this.cbAxisYTextAlignment.Name = "cbAxisYTextAlignment";
            this.cbAxisYTextAlignment.Size = new System.Drawing.Size(220, 26);
            this.cbAxisYTextAlignment.TabIndex = 8;
            this.cbAxisYTextAlignment.SelectedIndexChanged += new System.EventHandler(this.cbAxisYTextAlignment_SelectedIndexChanged);
            this.cbAxisYTextAlignment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAxisYTextAlignment_KeyPress);
            // 
            // cbAxisXTextAlignment
            // 
            this.cbAxisXTextAlignment.FormattingEnabled = true;
            this.cbAxisXTextAlignment.Location = new System.Drawing.Point(143, 95);
            this.cbAxisXTextAlignment.Name = "cbAxisXTextAlignment";
            this.cbAxisXTextAlignment.Size = new System.Drawing.Size(220, 26);
            this.cbAxisXTextAlignment.TabIndex = 7;
            this.cbAxisXTextAlignment.SelectedIndexChanged += new System.EventHandler(this.cbAxisXTextAlignment_SelectedIndexChanged);
            this.cbAxisXTextAlignment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAxisXTextAlignment_KeyPress);
            // 
            // tbAxisYTitle
            // 
            this.tbAxisYTitle.Location = new System.Drawing.Point(404, 54);
            this.tbAxisYTitle.MaxLength = 100;
            this.tbAxisYTitle.Name = "tbAxisYTitle";
            this.tbAxisYTitle.Size = new System.Drawing.Size(220, 24);
            this.tbAxisYTitle.TabIndex = 6;
            this.tbAxisYTitle.TextChanged += new System.EventHandler(this.tbAxisYTitle_TextChanged);
            // 
            // tbAxisXTitle
            // 
            this.tbAxisXTitle.Location = new System.Drawing.Point(143, 54);
            this.tbAxisXTitle.MaxLength = 100;
            this.tbAxisXTitle.Name = "tbAxisXTitle";
            this.tbAxisXTitle.Size = new System.Drawing.Size(220, 24);
            this.tbAxisXTitle.TabIndex = 5;
            this.tbAxisXTitle.TextChanged += new System.EventHandler(this.tbAxisXTitle_TextChanged);
            // 
            // gbCommon
            // 
            this.gbCommon.Controls.Add(this.cbColor);
            this.gbCommon.Controls.Add(this.lColor);
            this.gbCommon.Controls.Add(this.tbTitle);
            this.gbCommon.Controls.Add(this.lTitle);
            this.gbCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbCommon.Location = new System.Drawing.Point(12, 53);
            this.gbCommon.Name = "gbCommon";
            this.gbCommon.Size = new System.Drawing.Size(646, 100);
            this.gbCommon.TabIndex = 11;
            this.gbCommon.TabStop = false;
            this.gbCommon.Text = "Common";
            // 
            // cbColor
            // 
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Location = new System.Drawing.Point(71, 63);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(211, 26);
            this.cbColor.TabIndex = 11;
            this.cbColor.SelectedIndexChanged += new System.EventHandler(this.cbColor_SelectedIndexChanged);
            this.cbColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbColor_KeyPress);
            // 
            // lColor
            // 
            this.lColor.AutoSize = true;
            this.lColor.Location = new System.Drawing.Point(21, 71);
            this.lColor.Name = "lColor";
            this.lColor.Size = new System.Drawing.Size(49, 18);
            this.lColor.TabIndex = 12;
            this.lColor.Text = "Color:";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(71, 29);
            this.tbTitle.MaxLength = 150;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(526, 24);
            this.tbTitle.TabIndex = 11;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Location = new System.Drawing.Point(21, 32);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(39, 18);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Title:";
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
            this.Controls.Add(this.gbAxis);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatisticsSettingsPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StatisticsSettingsPage";
            this.Load += new System.EventHandler(this.StatisticsSettingsPage_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gbAxis.ResumeLayout(false);
            this.gbAxis.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbAxis;
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
    }
}