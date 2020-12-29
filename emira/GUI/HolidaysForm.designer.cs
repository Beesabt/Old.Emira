namespace emira.GUI
{
    partial class HolidaysForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HolidaysForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lHeader = new System.Windows.Forms.Label();
            this.btnMinimalized = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pMenuBar = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.gbAddHoliday = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lErrorMessage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.tlpAddHoliday = new System.Windows.Forms.TableLayoutPanel();
            this.lFrameDays = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lTitle = new System.Windows.Forms.Label();
            this.lFrame = new System.Windows.Forms.Label();
            this.lNormalHoliday = new System.Windows.Forms.Label();
            this.lSelected = new System.Windows.Forms.Label();
            this.lFrom = new System.Windows.Forms.Label();
            this.lTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lSelectedDays = new System.Windows.Forms.Label();
            this.gbHoliday = new System.Windows.Forms.GroupBox();
            this.tlpHoliday = new System.Windows.Forms.TableLayoutPanel();
            this.lPredictableDays = new System.Windows.Forms.Label();
            this.lPredictable = new System.Windows.Forms.Label();
            this.lAppliedDays = new System.Windows.Forms.Label();
            this.lApplied = new System.Windows.Forms.Label();
            this.lAnnualOpeningFrameDays = new System.Windows.Forms.Label();
            this.lAnnualOpeningFrame = new System.Windows.Forms.Label();
            this.gbHolidaysSoFar = new System.Windows.Forms.GroupBox();
            this.btnAddGovernmentHoliday = new System.Windows.Forms.Button();
            this.lState = new System.Windows.Forms.Label();
            this.lYear = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.dgvHolidays = new System.Windows.Forms.DataGridView();
            this.btnCancellation = new System.Windows.Forms.Button();
            this.cbYears = new System.Windows.Forms.ComboBox();
            this.pHeader.SuspendLayout();
            this.pMenuBar.SuspendLayout();
            this.gbAddHoliday.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tlpAddHoliday.SuspendLayout();
            this.gbHoliday.SuspendLayout();
            this.tlpHoliday.SuspendLayout();
            this.gbHolidaysSoFar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidays)).BeginInit();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pHeader.Controls.Add(this.lHeader);
            this.pHeader.Controls.Add(this.btnMinimalized);
            this.pHeader.Controls.Add(this.btnExit);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1030, 30);
            this.pHeader.TabIndex = 0;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // lHeader
            // 
            this.lHeader.AutoSize = true;
            this.lHeader.BackColor = System.Drawing.Color.Transparent;
            this.lHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lHeader.ForeColor = System.Drawing.Color.White;
            this.lHeader.Location = new System.Drawing.Point(0, 0);
            this.lHeader.Name = "lHeader";
            this.lHeader.Size = new System.Drawing.Size(305, 29);
            this.lHeader.TabIndex = 2;
            this.lHeader.Text = "Emira - Munkaidő Kezelő";
            // 
            // btnMinimalized
            // 
            this.btnMinimalized.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimalized.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimalized.BackgroundImage")));
            this.btnMinimalized.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimalized.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMinimalized.FlatAppearance.BorderSize = 0;
            this.btnMinimalized.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnMinimalized.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnMinimalized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimalized.Location = new System.Drawing.Point(929, 0);
            this.btnMinimalized.Name = "btnMinimalized";
            this.btnMinimalized.Size = new System.Drawing.Size(50, 30);
            this.btnMinimalized.TabIndex = 3;
            this.btnMinimalized.UseVisualStyleBackColor = false;
            this.btnMinimalized.Click += new System.EventHandler(this.btnMinimalized_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(980, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pMenuBar
            // 
            this.pMenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pMenuBar.Controls.Add(this.btnHome);
            this.pMenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMenuBar.Location = new System.Drawing.Point(0, 30);
            this.pMenuBar.Name = "pMenuBar";
            this.pMenuBar.Size = new System.Drawing.Size(1030, 85);
            this.pMenuBar.TabIndex = 1;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(1);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(180, 85);
            this.btnHome.TabIndex = 2;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // gbAddHoliday
            // 
            this.gbAddHoliday.BackColor = System.Drawing.Color.White;
            this.gbAddHoliday.Controls.Add(this.flowLayoutPanel1);
            this.gbAddHoliday.Controls.Add(this.btnCancel);
            this.gbAddHoliday.Controls.Add(this.btnAdd);
            this.gbAddHoliday.Controls.Add(this.btnCheck);
            this.gbAddHoliday.Controls.Add(this.tlpAddHoliday);
            this.gbAddHoliday.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbAddHoliday.Location = new System.Drawing.Point(23, 140);
            this.gbAddHoliday.Name = "gbAddHoliday";
            this.gbAddHoliday.Size = new System.Drawing.Size(339, 320);
            this.gbAddHoliday.TabIndex = 2;
            this.gbAddHoliday.TabStop = false;
            this.gbAddHoliday.Text = "Szabadság hozzáadás";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lErrorMessage);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 243);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(283, 71);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // lErrorMessage
            // 
            this.lErrorMessage.AutoSize = true;
            this.lErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lErrorMessage.Location = new System.Drawing.Point(3, 0);
            this.lErrorMessage.Name = "lErrorMessage";
            this.lErrorMessage.Size = new System.Drawing.Size(0, 21);
            this.lErrorMessage.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancel.Location = new System.Drawing.Point(189, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 34);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Mégse";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(23, 203);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 34);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Hozzáad";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnCheck.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCheck.FlatAppearance.BorderSize = 0;
            this.btnCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCheck.ForeColor = System.Drawing.Color.White;
            this.btnCheck.Location = new System.Drawing.Point(108, 203);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(113, 34);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Ellenőriz";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // tlpAddHoliday
            // 
            this.tlpAddHoliday.ColumnCount = 2;
            this.tlpAddHoliday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAddHoliday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAddHoliday.Controls.Add(this.lFrameDays, 1, 4);
            this.tlpAddHoliday.Controls.Add(this.dtpTo, 1, 2);
            this.tlpAddHoliday.Controls.Add(this.lTitle, 0, 0);
            this.tlpAddHoliday.Controls.Add(this.lFrame, 0, 4);
            this.tlpAddHoliday.Controls.Add(this.lNormalHoliday, 1, 0);
            this.tlpAddHoliday.Controls.Add(this.lSelected, 0, 3);
            this.tlpAddHoliday.Controls.Add(this.lFrom, 0, 1);
            this.tlpAddHoliday.Controls.Add(this.lTo, 0, 2);
            this.tlpAddHoliday.Controls.Add(this.dtpFrom, 1, 1);
            this.tlpAddHoliday.Controls.Add(this.lSelectedDays, 1, 3);
            this.tlpAddHoliday.Location = new System.Drawing.Point(23, 40);
            this.tlpAddHoliday.Name = "tlpAddHoliday";
            this.tlpAddHoliday.RowCount = 5;
            this.tlpAddHoliday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAddHoliday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAddHoliday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAddHoliday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAddHoliday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpAddHoliday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAddHoliday.Size = new System.Drawing.Size(283, 157);
            this.tlpAddHoliday.TabIndex = 0;
            // 
            // lFrameDays
            // 
            this.lFrameDays.AutoSize = true;
            this.lFrameDays.Location = new System.Drawing.Point(144, 124);
            this.lFrameDays.Name = "lFrameDays";
            this.lFrameDays.Size = new System.Drawing.Size(68, 17);
            this.lFrameDays.TabIndex = 9;
            this.lFrameDays.Text = "Unknown";
            this.lFrameDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "yyyy-MM-dd";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(144, 65);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(136, 23);
            this.dtpTo.TabIndex = 7;
            this.dtpTo.UseWaitCursor = true;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTitle.Location = new System.Drawing.Point(3, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(105, 20);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Megnevezés";
            // 
            // lFrame
            // 
            this.lFrame.AutoSize = true;
            this.lFrame.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFrame.Location = new System.Drawing.Point(3, 124);
            this.lFrame.Name = "lFrame";
            this.lFrame.Size = new System.Drawing.Size(48, 20);
            this.lFrame.TabIndex = 5;
            this.lFrame.Text = "Keret";
            // 
            // lNormalHoliday
            // 
            this.lNormalHoliday.AutoSize = true;
            this.lNormalHoliday.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNormalHoliday.Location = new System.Drawing.Point(144, 0);
            this.lNormalHoliday.Name = "lNormalHoliday";
            this.lNormalHoliday.Size = new System.Drawing.Size(88, 20);
            this.lNormalHoliday.TabIndex = 1;
            this.lNormalHoliday.Text = "Szabadság";
            // 
            // lSelected
            // 
            this.lSelected.AutoSize = true;
            this.lSelected.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSelected.Location = new System.Drawing.Point(3, 93);
            this.lSelected.Name = "lSelected";
            this.lSelected.Size = new System.Drawing.Size(80, 20);
            this.lSelected.TabIndex = 4;
            this.lSelected.Text = "Választott";
            // 
            // lFrom
            // 
            this.lFrom.AutoSize = true;
            this.lFrom.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFrom.Location = new System.Drawing.Point(3, 31);
            this.lFrom.Name = "lFrom";
            this.lFrom.Size = new System.Drawing.Size(68, 20);
            this.lFrom.TabIndex = 2;
            this.lFrom.Text = "Mikortól";
            // 
            // lTo
            // 
            this.lTo.AutoSize = true;
            this.lTo.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTo.Location = new System.Drawing.Point(3, 62);
            this.lTo.Name = "lTo";
            this.lTo.Size = new System.Drawing.Size(67, 20);
            this.lTo.TabIndex = 3;
            this.lTo.Text = "Meddig";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "yyyy-MM-dd";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(144, 34);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(136, 23);
            this.dtpFrom.TabIndex = 6;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // lSelectedDays
            // 
            this.lSelectedDays.AutoSize = true;
            this.lSelectedDays.Location = new System.Drawing.Point(144, 93);
            this.lSelectedDays.Name = "lSelectedDays";
            this.lSelectedDays.Size = new System.Drawing.Size(68, 17);
            this.lSelectedDays.TabIndex = 8;
            this.lSelectedDays.Text = "Unknown";
            this.lSelectedDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbHoliday
            // 
            this.gbHoliday.BackColor = System.Drawing.Color.White;
            this.gbHoliday.Controls.Add(this.tlpHoliday);
            this.gbHoliday.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbHoliday.Location = new System.Drawing.Point(23, 466);
            this.gbHoliday.Name = "gbHoliday";
            this.gbHoliday.Size = new System.Drawing.Size(339, 173);
            this.gbHoliday.TabIndex = 3;
            this.gbHoliday.TabStop = false;
            this.gbHoliday.Text = "Szabadság";
            // 
            // tlpHoliday
            // 
            this.tlpHoliday.ColumnCount = 2;
            this.tlpHoliday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHoliday.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHoliday.Controls.Add(this.lPredictableDays, 1, 2);
            this.tlpHoliday.Controls.Add(this.lPredictable, 0, 2);
            this.tlpHoliday.Controls.Add(this.lAppliedDays, 1, 1);
            this.tlpHoliday.Controls.Add(this.lApplied, 0, 1);
            this.tlpHoliday.Controls.Add(this.lAnnualOpeningFrameDays, 1, 0);
            this.tlpHoliday.Controls.Add(this.lAnnualOpeningFrame, 0, 0);
            this.tlpHoliday.Location = new System.Drawing.Point(23, 34);
            this.tlpHoliday.Name = "tlpHoliday";
            this.tlpHoliday.RowCount = 3;
            this.tlpHoliday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.62376F));
            this.tlpHoliday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.69307F));
            this.tlpHoliday.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.67327F));
            this.tlpHoliday.Size = new System.Drawing.Size(283, 133);
            this.tlpHoliday.TabIndex = 0;
            // 
            // lPredictableDays
            // 
            this.lPredictableDays.AutoSize = true;
            this.lPredictableDays.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPredictableDays.Location = new System.Drawing.Point(144, 89);
            this.lPredictableDays.Name = "lPredictableDays";
            this.lPredictableDays.Size = new System.Drawing.Size(85, 20);
            this.lPredictableDays.TabIndex = 5;
            this.lPredictableDays.Text = "Ismeretlen";
            this.lPredictableDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lPredictable
            // 
            this.lPredictable.AutoSize = true;
            this.lPredictable.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPredictable.Location = new System.Drawing.Point(3, 89);
            this.lPredictable.Name = "lPredictable";
            this.lPredictable.Size = new System.Drawing.Size(89, 20);
            this.lPredictable.TabIndex = 4;
            this.lPredictable.Text = "Tervezhető";
            this.lPredictable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lAppliedDays
            // 
            this.lAppliedDays.AutoSize = true;
            this.lAppliedDays.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lAppliedDays.Location = new System.Drawing.Point(144, 49);
            this.lAppliedDays.Name = "lAppliedDays";
            this.lAppliedDays.Size = new System.Drawing.Size(85, 20);
            this.lAppliedDays.TabIndex = 3;
            this.lAppliedDays.Text = "Ismeretlen";
            this.lAppliedDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lApplied
            // 
            this.lApplied.AutoSize = true;
            this.lApplied.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lApplied.Location = new System.Drawing.Point(3, 49);
            this.lApplied.Name = "lApplied";
            this.lApplied.Size = new System.Drawing.Size(85, 20);
            this.lApplied.TabIndex = 2;
            this.lApplied.Text = "Elfogadott";
            this.lApplied.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lAnnualOpeningFrameDays
            // 
            this.lAnnualOpeningFrameDays.AutoSize = true;
            this.lAnnualOpeningFrameDays.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lAnnualOpeningFrameDays.Location = new System.Drawing.Point(144, 0);
            this.lAnnualOpeningFrameDays.Name = "lAnnualOpeningFrameDays";
            this.lAnnualOpeningFrameDays.Size = new System.Drawing.Size(85, 20);
            this.lAnnualOpeningFrameDays.TabIndex = 1;
            this.lAnnualOpeningFrameDays.Text = "Ismeretlen";
            this.lAnnualOpeningFrameDays.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lAnnualOpeningFrame
            // 
            this.lAnnualOpeningFrame.AutoSize = true;
            this.lAnnualOpeningFrame.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lAnnualOpeningFrame.Location = new System.Drawing.Point(3, 0);
            this.lAnnualOpeningFrame.Name = "lAnnualOpeningFrame";
            this.lAnnualOpeningFrame.Size = new System.Drawing.Size(124, 20);
            this.lAnnualOpeningFrame.TabIndex = 0;
            this.lAnnualOpeningFrame.Text = "Éves nyitó keret";
            this.lAnnualOpeningFrame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbHolidaysSoFar
            // 
            this.gbHolidaysSoFar.BackColor = System.Drawing.Color.White;
            this.gbHolidaysSoFar.Controls.Add(this.btnAddGovernmentHoliday);
            this.gbHolidaysSoFar.Controls.Add(this.lState);
            this.gbHolidaysSoFar.Controls.Add(this.lYear);
            this.gbHolidaysSoFar.Controls.Add(this.cbState);
            this.gbHolidaysSoFar.Controls.Add(this.dgvHolidays);
            this.gbHolidaysSoFar.Controls.Add(this.btnCancellation);
            this.gbHolidaysSoFar.Controls.Add(this.cbYears);
            this.gbHolidaysSoFar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbHolidaysSoFar.Location = new System.Drawing.Point(378, 140);
            this.gbHolidaysSoFar.Name = "gbHolidaysSoFar";
            this.gbHolidaysSoFar.Size = new System.Drawing.Size(636, 499);
            this.gbHolidaysSoFar.TabIndex = 3;
            this.gbHolidaysSoFar.TabStop = false;
            this.gbHolidaysSoFar.Text = "Szabadságok eddig";
            // 
            // btnAddGovernmentHoliday
            // 
            this.btnAddGovernmentHoliday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(186)))), ((int)(((byte)(62)))));
            this.btnAddGovernmentHoliday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddGovernmentHoliday.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddGovernmentHoliday.FlatAppearance.BorderSize = 0;
            this.btnAddGovernmentHoliday.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(167)))), ((int)(((byte)(55)))));
            this.btnAddGovernmentHoliday.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(167)))), ((int)(((byte)(55)))));
            this.btnAddGovernmentHoliday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGovernmentHoliday.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddGovernmentHoliday.ForeColor = System.Drawing.Color.White;
            this.btnAddGovernmentHoliday.Image = global::emira.Properties.Resources.add_icon_white_26;
            this.btnAddGovernmentHoliday.Location = new System.Drawing.Point(361, 39);
            this.btnAddGovernmentHoliday.Name = "btnAddGovernmentHoliday";
            this.btnAddGovernmentHoliday.Size = new System.Drawing.Size(130, 40);
            this.btnAddGovernmentHoliday.TabIndex = 6;
            this.btnAddGovernmentHoliday.Text = "Pihenőnap";
            this.btnAddGovernmentHoliday.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddGovernmentHoliday.UseVisualStyleBackColor = false;
            this.btnAddGovernmentHoliday.Click += new System.EventHandler(this.btnAddGovernmentHoliday_Click);
            // 
            // lState
            // 
            this.lState.AutoSize = true;
            this.lState.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lState.Location = new System.Drawing.Point(153, 51);
            this.lState.Name = "lState";
            this.lState.Size = new System.Drawing.Size(65, 20);
            this.lState.TabIndex = 5;
            this.lState.Text = "Állapot:";
            // 
            // lYear
            // 
            this.lYear.AutoSize = true;
            this.lYear.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lYear.Location = new System.Drawing.Point(20, 51);
            this.lYear.Name = "lYear";
            this.lYear.Size = new System.Drawing.Size(31, 20);
            this.lYear.TabIndex = 4;
            this.lYear.Text = "Év:";
            // 
            // cbState
            // 
            this.cbState.BackColor = System.Drawing.Color.White;
            this.cbState.DropDownHeight = 100;
            this.cbState.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbState.FormattingEnabled = true;
            this.cbState.IntegralHeight = false;
            this.cbState.ItemHeight = 21;
            this.cbState.Items.AddRange(new object[] {
            "Aktuális",
            "Mind"});
            this.cbState.Location = new System.Drawing.Point(224, 46);
            this.cbState.MaxDropDownItems = 5;
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(90, 29);
            this.cbState.TabIndex = 3;
            this.cbState.Text = "Aktuális";
            this.cbState.SelectedIndexChanged += new System.EventHandler(this.cbState_SelectedIndexChanged);
            this.cbState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbState_KeyPress);
            // 
            // dgvHolidays
            // 
            this.dgvHolidays.AllowUserToAddRows = false;
            this.dgvHolidays.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgvHolidays.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHolidays.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHolidays.BackgroundColor = System.Drawing.Color.White;
            this.dgvHolidays.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHolidays.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.LightYellow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHolidays.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHolidays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHolidays.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHolidays.Location = new System.Drawing.Point(24, 96);
            this.dgvHolidays.Name = "dgvHolidays";
            this.dgvHolidays.RowHeadersVisible = false;
            this.dgvHolidays.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHolidays.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHolidays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHolidays.Size = new System.Drawing.Size(588, 380);
            this.dgvHolidays.TabIndex = 2;
            this.dgvHolidays.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHolidays_CellClick);
            this.dgvHolidays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvHolidays_KeyDown);
            // 
            // btnCancellation
            // 
            this.btnCancellation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(52)))), ((int)(((byte)(56)))));
            this.btnCancellation.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancellation.FlatAppearance.BorderSize = 0;
            this.btnCancellation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(71)))), ((int)(((byte)(75)))));
            this.btnCancellation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(71)))), ((int)(((byte)(75)))));
            this.btnCancellation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancellation.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnCancellation.ForeColor = System.Drawing.Color.White;
            this.btnCancellation.Image = global::emira.Properties.Resources.delete_icon_white_26;
            this.btnCancellation.Location = new System.Drawing.Point(509, 39);
            this.btnCancellation.Name = "btnCancellation";
            this.btnCancellation.Size = new System.Drawing.Size(100, 40);
            this.btnCancellation.TabIndex = 1;
            this.btnCancellation.Text = "Stornó";
            this.btnCancellation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancellation.UseVisualStyleBackColor = false;
            this.btnCancellation.Click += new System.EventHandler(this.btnCancellation_Click);
            // 
            // cbYears
            // 
            this.cbYears.BackColor = System.Drawing.Color.White;
            this.cbYears.DropDownHeight = 100;
            this.cbYears.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbYears.FormattingEnabled = true;
            this.cbYears.IntegralHeight = false;
            this.cbYears.ItemHeight = 21;
            this.cbYears.Location = new System.Drawing.Point(57, 46);
            this.cbYears.MaxDropDownItems = 5;
            this.cbYears.Name = "cbYears";
            this.cbYears.Size = new System.Drawing.Size(90, 29);
            this.cbYears.TabIndex = 0;
            this.cbYears.SelectedIndexChanged += new System.EventHandler(this.cbYears_SelectedIndexChanged);
            this.cbYears.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbYears_KeyPress);
            // 
            // HolidaysPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 650);
            this.Controls.Add(this.gbHolidaysSoFar);
            this.Controls.Add(this.gbHoliday);
            this.Controls.Add(this.gbAddHoliday);
            this.Controls.Add(this.pMenuBar);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HolidaysPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.HolidaysPage_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pMenuBar.ResumeLayout(false);
            this.gbAddHoliday.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tlpAddHoliday.ResumeLayout(false);
            this.tlpAddHoliday.PerformLayout();
            this.gbHoliday.ResumeLayout(false);
            this.tlpHoliday.ResumeLayout(false);
            this.tlpHoliday.PerformLayout();
            this.gbHolidaysSoFar.ResumeLayout(false);
            this.gbHolidaysSoFar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel pMenuBar;
        private System.Windows.Forms.Button btnMinimalized;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lHeader;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.GroupBox gbAddHoliday;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TableLayoutPanel tlpAddHoliday;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lFrame;
        private System.Windows.Forms.Label lNormalHoliday;
        private System.Windows.Forms.Label lSelected;
        private System.Windows.Forms.Label lFrom;
        private System.Windows.Forms.Label lTo;
        private System.Windows.Forms.GroupBox gbHoliday;
        private System.Windows.Forms.TableLayoutPanel tlpHoliday;
        private System.Windows.Forms.Label lPredictableDays;
        private System.Windows.Forms.Label lPredictable;
        private System.Windows.Forms.Label lAppliedDays;
        private System.Windows.Forms.Label lApplied;
        private System.Windows.Forms.Label lAnnualOpeningFrameDays;
        private System.Windows.Forms.Label lAnnualOpeningFrame;
        private System.Windows.Forms.GroupBox gbHolidaysSoFar;
        private System.Windows.Forms.DataGridView dgvHolidays;
        private System.Windows.Forms.Button btnCancellation;
        private System.Windows.Forms.ComboBox cbYears;
        private System.Windows.Forms.Label lFrameDays;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lSelectedDays;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lErrorMessage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lState;
        private System.Windows.Forms.Label lYear;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.Button btnAddGovernmentHoliday;
    }
}