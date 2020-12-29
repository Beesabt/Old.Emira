namespace emira.GUI
{
    partial class EmailChange
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
            this.lUsernameChange = new System.Windows.Forms.Label();
            this.btnUNameChange = new System.Windows.Forms.Button();
            this.tbNewEmailAgain = new System.Windows.Forms.TextBox();
            this.lNewEmail = new System.Windows.Forms.Label();
            this.tbNewEmail = new System.Windows.Forms.TextBox();
            this.lNewEmailAgain = new System.Windows.Forms.Label();
            this.UsernameInfoTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.lOldEmail = new System.Windows.Forms.Label();
            this.tbOldEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lUsernameChange
            // 
            this.lUsernameChange.AutoSize = true;
            this.lUsernameChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lUsernameChange.Location = new System.Drawing.Point(100, 68);
            this.lUsernameChange.Name = "lUsernameChange";
            this.lUsernameChange.Size = new System.Drawing.Size(328, 37);
            this.lUsernameChange.TabIndex = 5;
            this.lUsernameChange.Text = "E-mail cím változtatás";
            // 
            // btnUNameChange
            // 
            this.btnUNameChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(197)))));
            this.btnUNameChange.FlatAppearance.BorderColor = System.Drawing.Color.Snow;
            this.btnUNameChange.FlatAppearance.BorderSize = 0;
            this.btnUNameChange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnUNameChange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnUNameChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUNameChange.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUNameChange.ForeColor = System.Drawing.Color.White;
            this.btnUNameChange.Location = new System.Drawing.Point(730, 425);
            this.btnUNameChange.Name = "btnUNameChange";
            this.btnUNameChange.Size = new System.Drawing.Size(203, 49);
            this.btnUNameChange.TabIndex = 3;
            this.btnUNameChange.Text = "Mentés";
            this.btnUNameChange.UseVisualStyleBackColor = false;
            this.btnUNameChange.Click += new System.EventHandler(this.btnUNameChange_Click);
            // 
            // tbNewEmailAgain
            // 
            this.tbNewEmailAgain.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNewEmailAgain.Location = new System.Drawing.Point(384, 326);
            this.tbNewEmailAgain.Name = "tbNewEmailAgain";
            this.tbNewEmailAgain.Size = new System.Drawing.Size(400, 26);
            this.tbNewEmailAgain.TabIndex = 2;
            // 
            // lNewEmail
            // 
            this.lNewEmail.AutoSize = true;
            this.lNewEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNewEmail.Location = new System.Drawing.Point(271, 258);
            this.lNewEmail.Name = "lNewEmail";
            this.lNewEmail.Size = new System.Drawing.Size(105, 21);
            this.lNewEmail.TabIndex = 7;
            this.lNewEmail.Text = "Új e-mail cím:";
            // 
            // tbNewEmail
            // 
            this.tbNewEmail.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNewEmail.Location = new System.Drawing.Point(384, 253);
            this.tbNewEmail.Name = "tbNewEmail";
            this.tbNewEmail.Size = new System.Drawing.Size(400, 26);
            this.tbNewEmail.TabIndex = 1;
            // 
            // lNewEmailAgain
            // 
            this.lNewEmailAgain.AutoSize = true;
            this.lNewEmailAgain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNewEmailAgain.Location = new System.Drawing.Point(183, 331);
            this.lNewEmailAgain.Name = "lNewEmailAgain";
            this.lNewEmailAgain.Size = new System.Drawing.Size(193, 21);
            this.lNewEmailAgain.TabIndex = 8;
            this.lNewEmailAgain.Text = "Új e-mail cím mégegyszer:";
            // 
            // lOldEmail
            // 
            this.lOldEmail.AutoSize = true;
            this.lOldEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lOldEmail.Location = new System.Drawing.Point(255, 180);
            this.lOldEmail.Name = "lOldEmail";
            this.lOldEmail.Size = new System.Drawing.Size(121, 21);
            this.lOldEmail.TabIndex = 6;
            this.lOldEmail.Text = "Régi e-mail cím:";
            // 
            // tbOldEmail
            // 
            this.tbOldEmail.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbOldEmail.Location = new System.Drawing.Point(384, 180);
            this.tbOldEmail.Name = "tbOldEmail";
            this.tbOldEmail.Size = new System.Drawing.Size(400, 26);
            this.tbOldEmail.TabIndex = 0;
            // 
            // EmailChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.lUsernameChange);
            this.Controls.Add(this.btnUNameChange);
            this.Controls.Add(this.tbNewEmailAgain);
            this.Controls.Add(this.lOldEmail);
            this.Controls.Add(this.lNewEmail);
            this.Controls.Add(this.tbNewEmail);
            this.Controls.Add(this.lNewEmailAgain);
            this.Controls.Add(this.tbOldEmail);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "EmailChange";
            this.Size = new System.Drawing.Size(1030, 535);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lUsernameChange;
        private System.Windows.Forms.Button btnUNameChange;
        private System.Windows.Forms.TextBox tbNewEmailAgain;
        private System.Windows.Forms.Label lNewEmail;
        private System.Windows.Forms.TextBox tbNewEmail;
        private System.Windows.Forms.Label lNewEmailAgain;
        private System.Windows.Forms.ToolTip UsernameInfoTooltip;
        private System.Windows.Forms.Label lOldEmail;
        private System.Windows.Forms.TextBox tbOldEmail;
    }
}
