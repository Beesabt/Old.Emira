namespace emira.GUI
{
    partial class SettingsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPage));
            this.pMenuBar = new System.Windows.Forms.Panel();
            this.btnPersonalInformation = new System.Windows.Forms.Button();
            this.btnTaskManager = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPassword = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.lTitle = new System.Windows.Forms.Label();
            this.pHeader = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.UCtaskManager = new emira.GUI.TaskManager();
            this.UCpersonalInformation = new emira.GUI.PersonalInformation();
            this.UCusernameChange = new emira.GUI.EmailChange();
            this.UCpasswordChange = new emira.GUI.PasswordChange();
            this.pMenuBar.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.pSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMenuBar
            // 
            this.pMenuBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pMenuBar.Controls.Add(this.btnPersonalInformation);
            this.pMenuBar.Controls.Add(this.btnTaskManager);
            this.pMenuBar.Controls.Add(this.btnBack);
            this.pMenuBar.Controls.Add(this.btnPassword);
            this.pMenuBar.Controls.Add(this.btnEmail);
            this.pMenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMenuBar.Location = new System.Drawing.Point(0, 30);
            this.pMenuBar.Name = "pMenuBar";
            this.pMenuBar.Size = new System.Drawing.Size(1030, 85);
            this.pMenuBar.TabIndex = 1;
            // 
            // btnPersonalInformation
            // 
            this.btnPersonalInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(186)))), ((int)(((byte)(62)))));
            this.btnPersonalInformation.FlatAppearance.BorderSize = 0;
            this.btnPersonalInformation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(167)))), ((int)(((byte)(55)))));
            this.btnPersonalInformation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(167)))), ((int)(((byte)(55)))));
            this.btnPersonalInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersonalInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPersonalInformation.ForeColor = System.Drawing.Color.White;
            this.btnPersonalInformation.Image = global::emira.Properties.Resources.info_icon_white_50;
            this.btnPersonalInformation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonalInformation.Location = new System.Drawing.Point(180, 0);
            this.btnPersonalInformation.Margin = new System.Windows.Forms.Padding(1);
            this.btnPersonalInformation.Name = "btnPersonalInformation";
            this.btnPersonalInformation.Size = new System.Drawing.Size(180, 85);
            this.btnPersonalInformation.TabIndex = 6;
            this.btnPersonalInformation.Text = "Personal\r\ninformation";
            this.btnPersonalInformation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPersonalInformation.UseVisualStyleBackColor = false;
            this.btnPersonalInformation.Click += new System.EventHandler(this.btnPersonalInformation_Click);
            // 
            // btnTaskManager
            // 
            this.btnTaskManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(82)))));
            this.btnTaskManager.FlatAppearance.BorderSize = 0;
            this.btnTaskManager.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(25)))), ((int)(((byte)(98)))));
            this.btnTaskManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(25)))), ((int)(((byte)(98)))));
            this.btnTaskManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaskManager.ForeColor = System.Drawing.Color.White;
            this.btnTaskManager.Image = global::emira.Properties.Resources.task_icon_white_50;
            this.btnTaskManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaskManager.Location = new System.Drawing.Point(720, 0);
            this.btnTaskManager.Margin = new System.Windows.Forms.Padding(1);
            this.btnTaskManager.Name = "btnTaskManager";
            this.btnTaskManager.Size = new System.Drawing.Size(180, 85);
            this.btnTaskManager.TabIndex = 5;
            this.btnTaskManager.Text = "Task\r\nmanager";
            this.btnTaskManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaskManager.UseVisualStyleBackColor = false;
            this.btnTaskManager.Click += new System.EventHandler(this.btnTaskManager_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnBack.Image = global::emira.Properties.Resources.back_icon_white_50;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Margin = new System.Windows.Forms.Padding(1);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 85);
            this.btnBack.TabIndex = 0;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnPassword
            // 
            this.btnPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnPassword.FlatAppearance.BorderSize = 0;
            this.btnPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(133)))), ((int)(((byte)(218)))));
            this.btnPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(133)))), ((int)(((byte)(218)))));
            this.btnPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPassword.ForeColor = System.Drawing.Color.White;
            this.btnPassword.Image = global::emira.Properties.Resources.lock_icon_white_50;
            this.btnPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPassword.Location = new System.Drawing.Point(360, 0);
            this.btnPassword.Margin = new System.Windows.Forms.Padding(1);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(180, 85);
            this.btnPassword.TabIndex = 3;
            this.btnPassword.Text = "Password\r\nchange";
            this.btnPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPassword.UseVisualStyleBackColor = false;
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.btnEmail.FlatAppearance.BorderSize = 0;
            this.btnEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.btnEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(166)))), ((int)(((byte)(0)))));
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.ForeColor = System.Drawing.Color.White;
            this.btnEmail.Image = global::emira.Properties.Resources.email_icon_white_50;
            this.btnEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmail.Location = new System.Drawing.Point(540, 0);
            this.btnEmail.Margin = new System.Windows.Forms.Padding(1);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(180, 85);
            this.btnEmail.TabIndex = 4;
            this.btnEmail.Text = "E-mail\r\nchange";
            this.btnEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTitle.ForeColor = System.Drawing.Color.White;
            this.lTitle.Location = new System.Drawing.Point(0, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(305, 29);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "Emira - Munkaidő Kezelő";
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pHeader.Controls.Add(this.btnMinimize);
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
            // btnMinimize
            // 
            this.btnMinimize.BackgroundImage = global::emira.Properties.Resources.subtract_icon_white_26;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(930, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(50, 30);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(980, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pSettings
            // 
            this.pSettings.Controls.Add(this.UCtaskManager);
            this.pSettings.Controls.Add(this.UCpersonalInformation);
            this.pSettings.Controls.Add(this.UCusernameChange);
            this.pSettings.Controls.Add(this.UCpasswordChange);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pSettings.Location = new System.Drawing.Point(0, 115);
            this.pSettings.Name = "pSettings";
            this.pSettings.Size = new System.Drawing.Size(1030, 535);
            this.pSettings.TabIndex = 2;
            // 
            // UCtaskManager
            // 
            this.UCtaskManager.BackColor = System.Drawing.Color.Snow;
            this.UCtaskManager.Location = new System.Drawing.Point(0, 0);
            this.UCtaskManager.Margin = new System.Windows.Forms.Padding(0);
            this.UCtaskManager.Name = "UCtaskManager";
            this.UCtaskManager.Size = new System.Drawing.Size(1030, 535);
            this.UCtaskManager.TabIndex = 3;
            // 
            // UCpersonalInformation
            // 
            this.UCpersonalInformation.BackColor = System.Drawing.Color.White;
            this.UCpersonalInformation.Location = new System.Drawing.Point(0, 535);
            this.UCpersonalInformation.Margin = new System.Windows.Forms.Padding(0);
            this.UCpersonalInformation.Name = "UCpersonalInformation";
            this.UCpersonalInformation.Size = new System.Drawing.Size(1030, 535);
            this.UCpersonalInformation.TabIndex = 2;
            // 
            // UCusernameChange
            // 
            this.UCusernameChange.BackColor = System.Drawing.Color.White;
            this.UCusernameChange.Location = new System.Drawing.Point(0, 1070);
            this.UCusernameChange.Margin = new System.Windows.Forms.Padding(0);
            this.UCusernameChange.Name = "UCusernameChange";
            this.UCusernameChange.Size = new System.Drawing.Size(1030, 535);
            this.UCusernameChange.TabIndex = 1;
            // 
            // UCpasswordChange
            // 
            this.UCpasswordChange.BackColor = System.Drawing.Color.White;
            this.UCpasswordChange.Location = new System.Drawing.Point(0, 1605);
            this.UCpasswordChange.Margin = new System.Windows.Forms.Padding(0);
            this.UCpasswordChange.Name = "UCpasswordChange";
            this.UCpasswordChange.Size = new System.Drawing.Size(1030, 535);
            this.UCpasswordChange.TabIndex = 0;
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 650);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.pSettings);
            this.Controls.Add(this.pMenuBar);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsPage";
            this.Load += new System.EventHandler(this.SettingsPage_Load);
            this.pMenuBar.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pSettings.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pMenuBar;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnTaskManager;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.FlowLayoutPanel pSettings;
        private PersonalInformation UCpersonalInformation;
        private EmailChange UCusernameChange;
        private PasswordChange UCpasswordChange;
        private System.Windows.Forms.Button btnPersonalInformation;
        private TaskManager UCtaskManager;
    }
}