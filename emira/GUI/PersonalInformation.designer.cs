namespace emira.GUI
{
    partial class PersonalInformation
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
            this.tlpPersonalInformation = new System.Windows.Forms.TableLayoutPanel();
            this.lPositionFromDatabase = new System.Windows.Forms.Label();
            this.lCostCenterFromDatabase = new System.Windows.Forms.Label();
            this.lRegisterNumber = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.lCompany = new System.Windows.Forms.Label();
            this.lCostCenter = new System.Windows.Forms.Label();
            this.lPosition = new System.Windows.Forms.Label();
            this.lNameFromDatabase = new System.Windows.Forms.Label();
            this.lRegisterNumberFromDatabase = new System.Windows.Forms.Label();
            this.lCompanyFromDatabase = new System.Windows.Forms.Label();
            this.lPersonalInformation = new System.Windows.Forms.Label();
            this.btnChangeData = new System.Windows.Forms.Button();
            this.tlpPersonalInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPersonalInformation
            // 
            this.tlpPersonalInformation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpPersonalInformation.ColumnCount = 2;
            this.tlpPersonalInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.23961F));
            this.tlpPersonalInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.76039F));
            this.tlpPersonalInformation.Controls.Add(this.lPositionFromDatabase, 1, 4);
            this.tlpPersonalInformation.Controls.Add(this.lCostCenterFromDatabase, 1, 3);
            this.tlpPersonalInformation.Controls.Add(this.lRegisterNumber, 0, 1);
            this.tlpPersonalInformation.Controls.Add(this.lName, 0, 0);
            this.tlpPersonalInformation.Controls.Add(this.lCompany, 0, 2);
            this.tlpPersonalInformation.Controls.Add(this.lCostCenter, 0, 3);
            this.tlpPersonalInformation.Controls.Add(this.lPosition, 0, 4);
            this.tlpPersonalInformation.Controls.Add(this.lNameFromDatabase, 1, 0);
            this.tlpPersonalInformation.Controls.Add(this.lRegisterNumberFromDatabase, 1, 1);
            this.tlpPersonalInformation.Controls.Add(this.lCompanyFromDatabase, 1, 2);
            this.tlpPersonalInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tlpPersonalInformation.Location = new System.Drawing.Point(115, 158);
            this.tlpPersonalInformation.Name = "tlpPersonalInformation";
            this.tlpPersonalInformation.RowCount = 5;
            this.tlpPersonalInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPersonalInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPersonalInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPersonalInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPersonalInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPersonalInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPersonalInformation.Size = new System.Drawing.Size(831, 219);
            this.tlpPersonalInformation.TabIndex = 1;
            this.tlpPersonalInformation.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpPersonalInformation_Paint);
            // 
            // lPositionFromDatabase
            // 
            this.lPositionFromDatabase.AutoSize = true;
            this.lPositionFromDatabase.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPositionFromDatabase.Location = new System.Drawing.Point(237, 172);
            this.lPositionFromDatabase.Name = "lPositionFromDatabase";
            this.lPositionFromDatabase.Size = new System.Drawing.Size(92, 25);
            this.lPositionFromDatabase.TabIndex = 4;
            this.lPositionFromDatabase.Text = "Unknown";
            // 
            // lCostCenterFromDatabase
            // 
            this.lCostCenterFromDatabase.AutoSize = true;
            this.lCostCenterFromDatabase.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lCostCenterFromDatabase.Location = new System.Drawing.Point(237, 129);
            this.lCostCenterFromDatabase.Name = "lCostCenterFromDatabase";
            this.lCostCenterFromDatabase.Size = new System.Drawing.Size(92, 25);
            this.lCostCenterFromDatabase.TabIndex = 3;
            this.lCostCenterFromDatabase.Text = "Unknown";
            // 
            // lRegisterNumber
            // 
            this.lRegisterNumber.AutoSize = true;
            this.lRegisterNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lRegisterNumber.Location = new System.Drawing.Point(3, 43);
            this.lRegisterNumber.Name = "lRegisterNumber";
            this.lRegisterNumber.Size = new System.Drawing.Size(150, 25);
            this.lRegisterNumber.TabIndex = 6;
            this.lRegisterNumber.Text = "Register number";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lName.Location = new System.Drawing.Point(3, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(62, 25);
            this.lName.TabIndex = 5;
            this.lName.Text = "Name";
            // 
            // lCompany
            // 
            this.lCompany.AutoSize = true;
            this.lCompany.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lCompany.Location = new System.Drawing.Point(3, 86);
            this.lCompany.Name = "lCompany";
            this.lCompany.Size = new System.Drawing.Size(92, 25);
            this.lCompany.TabIndex = 7;
            this.lCompany.Text = "Company";
            // 
            // lCostCenter
            // 
            this.lCostCenter.AutoSize = true;
            this.lCostCenter.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lCostCenter.Location = new System.Drawing.Point(3, 129);
            this.lCostCenter.Name = "lCostCenter";
            this.lCostCenter.Size = new System.Drawing.Size(107, 25);
            this.lCostCenter.TabIndex = 8;
            this.lCostCenter.Text = "Cost center";
            // 
            // lPosition
            // 
            this.lPosition.AutoSize = true;
            this.lPosition.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPosition.Location = new System.Drawing.Point(3, 172);
            this.lPosition.Name = "lPosition";
            this.lPosition.Size = new System.Drawing.Size(79, 25);
            this.lPosition.TabIndex = 9;
            this.lPosition.Text = "Position";
            // 
            // lNameFromDatabase
            // 
            this.lNameFromDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lNameFromDatabase.AutoSize = true;
            this.lNameFromDatabase.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNameFromDatabase.Location = new System.Drawing.Point(237, 0);
            this.lNameFromDatabase.Name = "lNameFromDatabase";
            this.lNameFromDatabase.Size = new System.Drawing.Size(591, 25);
            this.lNameFromDatabase.TabIndex = 0;
            this.lNameFromDatabase.Text = "Unknown";
            // 
            // lRegisterNumberFromDatabase
            // 
            this.lRegisterNumberFromDatabase.AutoSize = true;
            this.lRegisterNumberFromDatabase.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lRegisterNumberFromDatabase.Location = new System.Drawing.Point(237, 43);
            this.lRegisterNumberFromDatabase.Name = "lRegisterNumberFromDatabase";
            this.lRegisterNumberFromDatabase.Size = new System.Drawing.Size(92, 25);
            this.lRegisterNumberFromDatabase.TabIndex = 1;
            this.lRegisterNumberFromDatabase.Text = "Unknown";
            // 
            // lCompanyFromDatabase
            // 
            this.lCompanyFromDatabase.AutoSize = true;
            this.lCompanyFromDatabase.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lCompanyFromDatabase.Location = new System.Drawing.Point(237, 86);
            this.lCompanyFromDatabase.Name = "lCompanyFromDatabase";
            this.lCompanyFromDatabase.Size = new System.Drawing.Size(92, 25);
            this.lCompanyFromDatabase.TabIndex = 2;
            this.lCompanyFromDatabase.Text = "Unknown";
            // 
            // lPersonalInformation
            // 
            this.lPersonalInformation.AutoSize = true;
            this.lPersonalInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lPersonalInformation.Location = new System.Drawing.Point(109, 68);
            this.lPersonalInformation.Name = "lPersonalInformation";
            this.lPersonalInformation.Size = new System.Drawing.Size(312, 37);
            this.lPersonalInformation.TabIndex = 2;
            this.lPersonalInformation.Text = "Personal information";
            // 
            // btnChangeData
            // 
            this.btnChangeData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(197)))));
            this.btnChangeData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnChangeData.FlatAppearance.BorderSize = 0;
            this.btnChangeData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnChangeData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnChangeData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeData.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnChangeData.ForeColor = System.Drawing.Color.White;
            this.btnChangeData.Location = new System.Drawing.Point(743, 425);
            this.btnChangeData.Name = "btnChangeData";
            this.btnChangeData.Size = new System.Drawing.Size(203, 49);
            this.btnChangeData.TabIndex = 0;
            this.btnChangeData.Text = "Change data";
            this.btnChangeData.UseVisualStyleBackColor = false;
            this.btnChangeData.Click += new System.EventHandler(this.btnChangeData_Click);
            // 
            // PersonalInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.btnChangeData);
            this.Controls.Add(this.lPersonalInformation);
            this.Controls.Add(this.tlpPersonalInformation);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PersonalInformation";
            this.Size = new System.Drawing.Size(1030, 535);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpPersonalInformation_Paint);
            this.tlpPersonalInformation.ResumeLayout(false);
            this.tlpPersonalInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPersonalInformation;
        private System.Windows.Forms.Label lPositionFromDatabase;
        private System.Windows.Forms.Label lCostCenterFromDatabase;
        private System.Windows.Forms.Label lRegisterNumber;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lCompany;
        private System.Windows.Forms.Label lCostCenter;
        private System.Windows.Forms.Label lPosition;
        private System.Windows.Forms.Label lNameFromDatabase;
        private System.Windows.Forms.Label lRegisterNumberFromDatabase;
        private System.Windows.Forms.Label lCompanyFromDatabase;
        private System.Windows.Forms.Label lPersonalInformation;
        private System.Windows.Forms.Button btnChangeData;
    }
}
