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
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lTaskGroup = new System.Windows.Forms.Label();
            this.tbTaskName = new System.Windows.Forms.TextBox();
            this.lTaskName = new System.Windows.Forms.Label();
            this.lTaskID = new System.Windows.Forms.Label();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.gbGroupSection = new System.Windows.Forms.GroupBox();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.cbGroupName = new System.Windows.Forms.ComboBox();
            this.btnUpdateGroup = new System.Windows.Forms.Button();
            this.gbTaskSection = new System.Windows.Forms.GroupBox();
            this.nupTaskID = new System.Windows.Forms.NumericUpDown();
            this.tvGroupsAndTasks = new System.Windows.Forms.TreeView();
            this.gbGroupSection.SuspendLayout();
            this.gbTaskSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTaskID)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(99)))), ((int)(((byte)(12)))));
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(116)))), ((int)(((byte)(38)))));
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(116)))), ((int)(((byte)(38)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Image = global::emira.Properties.Resources.import_icon_white_26;
            this.btnImport.Location = new System.Drawing.Point(195, 20);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(130, 40);
            this.btnImport.TabIndex = 26;
            this.btnImport.Text = "Import";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(0)))), ((int)(((byte)(82)))));
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(25)))), ((int)(((byte)(109)))));
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(25)))), ((int)(((byte)(109)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Image = global::emira.Properties.Resources.export_icon_white_26;
            this.btnExport.Location = new System.Drawing.Point(40, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(130, 40);
            this.btnExport.TabIndex = 25;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lTaskGroup
            // 
            this.lTaskGroup.AutoSize = true;
            this.lTaskGroup.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTaskGroup.Location = new System.Drawing.Point(17, 61);
            this.lTaskGroup.Name = "lTaskGroup";
            this.lTaskGroup.Size = new System.Drawing.Size(92, 18);
            this.lTaskGroup.TabIndex = 24;
            this.lTaskGroup.Text = "Csoport név:";
            // 
            // tbTaskName
            // 
            this.tbTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbTaskName.Location = new System.Drawing.Point(125, 83);
            this.tbTaskName.Name = "tbTaskName";
            this.tbTaskName.Size = new System.Drawing.Size(336, 24);
            this.tbTaskName.TabIndex = 20;
            // 
            // lTaskName
            // 
            this.lTaskName.AutoSize = true;
            this.lTaskName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTaskName.Location = new System.Drawing.Point(16, 86);
            this.lTaskName.Name = "lTaskName";
            this.lTaskName.Size = new System.Drawing.Size(89, 18);
            this.lTaskName.TabIndex = 18;
            this.lTaskName.Text = "Feladat név:";
            // 
            // lTaskID
            // 
            this.lTaskID.AutoSize = true;
            this.lTaskID.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTaskID.Location = new System.Drawing.Point(17, 38);
            this.lTaskID.Name = "lTaskID";
            this.lTaskID.Size = new System.Drawing.Size(81, 18);
            this.lTaskID.TabIndex = 16;
            this.lTaskID.Text = "Feladat ID:";
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(52)))), ((int)(((byte)(56)))));
            this.btnDeleteTask.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteTask.FlatAppearance.BorderSize = 0;
            this.btnDeleteTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnDeleteTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteTask.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTask.Image = global::emira.Properties.Resources.delete_icon_white_26;
            this.btnDeleteTask.Location = new System.Drawing.Point(330, 135);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteTask.TabIndex = 23;
            this.btnDeleteTask.Text = "Töröl";
            this.btnDeleteTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(137)))), ((int)(((byte)(62)))));
            this.btnUpdateTask.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdateTask.FlatAppearance.BorderSize = 0;
            this.btnUpdateTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(106)))));
            this.btnUpdateTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(106)))));
            this.btnUpdateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTask.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUpdateTask.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTask.Image = global::emira.Properties.Resources.update_icon_white_26;
            this.btnUpdateTask.Location = new System.Drawing.Point(175, 135);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(130, 40);
            this.btnUpdateTask.TabIndex = 22;
            this.btnUpdateTask.Text = "Frissít";
            this.btnUpdateTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateTask.UseVisualStyleBackColor = false;
            this.btnUpdateTask.Click += new System.EventHandler(this.btnUpdateTask_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(131)))), ((int)(((byte)(135)))));
            this.btnAddTask.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddTask.FlatAppearance.BorderSize = 0;
            this.btnAddTask.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(183)))), ((int)(((byte)(195)))));
            this.btnAddTask.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(183)))), ((int)(((byte)(195)))));
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddTask.ForeColor = System.Drawing.Color.White;
            this.btnAddTask.Image = global::emira.Properties.Resources.add_task_icon_white_26;
            this.btnAddTask.Location = new System.Drawing.Point(20, 135);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(130, 40);
            this.btnAddTask.TabIndex = 21;
            this.btnAddTask.Text = "Hozzáad";
            this.btnAddTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // gbGroupSection
            // 
            this.gbGroupSection.Controls.Add(this.btnDeleteGroup);
            this.gbGroupSection.Controls.Add(this.btnAddGroup);
            this.gbGroupSection.Controls.Add(this.cbGroupName);
            this.gbGroupSection.Controls.Add(this.btnUpdateGroup);
            this.gbGroupSection.Controls.Add(this.lTaskGroup);
            this.gbGroupSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbGroupSection.Location = new System.Drawing.Point(20, 100);
            this.gbGroupSection.Name = "gbGroupSection";
            this.gbGroupSection.Size = new System.Drawing.Size(480, 200);
            this.gbGroupSection.TabIndex = 27;
            this.gbGroupSection.TabStop = false;
            this.gbGroupSection.Text = "Csoport";
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(52)))), ((int)(((byte)(56)))));
            this.btnDeleteGroup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeleteGroup.FlatAppearance.BorderSize = 0;
            this.btnDeleteGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnDeleteGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.btnDeleteGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteGroup.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDeleteGroup.ForeColor = System.Drawing.Color.White;
            this.btnDeleteGroup.Image = global::emira.Properties.Resources.delete_icon_white_26;
            this.btnDeleteGroup.Location = new System.Drawing.Point(331, 124);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteGroup.TabIndex = 27;
            this.btnDeleteGroup.Text = "Töröl";
            this.btnDeleteGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteGroup.UseVisualStyleBackColor = false;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(131)))), ((int)(((byte)(135)))));
            this.btnAddGroup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddGroup.FlatAppearance.BorderSize = 0;
            this.btnAddGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(183)))), ((int)(((byte)(195)))));
            this.btnAddGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(183)))), ((int)(((byte)(195)))));
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroup.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddGroup.ForeColor = System.Drawing.Color.White;
            this.btnAddGroup.Image = global::emira.Properties.Resources.add_task_icon_white_26;
            this.btnAddGroup.Location = new System.Drawing.Point(19, 124);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(130, 40);
            this.btnAddGroup.TabIndex = 25;
            this.btnAddGroup.Text = "Hozzáad";
            this.btnAddGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // cbGroupName
            // 
            this.cbGroupName.FormattingEnabled = true;
            this.cbGroupName.Location = new System.Drawing.Point(125, 58);
            this.cbGroupName.Name = "cbGroupName";
            this.cbGroupName.Size = new System.Drawing.Size(336, 26);
            this.cbGroupName.TabIndex = 28;
            this.cbGroupName.DropDownClosed += new System.EventHandler(this.cbGroupName_DropDownClosed);
            this.cbGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbGroupName_KeyPress);
            // 
            // btnUpdateGroup
            // 
            this.btnUpdateGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(137)))), ((int)(((byte)(62)))));
            this.btnUpdateGroup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUpdateGroup.FlatAppearance.BorderSize = 0;
            this.btnUpdateGroup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(106)))));
            this.btnUpdateGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(106)))));
            this.btnUpdateGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateGroup.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUpdateGroup.ForeColor = System.Drawing.Color.White;
            this.btnUpdateGroup.Image = global::emira.Properties.Resources.update_icon_white_26;
            this.btnUpdateGroup.Location = new System.Drawing.Point(175, 124);
            this.btnUpdateGroup.Name = "btnUpdateGroup";
            this.btnUpdateGroup.Size = new System.Drawing.Size(130, 40);
            this.btnUpdateGroup.TabIndex = 26;
            this.btnUpdateGroup.Text = "Frissít";
            this.btnUpdateGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateGroup.UseVisualStyleBackColor = false;
            this.btnUpdateGroup.Click += new System.EventHandler(this.btnUpdateGroup_Click);
            // 
            // gbTaskSection
            // 
            this.gbTaskSection.Controls.Add(this.nupTaskID);
            this.gbTaskSection.Controls.Add(this.tbTaskName);
            this.gbTaskSection.Controls.Add(this.lTaskName);
            this.gbTaskSection.Controls.Add(this.lTaskID);
            this.gbTaskSection.Controls.Add(this.btnDeleteTask);
            this.gbTaskSection.Controls.Add(this.btnAddTask);
            this.gbTaskSection.Controls.Add(this.btnUpdateTask);
            this.gbTaskSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbTaskSection.Location = new System.Drawing.Point(20, 316);
            this.gbTaskSection.Name = "gbTaskSection";
            this.gbTaskSection.Size = new System.Drawing.Size(480, 200);
            this.gbTaskSection.TabIndex = 25;
            this.gbTaskSection.TabStop = false;
            this.gbTaskSection.Text = "Feladat";
            // 
            // nupTaskID
            // 
            this.nupTaskID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nupTaskID.Location = new System.Drawing.Point(125, 36);
            this.nupTaskID.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nupTaskID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupTaskID.Name = "nupTaskID";
            this.nupTaskID.Size = new System.Drawing.Size(83, 24);
            this.nupTaskID.TabIndex = 24;
            this.nupTaskID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupTaskID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nupTaskID_KeyPress);
            // 
            // tvGroupsAndTasks
            // 
            this.tvGroupsAndTasks.BackColor = System.Drawing.SystemColors.Window;
            this.tvGroupsAndTasks.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.tvGroupsAndTasks.Location = new System.Drawing.Point(520, 20);
            this.tvGroupsAndTasks.Name = "tvGroupsAndTasks";
            this.tvGroupsAndTasks.Size = new System.Drawing.Size(490, 496);
            this.tvGroupsAndTasks.TabIndex = 28;
            this.tvGroupsAndTasks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvGroupsAndTasks_AfterSelect);
            // 
            // TaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tvGroupsAndTasks);
            this.Controls.Add(this.gbTaskSection);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gbGroupSection);
            this.Name = "TaskManager";
            this.Size = new System.Drawing.Size(1030, 535);
            this.Load += new System.EventHandler(this.TaskManager_Load);
            this.gbGroupSection.ResumeLayout(false);
            this.gbGroupSection.PerformLayout();
            this.gbTaskSection.ResumeLayout(false);
            this.gbTaskSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTaskID)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lTaskGroup;
        private System.Windows.Forms.TextBox tbTaskName;
        private System.Windows.Forms.Label lTaskName;
        private System.Windows.Forms.Label lTaskID;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnUpdateTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.GroupBox gbGroupSection;
        private System.Windows.Forms.GroupBox gbTaskSection;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.ComboBox cbGroupName;
        private System.Windows.Forms.Button btnUpdateGroup;
        private System.Windows.Forms.NumericUpDown nupTaskID;
        private System.Windows.Forms.TreeView tvGroupsAndTasks;
    }
}
