namespace emira.GUI
{
    partial class TaskManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTaskManager = new System.Windows.Forms.DataGridView();
            this.btnTaskModification = new System.Windows.Forms.Button();
            this.lTaskManager = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskManager)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTaskManager
            // 
            this.dgvTaskManager.AllowUserToAddRows = false;
            this.dgvTaskManager.AllowUserToDeleteRows = false;
            this.dgvTaskManager.AllowUserToOrderColumns = true;
            this.dgvTaskManager.AllowUserToResizeColumns = false;
            this.dgvTaskManager.AllowUserToResizeRows = false;
            this.dgvTaskManager.BackgroundColor = System.Drawing.Color.White;
            this.dgvTaskManager.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTaskManager.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaskManager.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaskManager.Cursor = System.Windows.Forms.Cursors.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaskManager.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaskManager.EnableHeadersVisualStyles = false;
            this.dgvTaskManager.Location = new System.Drawing.Point(46, 101);
            this.dgvTaskManager.Name = "dgvTaskManager";
            this.dgvTaskManager.ReadOnly = true;
            this.dgvTaskManager.RowHeadersVisible = false;
            this.dgvTaskManager.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTaskManager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaskManager.Size = new System.Drawing.Size(942, 409);
            this.dgvTaskManager.TabIndex = 1;
            this.dgvTaskManager.VirtualMode = true;
            // 
            // btnTaskModification
            // 
            this.btnTaskModification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(133)))), ((int)(((byte)(197)))));
            this.btnTaskModification.FlatAppearance.BorderSize = 0;
            this.btnTaskModification.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnTaskModification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(144)))), ((int)(((byte)(195)))));
            this.btnTaskModification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskModification.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnTaskModification.ForeColor = System.Drawing.Color.White;
            this.btnTaskModification.Location = new System.Drawing.Point(759, 38);
            this.btnTaskModification.Name = "btnTaskModification";
            this.btnTaskModification.Size = new System.Drawing.Size(229, 49);
            this.btnTaskModification.TabIndex = 0;
            this.btnTaskModification.Text = "Tasks modification";
            this.btnTaskModification.UseVisualStyleBackColor = false;
            this.btnTaskModification.Click += new System.EventHandler(this.btnTaskModification_Click);
            // 
            // lTaskManager
            // 
            this.lTaskManager.AutoSize = true;
            this.lTaskManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTaskManager.Location = new System.Drawing.Point(40, 42);
            this.lTaskManager.Name = "lTaskManager";
            this.lTaskManager.Size = new System.Drawing.Size(223, 37);
            this.lTaskManager.TabIndex = 2;
            this.lTaskManager.Text = "Task manager";
            // 
            // TaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.lTaskManager);
            this.Controls.Add(this.dgvTaskManager);
            this.Controls.Add(this.btnTaskModification);
            this.Name = "TaskManager";
            this.Size = new System.Drawing.Size(1030, 535);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTaskManager;
        private System.Windows.Forms.Button btnTaskModification;
        private System.Windows.Forms.Label lTaskManager;      
    }
}
