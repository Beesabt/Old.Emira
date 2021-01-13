namespace emira.GUI
{
    partial class PasswordChange
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordChange));
            this.lPasswordChange = new System.Windows.Forms.Label();
            this.btnPasswordChange = new System.Windows.Forms.Button();
            this.tbNewPasswordAgain = new System.Windows.Forms.TextBox();
            this.lOldPassword = new System.Windows.Forms.Label();
            this.lNewPassword = new System.Windows.Forms.Label();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.lNewPasswordAgain = new System.Windows.Forms.Label();
            this.tbOldPassword = new System.Windows.Forms.TextBox();
            this.pbPasswordInformation = new System.Windows.Forms.PictureBox();
            this.ttPasswordInformation = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPasswordInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // lPasswordChange
            // 
            this.lPasswordChange.AutoSize = true;
            this.lPasswordChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPasswordChange.Location = new System.Drawing.Point(100, 68);
            this.lPasswordChange.Name = "lPasswordChange";
            this.lPasswordChange.Size = new System.Drawing.Size(263, 37);
            this.lPasswordChange.TabIndex = 7;
            this.lPasswordChange.Text = "Jelszó módosítás";
            // 
            // btnPasswordChange
            // 
            this.btnPasswordChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(197)))));
            this.btnPasswordChange.FlatAppearance.BorderColor = System.Drawing.Color.Snow;
            this.btnPasswordChange.FlatAppearance.BorderSize = 0;
            this.btnPasswordChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnPasswordChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnPasswordChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasswordChange.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPasswordChange.ForeColor = System.Drawing.Color.White;
            this.btnPasswordChange.Location = new System.Drawing.Point(730, 425);
            this.btnPasswordChange.Name = "btnPasswordChange";
            this.btnPasswordChange.Size = new System.Drawing.Size(203, 49);
            this.btnPasswordChange.TabIndex = 3;
            this.btnPasswordChange.Text = "Mentés";
            this.btnPasswordChange.UseVisualStyleBackColor = false;
            this.btnPasswordChange.Click += new System.EventHandler(this.btnPasswordChange_Click);
            // 
            // tbNewPasswordAgain
            // 
            this.tbNewPasswordAgain.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNewPasswordAgain.Location = new System.Drawing.Point(384, 326);
            this.tbNewPasswordAgain.Name = "tbNewPasswordAgain";
            this.tbNewPasswordAgain.Size = new System.Drawing.Size(400, 26);
            this.tbNewPasswordAgain.TabIndex = 2;
            // 
            // lOldPassword
            // 
            this.lOldPassword.AutoSize = true;
            this.lOldPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lOldPassword.Location = new System.Drawing.Point(259, 182);
            this.lOldPassword.Name = "lOldPassword";
            this.lOldPassword.Size = new System.Drawing.Size(87, 21);
            this.lOldPassword.TabIndex = 4;
            this.lOldPassword.Text = "Régi jelszó:";
            // 
            // lNewPassword
            // 
            this.lNewPassword.AutoSize = true;
            this.lNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNewPassword.Location = new System.Drawing.Point(275, 258);
            this.lNewPassword.Name = "lNewPassword";
            this.lNewPassword.Size = new System.Drawing.Size(71, 21);
            this.lNewPassword.TabIndex = 5;
            this.lNewPassword.Text = "Új jelszó:";
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNewPassword.Location = new System.Drawing.Point(384, 253);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(400, 26);
            this.tbNewPassword.TabIndex = 1;
            // 
            // lNewPasswordAgain
            // 
            this.lNewPasswordAgain.AutoSize = true;
            this.lNewPasswordAgain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNewPasswordAgain.Location = new System.Drawing.Point(183, 328);
            this.lNewPasswordAgain.Name = "lNewPasswordAgain";
            this.lNewPasswordAgain.Size = new System.Drawing.Size(163, 21);
            this.lNewPasswordAgain.TabIndex = 6;
            this.lNewPasswordAgain.Text = "Új jelszó még egyszer:";
            // 
            // tbOldPassword
            // 
            this.tbOldPassword.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbOldPassword.Location = new System.Drawing.Point(384, 180);
            this.tbOldPassword.Name = "tbOldPassword";
            this.tbOldPassword.PasswordChar = '*';
            this.tbOldPassword.Size = new System.Drawing.Size(400, 26);
            this.tbOldPassword.TabIndex = 0;
            // 
            // pbPasswordInformation
            // 
            this.pbPasswordInformation.BackColor = System.Drawing.Color.Transparent;
            this.pbPasswordInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbPasswordInformation.Image = global::emira.Properties.Resources.info_icon;
            this.pbPasswordInformation.Location = new System.Drawing.Point(790, 253);
            this.pbPasswordInformation.Name = "pbPasswordInformation";
            this.pbPasswordInformation.Size = new System.Drawing.Size(26, 26);
            this.pbPasswordInformation.TabIndex = 9;
            this.pbPasswordInformation.TabStop = false;
            this.ttPasswordInformation.SetToolTip(this.pbPasswordInformation, resources.GetString("pbPasswordInformation.ToolTip"));
            // 
            // ttPasswordInformation
            // 
            this.ttPasswordInformation.IsBalloon = true;
            // 
            // PasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.pbPasswordInformation);
            this.Controls.Add(this.btnPasswordChange);
            this.Controls.Add(this.lPasswordChange);
            this.Controls.Add(this.tbNewPasswordAgain);
            this.Controls.Add(this.lOldPassword);
            this.Controls.Add(this.tbOldPassword);
            this.Controls.Add(this.lNewPassword);
            this.Controls.Add(this.lNewPasswordAgain);
            this.Controls.Add(this.tbNewPassword);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PasswordChange";
            this.Size = new System.Drawing.Size(1030, 535);
            ((System.ComponentModel.ISupportInitialize)(this.pbPasswordInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lPasswordChange;
        private System.Windows.Forms.Button btnPasswordChange;
        private System.Windows.Forms.TextBox tbNewPasswordAgain;
        private System.Windows.Forms.Label lOldPassword;
        private System.Windows.Forms.Label lNewPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.Label lNewPasswordAgain;
        private System.Windows.Forms.TextBox tbOldPassword;
        private System.Windows.Forms.PictureBox pbPasswordInformation;
        private System.Windows.Forms.ToolTip ttPasswordInformation;
    }
}
