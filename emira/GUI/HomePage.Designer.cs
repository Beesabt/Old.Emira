namespace emira.GUI
{
    partial class HomePage
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMinimalize = new System.Windows.Forms.Button();
            this.lTitle = new System.Windows.Forms.Label();
            this.pFooter = new System.Windows.Forms.Panel();
            this.lFooter = new System.Windows.Forms.Label();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.btnHolidays = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnWorkingHours = new System.Windows.Forms.Button();
            this.pHeader.SuspendLayout();
            this.pFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pHeader.Controls.Add(this.btnExit);
            this.pHeader.Controls.Add(this.btnMinimalize);
            this.pHeader.Controls.Add(this.lTitle);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1373, 37);
            this.pHeader.TabIndex = 1;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::emira.Properties.Resources.close_icon_white_26;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1307, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(67, 37);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMinimalize
            // 
            this.btnMinimalize.BackgroundImage = global::emira.Properties.Resources.minimize_icon_white_26;
            this.btnMinimalize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimalize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMinimalize.FlatAppearance.BorderSize = 0;
            this.btnMinimalize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnMinimalize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnMinimalize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimalize.Location = new System.Drawing.Point(1240, 0);
            this.btnMinimalize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinimalize.Name = "btnMinimalize";
            this.btnMinimalize.Size = new System.Drawing.Size(67, 37);
            this.btnMinimalize.TabIndex = 3;
            this.btnMinimalize.UseVisualStyleBackColor = true;
            this.btnMinimalize.Click += new System.EventHandler(this.btnMinimalize_Click);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(0, 0);
            this.lTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(231, 36);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "Emira - Főoldal";
            // 
            // pFooter
            // 
            this.pFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pFooter.Controls.Add(this.lFooter);
            this.pFooter.Location = new System.Drawing.Point(1, 774);
            this.pFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pFooter.Name = "pFooter";
            this.pFooter.Size = new System.Drawing.Size(1371, 25);
            this.pFooter.TabIndex = 6;
            // 
            // lFooter
            // 
            this.lFooter.AutoSize = true;
            this.lFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lFooter.Location = new System.Drawing.Point(563, 2);
            this.lFooter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lFooter.Name = "lFooter";
            this.lFooter.Size = new System.Drawing.Size(0, 20);
            this.lFooter.TabIndex = 0;
            this.lFooter.Text = "Contact: beesabt@gmail.com";
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(0)))));
            this.btnStatistics.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStatistics.FlatAppearance.BorderSize = 0;
            this.btnStatistics.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange;
            this.btnStatistics.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.ForeColor = System.Drawing.Color.White;
            this.btnStatistics.Image = global::emira.Properties.Resources.piechart_icon_white_100;
            this.btnStatistics.Location = new System.Drawing.Point(713, 428);
            this.btnStatistics.Margin = new System.Windows.Forms.Padding(1);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(587, 295);
            this.btnStatistics.TabIndex = 5;
            this.btnStatistics.Text = "Statisztika";
            this.btnStatistics.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnStatistics.UseVisualStyleBackColor = false;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // btnHolidays
            // 
            this.btnHolidays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(82)))));
            this.btnHolidays.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHolidays.FlatAppearance.BorderSize = 0;
            this.btnHolidays.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(25)))), ((int)(((byte)(109)))));
            this.btnHolidays.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(25)))), ((int)(((byte)(109)))));
            this.btnHolidays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHolidays.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHolidays.ForeColor = System.Drawing.Color.White;
            this.btnHolidays.Image = global::emira.Properties.Resources.beach_icon_white_50;
            this.btnHolidays.Location = new System.Drawing.Point(73, 428);
            this.btnHolidays.Margin = new System.Windows.Forms.Padding(1);
            this.btnHolidays.Name = "btnHolidays";
            this.btnHolidays.Size = new System.Drawing.Size(587, 295);
            this.btnHolidays.TabIndex = 4;
            this.btnHolidays.Text = "Szabadság";
            this.btnHolidays.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnHolidays.UseVisualStyleBackColor = false;
            this.btnHolidays.Click += new System.EventHandler(this.btnHolidays_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(130)))), ((int)(((byte)(5)))));
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(143)))), ((int)(((byte)(30)))));
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(143)))), ((int)(((byte)(30)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::emira.Properties.Resources.settings_icon_white_50;
            this.btnSettings.Location = new System.Drawing.Point(713, 85);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(1);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(587, 295);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Beállítások";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnWorkingHours
            // 
            this.btnWorkingHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(120)))), ((int)(((byte)(167)))));
            this.btnWorkingHours.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnWorkingHours.FlatAppearance.BorderSize = 0;
            this.btnWorkingHours.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnWorkingHours.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnWorkingHours.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkingHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWorkingHours.ForeColor = System.Drawing.Color.White;
            this.btnWorkingHours.Image = global::emira.Properties.Resources.clock_icon_white_100;
            this.btnWorkingHours.Location = new System.Drawing.Point(73, 85);
            this.btnWorkingHours.Margin = new System.Windows.Forms.Padding(1);
            this.btnWorkingHours.Name = "btnWorkingHours";
            this.btnWorkingHours.Size = new System.Drawing.Size(587, 295);
            this.btnWorkingHours.TabIndex = 2;
            this.btnWorkingHours.Text = "Munkaidő";
            this.btnWorkingHours.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnWorkingHours.UseVisualStyleBackColor = false;
            this.btnWorkingHours.Click += new System.EventHandler(this.btnWorkingHours_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1373, 800);
            this.Controls.Add(this.pFooter);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.btnHolidays);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnWorkingHours);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.MainPage_Shown);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pFooter.ResumeLayout(false);
            this.pFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnWorkingHours;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.Button btnHolidays;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMinimalize;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Panel pFooter;
        private System.Windows.Forms.Label lFooter;
    }
}