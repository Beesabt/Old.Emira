namespace emira.GUI
{
    partial class PersonalDataChangePage
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
            this.lDataChange = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbPersonalInformation = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.lGender = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.gbCompanyRelatedInformation = new System.Windows.Forms.GroupBox();
            this.nupWorkingHours = new System.Windows.Forms.NumericUpDown();
            this.lWorkingHours = new System.Windows.Forms.Label();
            this.tbRegisterNumber = new System.Windows.Forms.TextBox();
            this.lRegisterNumber = new System.Windows.Forms.Label();
            this.tbPosition = new System.Windows.Forms.TextBox();
            this.tbCostCenter = new System.Windows.Forms.TextBox();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.lPosition = new System.Windows.Forms.Label();
            this.lCostCenter = new System.Windows.Forms.Label();
            this.lCompany = new System.Windows.Forms.Label();
            this.gbHolidayRelatedInformation = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbYesNo = new System.Windows.Forms.RadioButton();
            this.rbYesChild = new System.Windows.Forms.RadioButton();
            this.lDoYouHaveChild = new System.Windows.Forms.Label();
            this.nupNumberOfNewBornBabies = new System.Windows.Forms.NumericUpDown();
            this.lNumberOfNewBornBabies = new System.Windows.Forms.Label();
            this.nupNumberOfDisabledChildren = new System.Windows.Forms.NumericUpDown();
            this.nupNumberOfChildren = new System.Windows.Forms.NumericUpDown();
            this.dtpDateOfStart = new System.Windows.Forms.DateTimePicker();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lNumberOfDisabledChildren = new System.Windows.Forms.Label();
            this.lNumberOfChildren = new System.Windows.Forms.Label();
            this.lDateOfStart = new System.Windows.Forms.Label();
            this.lDateOfBirth = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.lHealthDamage = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.pHeader.SuspendLayout();
            this.gbPersonalInformation.SuspendLayout();
            this.gbCompanyRelatedInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupWorkingHours)).BeginInit();
            this.gbHolidayRelatedInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupNumberOfNewBornBabies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNumberOfDisabledChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNumberOfChildren)).BeginInit();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(184)))));
            this.pHeader.Controls.Add(this.lDataChange);
            this.pHeader.Controls.Add(this.btnExit);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(680, 30);
            this.pHeader.TabIndex = 0;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // lDataChange
            // 
            this.lDataChange.AutoSize = true;
            this.lDataChange.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDataChange.ForeColor = System.Drawing.Color.White;
            this.lDataChange.Location = new System.Drawing.Point(0, 0);
            this.lDataChange.Name = "lDataChange";
            this.lDataChange.Size = new System.Drawing.Size(134, 30);
            this.lDataChange.TabIndex = 4;
            this.lDataChange.Text = "Data Change";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::emira.Properties.Resources.close_icon_white_26;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(630, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 30);
            this.btnExit.TabIndex = 3;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gbPersonalInformation
            // 
            this.gbPersonalInformation.Controls.Add(this.rbFemale);
            this.gbPersonalInformation.Controls.Add(this.rbMale);
            this.gbPersonalInformation.Controls.Add(this.lGender);
            this.gbPersonalInformation.Controls.Add(this.tbName);
            this.gbPersonalInformation.Controls.Add(this.lName);
            this.gbPersonalInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbPersonalInformation.Location = new System.Drawing.Point(30, 54);
            this.gbPersonalInformation.Name = "gbPersonalInformation";
            this.gbPersonalInformation.Size = new System.Drawing.Size(620, 114);
            this.gbPersonalInformation.TabIndex = 1;
            this.gbPersonalInformation.TabStop = false;
            this.gbPersonalInformation.Text = "Personal Information";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.Location = new System.Drawing.Point(222, 77);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(75, 24);
            this.rbFemale.TabIndex = 9;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.Location = new System.Drawing.Point(130, 77);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(60, 24);
            this.rbMale.TabIndex = 8;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // lGender
            // 
            this.lGender.AutoSize = true;
            this.lGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lGender.Location = new System.Drawing.Point(27, 81);
            this.lGender.Name = "lGender";
            this.lGender.Size = new System.Drawing.Size(60, 20);
            this.lGender.TabIndex = 7;
            this.lGender.Text = "Gender:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(99, 37);
            this.tbName.MaxLength = 800;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(511, 27);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lName.Location = new System.Drawing.Point(27, 37);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(52, 20);
            this.lName.TabIndex = 3;
            this.lName.Text = "Name:";
            // 
            // gbCompanyRelatedInformation
            // 
            this.gbCompanyRelatedInformation.Controls.Add(this.nupWorkingHours);
            this.gbCompanyRelatedInformation.Controls.Add(this.lWorkingHours);
            this.gbCompanyRelatedInformation.Controls.Add(this.tbRegisterNumber);
            this.gbCompanyRelatedInformation.Controls.Add(this.lRegisterNumber);
            this.gbCompanyRelatedInformation.Controls.Add(this.tbPosition);
            this.gbCompanyRelatedInformation.Controls.Add(this.tbCostCenter);
            this.gbCompanyRelatedInformation.Controls.Add(this.tbCompany);
            this.gbCompanyRelatedInformation.Controls.Add(this.lPosition);
            this.gbCompanyRelatedInformation.Controls.Add(this.lCostCenter);
            this.gbCompanyRelatedInformation.Controls.Add(this.lCompany);
            this.gbCompanyRelatedInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbCompanyRelatedInformation.Location = new System.Drawing.Point(30, 174);
            this.gbCompanyRelatedInformation.Name = "gbCompanyRelatedInformation";
            this.gbCompanyRelatedInformation.Size = new System.Drawing.Size(620, 229);
            this.gbCompanyRelatedInformation.TabIndex = 2;
            this.gbCompanyRelatedInformation.TabStop = false;
            this.gbCompanyRelatedInformation.Text = "Company Related Information";
            // 
            // nupWorkingHours
            // 
            this.nupWorkingHours.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupWorkingHours.Location = new System.Drawing.Point(161, 177);
            this.nupWorkingHours.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nupWorkingHours.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nupWorkingHours.Name = "nupWorkingHours";
            this.nupWorkingHours.Size = new System.Drawing.Size(70, 27);
            this.nupWorkingHours.TabIndex = 28;
            this.nupWorkingHours.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nupWorkingHours.ValueChanged += new System.EventHandler(this.nupWorkingHours_ValueChanged);
            // 
            // lWorkingHours
            // 
            this.lWorkingHours.AutoSize = true;
            this.lWorkingHours.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lWorkingHours.Location = new System.Drawing.Point(27, 184);
            this.lWorkingHours.Name = "lWorkingHours";
            this.lWorkingHours.Size = new System.Drawing.Size(107, 20);
            this.lWorkingHours.TabIndex = 18;
            this.lWorkingHours.Text = "Working hours:";
            // 
            // tbRegisterNumber
            // 
            this.tbRegisterNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRegisterNumber.Location = new System.Drawing.Point(161, 38);
            this.tbRegisterNumber.MaxLength = 100;
            this.tbRegisterNumber.Name = "tbRegisterNumber";
            this.tbRegisterNumber.Size = new System.Drawing.Size(449, 27);
            this.tbRegisterNumber.TabIndex = 16;
            this.tbRegisterNumber.TextChanged += new System.EventHandler(this.tbRegisterNumber_TextChanged);
            // 
            // lRegisterNumber
            // 
            this.lRegisterNumber.AutoSize = true;
            this.lRegisterNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRegisterNumber.Location = new System.Drawing.Point(27, 41);
            this.lRegisterNumber.Name = "lRegisterNumber";
            this.lRegisterNumber.Size = new System.Drawing.Size(121, 20);
            this.lRegisterNumber.TabIndex = 15;
            this.lRegisterNumber.Text = "Register number:";
            // 
            // tbPosition
            // 
            this.tbPosition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosition.Location = new System.Drawing.Point(161, 143);
            this.tbPosition.MaxLength = 2000;
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(449, 27);
            this.tbPosition.TabIndex = 14;
            this.tbPosition.TextChanged += new System.EventHandler(this.tbPosition_TextChanged);
            // 
            // tbCostCenter
            // 
            this.tbCostCenter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCostCenter.Location = new System.Drawing.Point(161, 108);
            this.tbCostCenter.MaxLength = 2000;
            this.tbCostCenter.Name = "tbCostCenter";
            this.tbCostCenter.Size = new System.Drawing.Size(449, 27);
            this.tbCostCenter.TabIndex = 13;
            this.tbCostCenter.TextChanged += new System.EventHandler(this.tbCostCenter_TextChanged);
            // 
            // tbCompany
            // 
            this.tbCompany.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompany.Location = new System.Drawing.Point(161, 73);
            this.tbCompany.MaxLength = 2000;
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(449, 27);
            this.tbCompany.TabIndex = 10;
            this.tbCompany.TextChanged += new System.EventHandler(this.tbCompany_TextChanged);
            // 
            // lPosition
            // 
            this.lPosition.AutoSize = true;
            this.lPosition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPosition.Location = new System.Drawing.Point(27, 146);
            this.lPosition.Name = "lPosition";
            this.lPosition.Size = new System.Drawing.Size(64, 20);
            this.lPosition.TabIndex = 12;
            this.lPosition.Text = "Position:";
            // 
            // lCostCenter
            // 
            this.lCostCenter.AutoSize = true;
            this.lCostCenter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCostCenter.Location = new System.Drawing.Point(27, 111);
            this.lCostCenter.Name = "lCostCenter";
            this.lCostCenter.Size = new System.Drawing.Size(86, 20);
            this.lCostCenter.TabIndex = 11;
            this.lCostCenter.Text = "Cost center:";
            // 
            // lCompany
            // 
            this.lCompany.AutoSize = true;
            this.lCompany.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCompany.Location = new System.Drawing.Point(27, 76);
            this.lCompany.Name = "lCompany";
            this.lCompany.Size = new System.Drawing.Size(75, 20);
            this.lCompany.TabIndex = 10;
            this.lCompany.Text = "Company:";
            // 
            // gbHolidayRelatedInformation
            // 
            this.gbHolidayRelatedInformation.Controls.Add(this.radioButton4);
            this.gbHolidayRelatedInformation.Controls.Add(this.radioButton3);
            this.gbHolidayRelatedInformation.Controls.Add(this.lHealthDamage);
            this.gbHolidayRelatedInformation.Controls.Add(this.radioButton2);
            this.gbHolidayRelatedInformation.Controls.Add(this.radioButton1);
            this.gbHolidayRelatedInformation.Controls.Add(this.label1);
            this.gbHolidayRelatedInformation.Controls.Add(this.rbYesNo);
            this.gbHolidayRelatedInformation.Controls.Add(this.rbYesChild);
            this.gbHolidayRelatedInformation.Controls.Add(this.lDoYouHaveChild);
            this.gbHolidayRelatedInformation.Controls.Add(this.nupNumberOfNewBornBabies);
            this.gbHolidayRelatedInformation.Controls.Add(this.lNumberOfNewBornBabies);
            this.gbHolidayRelatedInformation.Controls.Add(this.nupNumberOfDisabledChildren);
            this.gbHolidayRelatedInformation.Controls.Add(this.nupNumberOfChildren);
            this.gbHolidayRelatedInformation.Controls.Add(this.dtpDateOfStart);
            this.gbHolidayRelatedInformation.Controls.Add(this.dtpDateOfBirth);
            this.gbHolidayRelatedInformation.Controls.Add(this.lNumberOfDisabledChildren);
            this.gbHolidayRelatedInformation.Controls.Add(this.lNumberOfChildren);
            this.gbHolidayRelatedInformation.Controls.Add(this.lDateOfStart);
            this.gbHolidayRelatedInformation.Controls.Add(this.lDateOfBirth);
            this.gbHolidayRelatedInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbHolidayRelatedInformation.Location = new System.Drawing.Point(30, 409);
            this.gbHolidayRelatedInformation.Name = "gbHolidayRelatedInformation";
            this.gbHolidayRelatedInformation.Size = new System.Drawing.Size(620, 329);
            this.gbHolidayRelatedInformation.TabIndex = 2;
            this.gbHolidayRelatedInformation.TabStop = false;
            this.gbHolidayRelatedInformation.Text = "Holiday Related Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(28, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Do you have disabled child?";
            // 
            // rbYesNo
            // 
            this.rbYesNo.AutoSize = true;
            this.rbYesNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbYesNo.Location = new System.Drawing.Point(222, 86);
            this.rbYesNo.Name = "rbYesNo";
            this.rbYesNo.Size = new System.Drawing.Size(47, 24);
            this.rbYesNo.TabIndex = 30;
            this.rbYesNo.TabStop = true;
            this.rbYesNo.Text = "No";
            this.rbYesNo.UseVisualStyleBackColor = true;
            // 
            // rbYesChild
            // 
            this.rbYesChild.AutoSize = true;
            this.rbYesChild.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbYesChild.Location = new System.Drawing.Point(292, 86);
            this.rbYesChild.Name = "rbYesChild";
            this.rbYesChild.Size = new System.Drawing.Size(48, 24);
            this.rbYesChild.TabIndex = 29;
            this.rbYesChild.TabStop = true;
            this.rbYesChild.Text = "Yes";
            this.rbYesChild.UseVisualStyleBackColor = true;
            // 
            // lDoYouHaveChild
            // 
            this.lDoYouHaveChild.AutoSize = true;
            this.lDoYouHaveChild.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDoYouHaveChild.Location = new System.Drawing.Point(27, 88);
            this.lDoYouHaveChild.Name = "lDoYouHaveChild";
            this.lDoYouHaveChild.Size = new System.Drawing.Size(147, 20);
            this.lDoYouHaveChild.TabIndex = 28;
            this.lDoYouHaveChild.Text = "Do you have a child?";
            // 
            // nupNumberOfNewBornBabies
            // 
            this.nupNumberOfNewBornBabies.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupNumberOfNewBornBabies.Location = new System.Drawing.Point(227, 241);
            this.nupNumberOfNewBornBabies.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupNumberOfNewBornBabies.Name = "nupNumberOfNewBornBabies";
            this.nupNumberOfNewBornBabies.Size = new System.Drawing.Size(70, 27);
            this.nupNumberOfNewBornBabies.TabIndex = 27;
            this.nupNumberOfNewBornBabies.ValueChanged += new System.EventHandler(this.nupNumberOfNewBornBabies_ValueChanged);
            // 
            // lNumberOfNewBornBabies
            // 
            this.lNumberOfNewBornBabies.AutoSize = true;
            this.lNumberOfNewBornBabies.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfNewBornBabies.Location = new System.Drawing.Point(28, 243);
            this.lNumberOfNewBornBabies.Name = "lNumberOfNewBornBabies";
            this.lNumberOfNewBornBabies.Size = new System.Drawing.Size(198, 20);
            this.lNumberOfNewBornBabies.TabIndex = 26;
            this.lNumberOfNewBornBabies.Text = "Number of new born babies:";
            // 
            // nupNumberOfDisabledChildren
            // 
            this.nupNumberOfDisabledChildren.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupNumberOfDisabledChildren.Location = new System.Drawing.Point(298, 200);
            this.nupNumberOfDisabledChildren.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupNumberOfDisabledChildren.Name = "nupNumberOfDisabledChildren";
            this.nupNumberOfDisabledChildren.Size = new System.Drawing.Size(70, 27);
            this.nupNumberOfDisabledChildren.TabIndex = 25;
            this.nupNumberOfDisabledChildren.ValueChanged += new System.EventHandler(this.nupNumberOfDisabledChildren_ValueChanged);
            // 
            // nupNumberOfChildren
            // 
            this.nupNumberOfChildren.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupNumberOfChildren.Location = new System.Drawing.Point(237, 124);
            this.nupNumberOfChildren.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupNumberOfChildren.Name = "nupNumberOfChildren";
            this.nupNumberOfChildren.Size = new System.Drawing.Size(70, 27);
            this.nupNumberOfChildren.TabIndex = 24;
            this.nupNumberOfChildren.ValueChanged += new System.EventHandler(this.nupNumberOfChildren_ValueChanged);
            // 
            // dtpDateOfStart
            // 
            this.dtpDateOfStart.CustomFormat = "yyyy. hh. nn.";
            this.dtpDateOfStart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDateOfStart.Location = new System.Drawing.Point(430, 31);
            this.dtpDateOfStart.Name = "dtpDateOfStart";
            this.dtpDateOfStart.Size = new System.Drawing.Size(167, 27);
            this.dtpDateOfStart.TabIndex = 23;
            this.dtpDateOfStart.ValueChanged += new System.EventHandler(this.dtpDateOfStart_ValueChanged);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "yyyy. hh. nn.";
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDateOfBirth.Location = new System.Drawing.Point(130, 31);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(167, 27);
            this.dtpDateOfBirth.TabIndex = 22;
            this.dtpDateOfBirth.ValueChanged += new System.EventHandler(this.dtpDateOfBirth_ValueChanged);
            // 
            // lNumberOfDisabledChildren
            // 
            this.lNumberOfDisabledChildren.AutoSize = true;
            this.lNumberOfDisabledChildren.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfDisabledChildren.Location = new System.Drawing.Point(28, 202);
            this.lNumberOfDisabledChildren.Name = "lNumberOfDisabledChildren";
            this.lNumberOfDisabledChildren.Size = new System.Drawing.Size(264, 20);
            this.lNumberOfDisabledChildren.TabIndex = 18;
            this.lNumberOfDisabledChildren.Text = "Number of disabled children under 16:";
            // 
            // lNumberOfChildren
            // 
            this.lNumberOfChildren.AutoSize = true;
            this.lNumberOfChildren.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfChildren.Location = new System.Drawing.Point(28, 126);
            this.lNumberOfChildren.Name = "lNumberOfChildren";
            this.lNumberOfChildren.Size = new System.Drawing.Size(203, 20);
            this.lNumberOfChildren.TabIndex = 17;
            this.lNumberOfChildren.Text = "Number of children under 16:";
            // 
            // lDateOfStart
            // 
            this.lDateOfStart.AutoSize = true;
            this.lDateOfStart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDateOfStart.Location = new System.Drawing.Point(329, 35);
            this.lDateOfStart.Name = "lDateOfStart";
            this.lDateOfStart.Size = new System.Drawing.Size(95, 20);
            this.lDateOfStart.TabIndex = 16;
            this.lDateOfStart.Text = "Date of start:";
            // 
            // lDateOfBirth
            // 
            this.lDateOfBirth.AutoSize = true;
            this.lDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDateOfBirth.Location = new System.Drawing.Point(27, 35);
            this.lDateOfBirth.Name = "lDateOfBirth";
            this.lDateOfBirth.Size = new System.Drawing.Size(97, 20);
            this.lDateOfBirth.TabIndex = 15;
            this.lDateOfBirth.Text = "Date of birth:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(129, 762);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Location = new System.Drawing.Point(363, 762);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(260, 162);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 24);
            this.radioButton1.TabIndex = 32;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "No";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(313, 162);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 24);
            this.radioButton2.TabIndex = 33;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Yes";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // lHealthDamage
            // 
            this.lHealthDamage.AutoSize = true;
            this.lHealthDamage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lHealthDamage.Location = new System.Drawing.Point(28, 285);
            this.lHealthDamage.Name = "lHealthDamage";
            this.lHealthDamage.Size = new System.Drawing.Size(235, 20);
            this.lHealthDamage.TabIndex = 34;
            this.lHealthDamage.Text = "Do you have 50% health damage?";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(293, 283);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 24);
            this.radioButton3.TabIndex = 35;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "No";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton4.Location = new System.Drawing.Point(353, 283);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(48, 24);
            this.radioButton4.TabIndex = 36;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Yes";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // PersonalDataChangePage
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(680, 845);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbHolidayRelatedInformation);
            this.Controls.Add(this.gbCompanyRelatedInformation);
            this.Controls.Add(this.gbPersonalInformation);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PersonalDataChangePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DataChangePage";
            this.Load += new System.EventHandler(this.DataChangePage_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.gbPersonalInformation.ResumeLayout(false);
            this.gbPersonalInformation.PerformLayout();
            this.gbCompanyRelatedInformation.ResumeLayout(false);
            this.gbCompanyRelatedInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupWorkingHours)).EndInit();
            this.gbHolidayRelatedInformation.ResumeLayout(false);
            this.gbHolidayRelatedInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupNumberOfNewBornBabies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNumberOfDisabledChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupNumberOfChildren)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.GroupBox gbPersonalInformation;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label lGender;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.GroupBox gbCompanyRelatedInformation;
        private System.Windows.Forms.TextBox tbPosition;
        private System.Windows.Forms.TextBox tbCostCenter;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label lPosition;
        private System.Windows.Forms.Label lCostCenter;
        private System.Windows.Forms.Label lCompany;
        private System.Windows.Forms.GroupBox gbHolidayRelatedInformation;
        private System.Windows.Forms.NumericUpDown nupNumberOfDisabledChildren;
        private System.Windows.Forms.NumericUpDown nupNumberOfChildren;
        private System.Windows.Forms.DateTimePicker dtpDateOfStart;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lNumberOfDisabledChildren;
        private System.Windows.Forms.Label lNumberOfChildren;
        private System.Windows.Forms.Label lDateOfStart;
        private System.Windows.Forms.Label lDateOfBirth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lDataChange;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tbRegisterNumber;
        private System.Windows.Forms.Label lRegisterNumber;
        private System.Windows.Forms.NumericUpDown nupNumberOfNewBornBabies;
        private System.Windows.Forms.Label lNumberOfNewBornBabies;
        private System.Windows.Forms.NumericUpDown nupWorkingHours;
        private System.Windows.Forms.Label lWorkingHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbYesNo;
        private System.Windows.Forms.RadioButton rbYesChild;
        private System.Windows.Forms.Label lDoYouHaveChild;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label lHealthDamage;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}