namespace emira.GUI
{
    partial class AddOrUpdateGroupForm
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
            this.lGroupID = new System.Windows.Forms.Label();
            this.lGroupName = new System.Windows.Forms.Label();
            this.nupGroupID = new System.Windows.Forms.NumericUpDown();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lAddOrUpdateGroup = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nupGroupID)).BeginInit();
            this.pHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lGroupID
            // 
            this.lGroupID.AutoSize = true;
            this.lGroupID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lGroupID.Location = new System.Drawing.Point(40, 60);
            this.lGroupID.Name = "lGroupID";
            this.lGroupID.Size = new System.Drawing.Size(84, 18);
            this.lGroupID.TabIndex = 4;
            this.lGroupID.Text = "Csoport ID:";
            // 
            // lGroupName
            // 
            this.lGroupName.AutoSize = true;
            this.lGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lGroupName.Location = new System.Drawing.Point(40, 100);
            this.lGroupName.Name = "lGroupName";
            this.lGroupName.Size = new System.Drawing.Size(89, 18);
            this.lGroupName.TabIndex = 5;
            this.lGroupName.Text = "Csoportnév:";
            // 
            // nupGroupID
            // 
            this.nupGroupID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nupGroupID.Location = new System.Drawing.Point(141, 58);
            this.nupGroupID.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nupGroupID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupGroupID.Name = "nupGroupID";
            this.nupGroupID.Size = new System.Drawing.Size(98, 24);
            this.nupGroupID.TabIndex = 0;
            this.nupGroupID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupGroupID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupGroupID_KeyPress);
            // 
            // btnAction
            // 
            this.btnAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(193)))));
            this.btnAction.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAction.FlatAppearance.BorderSize = 0;
            this.btnAction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnAction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.btnAction.ForeColor = System.Drawing.Color.White;
            this.btnAction.Location = new System.Drawing.Point(100, 148);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(110, 30);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "Hozzáad";
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(290, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Mégse";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbGroupName
            // 
            this.tbGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbGroupName.Location = new System.Drawing.Point(141, 97);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(300, 24);
            this.tbGroupName.TabIndex = 1;
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(184)))));
            this.pHeader.Controls.Add(this.lAddOrUpdateGroup);
            this.pHeader.Controls.Add(this.btnExit);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(500, 30);
            this.pHeader.TabIndex = 7;
            this.pHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseDown);
            this.pHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseMove);
            this.pHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pHeader_MouseUp);
            // 
            // lAddOrUpdateGroup
            // 
            this.lAddOrUpdateGroup.AutoSize = true;
            this.lAddOrUpdateGroup.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lAddOrUpdateGroup.ForeColor = System.Drawing.Color.White;
            this.lAddOrUpdateGroup.Location = new System.Drawing.Point(0, 0);
            this.lAddOrUpdateGroup.Name = "lAddOrUpdateGroup";
            this.lAddOrUpdateGroup.Size = new System.Drawing.Size(188, 28);
            this.lAddOrUpdateGroup.TabIndex = 1;
            this.lAddOrUpdateGroup.Text = "Csoport hozzáadása";
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
            this.btnExit.Location = new System.Drawing.Point(450, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 30);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // AddOrUpdateGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 200);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.tbGroupName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.nupGroupID);
            this.Controls.Add(this.lGroupName);
            this.Controls.Add(this.lGroupID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddOrUpdateGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddModifyGroupForm";
            this.Load += new System.EventHandler(this.AddOrUpdateGroupPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupGroupID)).EndInit();
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lGroupID;
        private System.Windows.Forms.Label lGroupName;
        private System.Windows.Forms.NumericUpDown nupGroupID;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbGroupName;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lAddOrUpdateGroup;
    }
}