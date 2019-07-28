namespace emira.GUI
{
    partial class WorkingHoursPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkingHoursPage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMinimalize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pMenuBar = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAddRemoveTask = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgvWorkingHours = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.pHeader.SuspendLayout();
            this.pMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkingHours)).BeginInit();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pHeader.Controls.Add(this.label1);
            this.pHeader.Controls.Add(this.btnMinimalize);
            this.pHeader.Controls.Add(this.btnExit);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1030, 30);
            this.pHeader.TabIndex = 0;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Emira - Munkaidő Kezelő";
            // 
            // btnMinimalize
            // 
            this.btnMinimalize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimalize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimalize.BackgroundImage")));
            this.btnMinimalize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimalize.FlatAppearance.BorderSize = 0;
            this.btnMinimalize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnMinimalize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnMinimalize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimalize.Location = new System.Drawing.Point(930, 0);
            this.btnMinimalize.Name = "btnMinimalize";
            this.btnMinimalize.Size = new System.Drawing.Size(50, 30);
            this.btnMinimalize.TabIndex = 3;
            this.btnMinimalize.UseVisualStyleBackColor = false;
            this.btnMinimalize.Click += new System.EventHandler(this.btnMinimalize_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(980, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = false;
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
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(1);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(181, 84);
            this.btnHome.TabIndex = 2;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(186)))), ((int)(((byte)(62)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(167)))), ((int)(((byte)(55)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(167)))), ((int)(((byte)(55)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(32, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 50);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(133)))), ((int)(((byte)(218)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(133)))), ((int)(((byte)(218)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(168, 142);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 50);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(304, 142);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 50);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // btnAddRemoveTask
            // 
            this.btnAddRemoveTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(82)))));
            this.btnAddRemoveTask.FlatAppearance.BorderSize = 0;
            this.btnAddRemoveTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(25)))), ((int)(((byte)(98)))));
            this.btnAddRemoveTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(25)))), ((int)(((byte)(98)))));
            this.btnAddRemoveTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRemoveTask.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddRemoveTask.ForeColor = System.Drawing.Color.White;
            this.btnAddRemoveTask.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRemoveTask.Image")));
            this.btnAddRemoveTask.Location = new System.Drawing.Point(879, 142);
            this.btnAddRemoveTask.Name = "btnAddRemoveTask";
            this.btnAddRemoveTask.Size = new System.Drawing.Size(120, 50);
            this.btnAddRemoveTask.TabIndex = 5;
            this.btnAddRemoveTask.Text = "Task";
            this.btnAddRemoveTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddRemoveTask.UseVisualStyleBackColor = false;
            this.btnAddRemoveTask.Click += new System.EventHandler(this.btnAddRemoveTask_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(548, 164);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 25);
            this.comboBox1.TabIndex = 6;
            // 
            // dgvWorkingHours
            // 
            this.dgvWorkingHours.AllowUserToAddRows = false;
            this.dgvWorkingHours.AllowUserToDeleteRows = false;
            this.dgvWorkingHours.AllowUserToResizeColumns = false;
            this.dgvWorkingHours.AllowUserToResizeRows = false;
            this.dgvWorkingHours.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvWorkingHours.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvWorkingHours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWorkingHours.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkingHours.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkingHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkingHours.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkingHours.Location = new System.Drawing.Point(32, 214);
            this.dgvWorkingHours.Name = "dgvWorkingHours";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkingHours.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWorkingHours.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvWorkingHours.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvWorkingHours.Size = new System.Drawing.Size(967, 415);
            this.dgvWorkingHours.TabIndex = 7;
            this.dgvWorkingHours.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvWorkingHours.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvWorkingHours_CellValidating);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(738, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(513, 164);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(25, 25);
            this.btnBack.TabIndex = 8;
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // WorkingHoursPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 650);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvWorkingHours);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnAddRemoveTask);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pMenuBar);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorkingHoursPage";
            this.Load += new System.EventHandler(this.WorkingHours_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pMenuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkingHours)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Panel pMenuBar;
        private System.Windows.Forms.Button btnMinimalize;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnAddRemoveTask;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgvWorkingHours;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBack;
    }
}