namespace emira.GUI
{
    partial class PersonalDataChangeForm
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
            this.nupExtraHoliday = new System.Windows.Forms.NumericUpDown();
            this.lExtraHoliday = new System.Windows.Forms.Label();
            this.nupHolidaysLeft = new System.Windows.Forms.NumericUpDown();
            this.lHolidaysLeft = new System.Windows.Forms.Label();
            this.cbYesHealthDamage = new System.Windows.Forms.CheckBox();
            this.cbNoHealthDamage = new System.Windows.Forms.CheckBox();
            this.cbYesDisabledChild = new System.Windows.Forms.CheckBox();
            this.cbNoDisabledChild = new System.Windows.Forms.CheckBox();
            this.cbYesChild = new System.Windows.Forms.CheckBox();
            this.cbNoChild = new System.Windows.Forms.CheckBox();
            this.lHealthDamage = new System.Windows.Forms.Label();
            this.lDoYouHaveDiasabledChild = new System.Windows.Forms.Label();
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
            this.pHeader.SuspendLayout();
            this.gbPersonalInformation.SuspendLayout();
            this.gbCompanyRelatedInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupWorkingHours)).BeginInit();
            this.gbHolidayRelatedInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupExtraHoliday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHolidaysLeft)).BeginInit();
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
            this.pHeader.Size = new System.Drawing.Size(670, 30);
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
            this.lDataChange.Size = new System.Drawing.Size(158, 30);
            this.lDataChange.TabIndex = 4;
            this.lDataChange.Text = "Adat módosítás";
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
            this.gbPersonalInformation.Size = new System.Drawing.Size(610, 115);
            this.gbPersonalInformation.TabIndex = 1;
            this.gbPersonalInformation.TabStop = false;
            this.gbPersonalInformation.Text = "Személyes adatok";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.Location = new System.Drawing.Point(222, 77);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(47, 24);
            this.rbFemale.TabIndex = 9;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Nő";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.Location = new System.Drawing.Point(130, 77);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(56, 24);
            this.rbMale.TabIndex = 8;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Férfi";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // lGender
            // 
            this.lGender.AutoSize = true;
            this.lGender.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lGender.Location = new System.Drawing.Point(27, 79);
            this.lGender.Name = "lGender";
            this.lGender.Size = new System.Drawing.Size(44, 20);
            this.lGender.TabIndex = 7;
            this.lGender.Text = "Nem:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(99, 35);
            this.tbName.MaxLength = 800;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(475, 27);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lName.Location = new System.Drawing.Point(27, 37);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(38, 20);
            this.lName.TabIndex = 3;
            this.lName.Text = "Név:";
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
            this.gbCompanyRelatedInformation.Size = new System.Drawing.Size(610, 230);
            this.gbCompanyRelatedInformation.TabIndex = 2;
            this.gbCompanyRelatedInformation.TabStop = false;
            this.gbCompanyRelatedInformation.Text = "Céggel kapcsolatos adatok";
            // 
            // nupWorkingHours
            // 
            this.nupWorkingHours.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupWorkingHours.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupWorkingHours.Location = new System.Drawing.Point(161, 181);
            this.nupWorkingHours.Maximum = new decimal(new int[] {
            8,
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
            8,
            0,
            0,
            0});
            this.nupWorkingHours.ValueChanged += new System.EventHandler(this.nupWorkingHours_ValueChanged);
            this.nupWorkingHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupWorkingHours_KeyPress);
            // 
            // lWorkingHours
            // 
            this.lWorkingHours.AutoSize = true;
            this.lWorkingHours.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lWorkingHours.Location = new System.Drawing.Point(27, 183);
            this.lWorkingHours.Name = "lWorkingHours";
            this.lWorkingHours.Size = new System.Drawing.Size(78, 20);
            this.lWorkingHours.TabIndex = 18;
            this.lWorkingHours.Text = "Munkaidő:";
            // 
            // tbRegisterNumber
            // 
            this.tbRegisterNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRegisterNumber.Location = new System.Drawing.Point(161, 38);
            this.tbRegisterNumber.MaxLength = 100;
            this.tbRegisterNumber.Name = "tbRegisterNumber";
            this.tbRegisterNumber.Size = new System.Drawing.Size(413, 27);
            this.tbRegisterNumber.TabIndex = 16;
            this.tbRegisterNumber.TextChanged += new System.EventHandler(this.tbRegisterNumber_TextChanged);
            // 
            // lRegisterNumber
            // 
            this.lRegisterNumber.AutoSize = true;
            this.lRegisterNumber.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRegisterNumber.Location = new System.Drawing.Point(27, 41);
            this.lRegisterNumber.Name = "lRegisterNumber";
            this.lRegisterNumber.Size = new System.Drawing.Size(80, 20);
            this.lRegisterNumber.TabIndex = 15;
            this.lRegisterNumber.Text = "Tőrzsszám:";
            // 
            // tbPosition
            // 
            this.tbPosition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosition.Location = new System.Drawing.Point(161, 140);
            this.tbPosition.MaxLength = 2000;
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(413, 27);
            this.tbPosition.TabIndex = 14;
            this.tbPosition.TextChanged += new System.EventHandler(this.tbPosition_TextChanged);
            // 
            // tbCostCenter
            // 
            this.tbCostCenter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCostCenter.Location = new System.Drawing.Point(161, 106);
            this.tbCostCenter.MaxLength = 2000;
            this.tbCostCenter.Name = "tbCostCenter";
            this.tbCostCenter.Size = new System.Drawing.Size(413, 27);
            this.tbCostCenter.TabIndex = 13;
            this.tbCostCenter.TextChanged += new System.EventHandler(this.tbCostCenter_TextChanged);
            // 
            // tbCompany
            // 
            this.tbCompany.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCompany.Location = new System.Drawing.Point(161, 72);
            this.tbCompany.MaxLength = 2000;
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(413, 27);
            this.tbCompany.TabIndex = 10;
            this.tbCompany.TextChanged += new System.EventHandler(this.tbCompany_TextChanged);
            // 
            // lPosition
            // 
            this.lPosition.AutoSize = true;
            this.lPosition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPosition.Location = new System.Drawing.Point(27, 146);
            this.lPosition.Name = "lPosition";
            this.lPosition.Size = new System.Drawing.Size(59, 20);
            this.lPosition.TabIndex = 12;
            this.lPosition.Text = "Pozíció:";
            // 
            // lCostCenter
            // 
            this.lCostCenter.AutoSize = true;
            this.lCostCenter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCostCenter.Location = new System.Drawing.Point(27, 111);
            this.lCostCenter.Name = "lCostCenter";
            this.lCostCenter.Size = new System.Drawing.Size(89, 20);
            this.lCostCenter.TabIndex = 11;
            this.lCostCenter.Text = "Költséghely:";
            // 
            // lCompany
            // 
            this.lCompany.AutoSize = true;
            this.lCompany.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCompany.Location = new System.Drawing.Point(27, 76);
            this.lCompany.Name = "lCompany";
            this.lCompany.Size = new System.Drawing.Size(73, 20);
            this.lCompany.TabIndex = 10;
            this.lCompany.Text = "Cég neve:";
            // 
            // gbHolidayRelatedInformation
            // 
            this.gbHolidayRelatedInformation.Controls.Add(this.nupExtraHoliday);
            this.gbHolidayRelatedInformation.Controls.Add(this.lExtraHoliday);
            this.gbHolidayRelatedInformation.Controls.Add(this.nupHolidaysLeft);
            this.gbHolidayRelatedInformation.Controls.Add(this.lHolidaysLeft);
            this.gbHolidayRelatedInformation.Controls.Add(this.cbYesHealthDamage);
            this.gbHolidayRelatedInformation.Controls.Add(this.cbNoHealthDamage);
            this.gbHolidayRelatedInformation.Controls.Add(this.cbYesDisabledChild);
            this.gbHolidayRelatedInformation.Controls.Add(this.cbNoDisabledChild);
            this.gbHolidayRelatedInformation.Controls.Add(this.cbYesChild);
            this.gbHolidayRelatedInformation.Controls.Add(this.cbNoChild);
            this.gbHolidayRelatedInformation.Controls.Add(this.lHealthDamage);
            this.gbHolidayRelatedInformation.Controls.Add(this.lDoYouHaveDiasabledChild);
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
            this.gbHolidayRelatedInformation.Size = new System.Drawing.Size(610, 450);
            this.gbHolidayRelatedInformation.TabIndex = 2;
            this.gbHolidayRelatedInformation.TabStop = false;
            this.gbHolidayRelatedInformation.Text = "Szabadsággal kapcsolatos adatok";
            // 
            // nupExtraHoliday
            // 
            this.nupExtraHoliday.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupExtraHoliday.Location = new System.Drawing.Point(334, 402);
            this.nupExtraHoliday.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nupExtraHoliday.Name = "nupExtraHoliday";
            this.nupExtraHoliday.Size = new System.Drawing.Size(70, 27);
            this.nupExtraHoliday.TabIndex = 46;
            this.nupExtraHoliday.ValueChanged += new System.EventHandler(this.nupExtraHoliday_ValueChanged);
            this.nupExtraHoliday.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupExtraHoliday_KeyPress);
            // 
            // lExtraHoliday
            // 
            this.lExtraHoliday.AutoSize = true;
            this.lExtraHoliday.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lExtraHoliday.Location = new System.Drawing.Point(37, 404);
            this.lExtraHoliday.Name = "lExtraHoliday";
            this.lExtraHoliday.Size = new System.Drawing.Size(196, 20);
            this.lExtraHoliday.TabIndex = 45;
            this.lExtraHoliday.Text = "Mennyi pótszabadsága van?";
            // 
            // nupHolidaysLeft
            // 
            this.nupHolidaysLeft.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupHolidaysLeft.Location = new System.Drawing.Point(334, 357);
            this.nupHolidaysLeft.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nupHolidaysLeft.Name = "nupHolidaysLeft";
            this.nupHolidaysLeft.Size = new System.Drawing.Size(70, 27);
            this.nupHolidaysLeft.TabIndex = 44;
            this.nupHolidaysLeft.Visible = false;
            this.nupHolidaysLeft.ValueChanged += new System.EventHandler(this.nupHolidaysLeft_ValueChanged);
            this.nupHolidaysLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupHolidaysLeft_KeyPress);
            // 
            // lHolidaysLeft
            // 
            this.lHolidaysLeft.AutoSize = true;
            this.lHolidaysLeft.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lHolidaysLeft.Location = new System.Drawing.Point(37, 359);
            this.lHolidaysLeft.Name = "lHolidaysLeft";
            this.lHolidaysLeft.Size = new System.Drawing.Size(245, 20);
            this.lHolidaysLeft.TabIndex = 43;
            this.lHolidaysLeft.Text = "Hány szabadsága maradt tavalyról?";
            this.lHolidaysLeft.Visible = false;
            // 
            // cbYesHealthDamage
            // 
            this.cbYesHealthDamage.AutoSize = true;
            this.cbYesHealthDamage.Location = new System.Drawing.Point(334, 314);
            this.cbYesHealthDamage.Name = "cbYesHealthDamage";
            this.cbYesHealthDamage.Size = new System.Drawing.Size(54, 22);
            this.cbYesHealthDamage.TabIndex = 42;
            this.cbYesHealthDamage.Text = "Igen";
            this.cbYesHealthDamage.UseVisualStyleBackColor = true;
            this.cbYesHealthDamage.CheckedChanged += new System.EventHandler(this.cbYesHealthDamage_CheckedChanged);
            // 
            // cbNoHealthDamage
            // 
            this.cbNoHealthDamage.AutoSize = true;
            this.cbNoHealthDamage.Location = new System.Drawing.Point(447, 314);
            this.cbNoHealthDamage.Name = "cbNoHealthDamage";
            this.cbNoHealthDamage.Size = new System.Drawing.Size(59, 22);
            this.cbNoHealthDamage.TabIndex = 41;
            this.cbNoHealthDamage.Text = "Nem";
            this.cbNoHealthDamage.UseVisualStyleBackColor = true;
            this.cbNoHealthDamage.CheckedChanged += new System.EventHandler(this.cbNoHealthDamage_CheckedChanged);
            // 
            // cbYesDisabledChild
            // 
            this.cbYesDisabledChild.AutoSize = true;
            this.cbYesDisabledChild.Location = new System.Drawing.Point(334, 219);
            this.cbYesDisabledChild.Name = "cbYesDisabledChild";
            this.cbYesDisabledChild.Size = new System.Drawing.Size(54, 22);
            this.cbYesDisabledChild.TabIndex = 40;
            this.cbYesDisabledChild.Text = "Igen";
            this.cbYesDisabledChild.UseVisualStyleBackColor = true;
            this.cbYesDisabledChild.Visible = false;
            this.cbYesDisabledChild.CheckedChanged += new System.EventHandler(this.cbYesDisabledChild_CheckedChanged);
            // 
            // cbNoDisabledChild
            // 
            this.cbNoDisabledChild.AutoSize = true;
            this.cbNoDisabledChild.Location = new System.Drawing.Point(447, 219);
            this.cbNoDisabledChild.Name = "cbNoDisabledChild";
            this.cbNoDisabledChild.Size = new System.Drawing.Size(59, 22);
            this.cbNoDisabledChild.TabIndex = 39;
            this.cbNoDisabledChild.Text = "Nem";
            this.cbNoDisabledChild.UseVisualStyleBackColor = true;
            this.cbNoDisabledChild.Visible = false;
            this.cbNoDisabledChild.CheckedChanged += new System.EventHandler(this.cbNoDisabledChild_CheckedChanged);
            // 
            // cbYesChild
            // 
            this.cbYesChild.AutoSize = true;
            this.cbYesChild.Location = new System.Drawing.Point(334, 89);
            this.cbYesChild.Name = "cbYesChild";
            this.cbYesChild.Size = new System.Drawing.Size(54, 22);
            this.cbYesChild.TabIndex = 38;
            this.cbYesChild.Text = "Igen";
            this.cbYesChild.UseVisualStyleBackColor = true;
            this.cbYesChild.CheckedChanged += new System.EventHandler(this.cbYesChild_CheckedChanged);
            // 
            // cbNoChild
            // 
            this.cbNoChild.AutoSize = true;
            this.cbNoChild.Location = new System.Drawing.Point(447, 89);
            this.cbNoChild.Name = "cbNoChild";
            this.cbNoChild.Size = new System.Drawing.Size(59, 22);
            this.cbNoChild.TabIndex = 37;
            this.cbNoChild.Text = "Nem";
            this.cbNoChild.UseVisualStyleBackColor = true;
            this.cbNoChild.CheckedChanged += new System.EventHandler(this.cbNoChild_CheckedChanged);
            // 
            // lHealthDamage
            // 
            this.lHealthDamage.AutoSize = true;
            this.lHealthDamage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lHealthDamage.Location = new System.Drawing.Point(37, 314);
            this.lHealthDamage.Name = "lHealthDamage";
            this.lHealthDamage.Size = new System.Drawing.Size(233, 20);
            this.lHealthDamage.TabIndex = 34;
            this.lHealthDamage.Text = "Van 50%-os egészségkárosodása?";
            // 
            // lDoYouHaveDiasabledChild
            // 
            this.lDoYouHaveDiasabledChild.AutoSize = true;
            this.lDoYouHaveDiasabledChild.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDoYouHaveDiasabledChild.Location = new System.Drawing.Point(37, 219);
            this.lDoYouHaveDiasabledChild.Name = "lDoYouHaveDiasabledChild";
            this.lDoYouHaveDiasabledChild.Size = new System.Drawing.Size(207, 20);
            this.lDoYouHaveDiasabledChild.TabIndex = 31;
            this.lDoYouHaveDiasabledChild.Text = "Van közöttük fogyatékkal élő?";
            this.lDoYouHaveDiasabledChild.Visible = false;
            // 
            // lDoYouHaveChild
            // 
            this.lDoYouHaveChild.AutoSize = true;
            this.lDoYouHaveChild.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDoYouHaveChild.Location = new System.Drawing.Point(37, 89);
            this.lDoYouHaveChild.Name = "lDoYouHaveChild";
            this.lDoYouHaveChild.Size = new System.Drawing.Size(136, 20);
            this.lDoYouHaveChild.TabIndex = 28;
            this.lDoYouHaveChild.Text = "Vannak gyermekei?";
            // 
            // nupNumberOfNewBornBabies
            // 
            this.nupNumberOfNewBornBabies.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupNumberOfNewBornBabies.Location = new System.Drawing.Point(334, 177);
            this.nupNumberOfNewBornBabies.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupNumberOfNewBornBabies.Name = "nupNumberOfNewBornBabies";
            this.nupNumberOfNewBornBabies.Size = new System.Drawing.Size(70, 27);
            this.nupNumberOfNewBornBabies.TabIndex = 27;
            this.nupNumberOfNewBornBabies.Visible = false;
            this.nupNumberOfNewBornBabies.ValueChanged += new System.EventHandler(this.nupNumberOfNewBornBabies_ValueChanged);
            this.nupNumberOfNewBornBabies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupNumberOfNewBornBabies_KeyPress);
            // 
            // lNumberOfNewBornBabies
            // 
            this.lNumberOfNewBornBabies.AutoSize = true;
            this.lNumberOfNewBornBabies.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfNewBornBabies.Location = new System.Drawing.Point(37, 179);
            this.lNumberOfNewBornBabies.Name = "lNumberOfNewBornBabies";
            this.lNumberOfNewBornBabies.Size = new System.Drawing.Size(194, 20);
            this.lNumberOfNewBornBabies.TabIndex = 26;
            this.lNumberOfNewBornBabies.Text = "Közülük hányan újszülöttek?";
            this.lNumberOfNewBornBabies.Visible = false;
            // 
            // nupNumberOfDisabledChildren
            // 
            this.nupNumberOfDisabledChildren.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupNumberOfDisabledChildren.Location = new System.Drawing.Point(334, 260);
            this.nupNumberOfDisabledChildren.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupNumberOfDisabledChildren.Name = "nupNumberOfDisabledChildren";
            this.nupNumberOfDisabledChildren.Size = new System.Drawing.Size(70, 27);
            this.nupNumberOfDisabledChildren.TabIndex = 25;
            this.nupNumberOfDisabledChildren.Visible = false;
            this.nupNumberOfDisabledChildren.ValueChanged += new System.EventHandler(this.nupNumberOfDisabledChildren_ValueChanged);
            this.nupNumberOfDisabledChildren.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupNumberOfDisabledChildren_KeyPress);
            // 
            // nupNumberOfChildren
            // 
            this.nupNumberOfChildren.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupNumberOfChildren.Location = new System.Drawing.Point(334, 132);
            this.nupNumberOfChildren.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupNumberOfChildren.Name = "nupNumberOfChildren";
            this.nupNumberOfChildren.Size = new System.Drawing.Size(70, 27);
            this.nupNumberOfChildren.TabIndex = 24;
            this.nupNumberOfChildren.Visible = false;
            this.nupNumberOfChildren.ValueChanged += new System.EventHandler(this.nupNumberOfChildren_ValueChanged);
            this.nupNumberOfChildren.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupNumberOfChildren_KeyPress);
            // 
            // dtpDateOfStart
            // 
            this.dtpDateOfStart.CustomFormat = "yyyy-MM-dd";
            this.dtpDateOfStart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDateOfStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfStart.Location = new System.Drawing.Point(447, 34);
            this.dtpDateOfStart.MaxDate = new System.DateTime(2219, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfStart.MinDate = new System.DateTime(1909, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfStart.Name = "dtpDateOfStart";
            this.dtpDateOfStart.Size = new System.Drawing.Size(120, 27);
            this.dtpDateOfStart.TabIndex = 23;
            this.dtpDateOfStart.ValueChanged += new System.EventHandler(this.dtpDateOfStart_ValueChanged);
            this.dtpDateOfStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDateOfStart_KeyPress);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "yyyy-MM-dd";
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(162, 34);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(2219, 12, 31, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1909, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(120, 27);
            this.dtpDateOfBirth.TabIndex = 22;
            this.dtpDateOfBirth.ValueChanged += new System.EventHandler(this.dtpDateOfBirth_ValueChanged);
            this.dtpDateOfBirth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDateOfBirth_KeyPress);
            // 
            // lNumberOfDisabledChildren
            // 
            this.lNumberOfDisabledChildren.AutoSize = true;
            this.lNumberOfDisabledChildren.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfDisabledChildren.Location = new System.Drawing.Point(37, 262);
            this.lNumberOfDisabledChildren.Name = "lNumberOfDisabledChildren";
            this.lNumberOfDisabledChildren.Size = new System.Drawing.Size(257, 20);
            this.lNumberOfDisabledChildren.TabIndex = 18;
            this.lNumberOfDisabledChildren.Text = "Közülük hányan 16 évnél fiatalabbak?";
            this.lNumberOfDisabledChildren.Visible = false;
            // 
            // lNumberOfChildren
            // 
            this.lNumberOfChildren.AutoSize = true;
            this.lNumberOfChildren.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNumberOfChildren.Location = new System.Drawing.Point(37, 134);
            this.lNumberOfChildren.Name = "lNumberOfChildren";
            this.lNumberOfChildren.Size = new System.Drawing.Size(257, 20);
            this.lNumberOfChildren.TabIndex = 17;
            this.lNumberOfChildren.Text = "Közülük hányan 16 évnél fiatalabbak?";
            this.lNumberOfChildren.Visible = false;
            // 
            // lDateOfStart
            // 
            this.lDateOfStart.AutoSize = true;
            this.lDateOfStart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDateOfStart.Location = new System.Drawing.Point(330, 39);
            this.lDateOfStart.Name = "lDateOfStart";
            this.lDateOfStart.Size = new System.Drawing.Size(106, 20);
            this.lDateOfStart.TabIndex = 16;
            this.lDateOfStart.Text = "Kezdés dátum:";
            // 
            // lDateOfBirth
            // 
            this.lDateOfBirth.AutoSize = true;
            this.lDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lDateOfBirth.Location = new System.Drawing.Point(37, 39);
            this.lDateOfBirth.Name = "lDateOfBirth";
            this.lDateOfBirth.Size = new System.Drawing.Size(117, 20);
            this.lDateOfBirth.TabIndex = 15;
            this.lDateOfBirth.Text = "Születési dátum:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(127, 880);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Mentés";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(380, 880);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Mégse";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PersonalDataChangeForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(670, 950);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbHolidayRelatedInformation);
            this.Controls.Add(this.gbCompanyRelatedInformation);
            this.Controls.Add(this.gbPersonalInformation);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PersonalDataChangeForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.nupExtraHoliday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupHolidaysLeft)).EndInit();
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
        private System.Windows.Forms.Label lDoYouHaveDiasabledChild;
        private System.Windows.Forms.Label lDoYouHaveChild;
        private System.Windows.Forms.Label lHealthDamage;
        private System.Windows.Forms.CheckBox cbYesHealthDamage;
        private System.Windows.Forms.CheckBox cbNoHealthDamage;
        private System.Windows.Forms.CheckBox cbYesDisabledChild;
        private System.Windows.Forms.CheckBox cbNoDisabledChild;
        private System.Windows.Forms.CheckBox cbYesChild;
        private System.Windows.Forms.CheckBox cbNoChild;
        private System.Windows.Forms.NumericUpDown nupHolidaysLeft;
        private System.Windows.Forms.Label lHolidaysLeft;
        private System.Windows.Forms.NumericUpDown nupExtraHoliday;
        private System.Windows.Forms.Label lExtraHoliday;
    }
}