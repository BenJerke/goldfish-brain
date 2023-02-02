namespace GoldfishBrain
{
    partial class GoldfishBrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoldfishBrain));
            this.submitButton = new System.Windows.Forms.Button();
            this.activeTaskLabel = new System.Windows.Forms.Label();
            this.taskEntryTextBox = new System.Windows.Forms.TextBox();
            this.projectEntryTextBox = new System.Windows.Forms.TextBox();
            this.taskLabel = new System.Windows.Forms.Label();
            this.projectLabel = new System.Windows.Forms.Label();
            this.activeProjectLabel = new System.Windows.Forms.Label();
            this.completeTaskButton = new System.Windows.Forms.Button();
            this.cancelTaskButton = new System.Windows.Forms.Button();
            this.submitTaskAndSwitchButton = new System.Windows.Forms.Button();
            this.switchTaskButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(54, 149);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(121, 23);
            this.submitButton.TabIndex = 7;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // activeTaskLabel
            // 
            this.activeTaskLabel.AutoEllipsis = true;
            this.activeTaskLabel.AutoSize = true;
            this.activeTaskLabel.BackColor = System.Drawing.SystemColors.Control;
            this.activeTaskLabel.Enabled = false;
            this.activeTaskLabel.Font = new System.Drawing.Font("Bahnschrift", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeTaskLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.activeTaskLabel.Location = new System.Drawing.Point(8, 9);
            this.activeTaskLabel.Name = "activeTaskLabel";
            this.activeTaskLabel.Size = new System.Drawing.Size(104, 20);
            this.activeTaskLabel.TabIndex = 10;
            this.activeTaskLabel.Text = "<<active task>>";
            this.activeTaskLabel.UseCompatibleTextRendering = true;
            this.activeTaskLabel.Click += new System.EventHandler(this.activeTaskLabel_Click_1);
            // 
            // taskEntryTextBox
            // 
            this.taskEntryTextBox.Location = new System.Drawing.Point(54, 97);
            this.taskEntryTextBox.Name = "taskEntryTextBox";
            this.taskEntryTextBox.Size = new System.Drawing.Size(237, 20);
            this.taskEntryTextBox.TabIndex = 4;
            // 
            // projectEntryTextBox
            // 
            this.projectEntryTextBox.Location = new System.Drawing.Point(54, 123);
            this.projectEntryTextBox.Name = "projectEntryTextBox";
            this.projectEntryTextBox.Size = new System.Drawing.Size(237, 20);
            this.projectEntryTextBox.TabIndex = 6;
            // 
            // taskLabel
            // 
            this.taskLabel.AutoSize = true;
            this.taskLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taskLabel.Location = new System.Drawing.Point(14, 97);
            this.taskLabel.Name = "taskLabel";
            this.taskLabel.Size = new System.Drawing.Size(34, 13);
            this.taskLabel.TabIndex = 5;
            this.taskLabel.Text = "Task:";
            // 
            // projectLabel
            // 
            this.projectLabel.AutoSize = true;
            this.projectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectLabel.Location = new System.Drawing.Point(5, 123);
            this.projectLabel.Name = "projectLabel";
            this.projectLabel.Size = new System.Drawing.Size(43, 13);
            this.projectLabel.TabIndex = 6;
            this.projectLabel.Text = "Project:";
            // 
            // activeProjectLabel
            // 
            this.activeProjectLabel.AutoEllipsis = true;
            this.activeProjectLabel.AutoSize = true;
            this.activeProjectLabel.Enabled = false;
            this.activeProjectLabel.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activeProjectLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.activeProjectLabel.Location = new System.Drawing.Point(8, 45);
            this.activeProjectLabel.Name = "activeProjectLabel";
            this.activeProjectLabel.Size = new System.Drawing.Size(125, 20);
            this.activeProjectLabel.TabIndex = 9;
            this.activeProjectLabel.Text = "<<active project>>";
            this.activeProjectLabel.UseCompatibleTextRendering = true;
            // 
            // completeTaskButton
            // 
            this.completeTaskButton.Location = new System.Drawing.Point(54, 68);
            this.completeTaskButton.Name = "completeTaskButton";
            this.completeTaskButton.Size = new System.Drawing.Size(75, 23);
            this.completeTaskButton.TabIndex = 1;
            this.completeTaskButton.Text = "Done";
            this.completeTaskButton.UseVisualStyleBackColor = true;
            this.completeTaskButton.Click += new System.EventHandler(this.completeTaskButton_Click);
            // 
            // cancelTaskButton
            // 
            this.cancelTaskButton.Location = new System.Drawing.Point(216, 68);
            this.cancelTaskButton.Name = "cancelTaskButton";
            this.cancelTaskButton.Size = new System.Drawing.Size(75, 23);
            this.cancelTaskButton.TabIndex = 3;
            this.cancelTaskButton.Text = "Cancel";
            this.cancelTaskButton.UseVisualStyleBackColor = true;
            this.cancelTaskButton.Click += new System.EventHandler(this.cancelTaskButton_Click);
            // 
            // submitTaskAndSwitchButton
            // 
            this.submitTaskAndSwitchButton.Location = new System.Drawing.Point(181, 149);
            this.submitTaskAndSwitchButton.Name = "submitTaskAndSwitchButton";
            this.submitTaskAndSwitchButton.Size = new System.Drawing.Size(110, 23);
            this.submitTaskAndSwitchButton.TabIndex = 8;
            this.submitTaskAndSwitchButton.Text = "Submit and Switch";
            this.submitTaskAndSwitchButton.UseVisualStyleBackColor = true;
            this.submitTaskAndSwitchButton.Click += new System.EventHandler(this.submitTaskAndSwitchButton_Click);
            // 
            // switchTaskButton
            // 
            this.switchTaskButton.Location = new System.Drawing.Point(135, 68);
            this.switchTaskButton.Name = "switchTaskButton";
            this.switchTaskButton.Size = new System.Drawing.Size(75, 23);
            this.switchTaskButton.TabIndex = 2;
            this.switchTaskButton.Text = "Switch";
            this.switchTaskButton.UseVisualStyleBackColor = true;
            this.switchTaskButton.Click += new System.EventHandler(this.switchTaskButton_Click);
            // 
            // GoldfishBrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 180);
            this.Controls.Add(this.submitTaskAndSwitchButton);
            this.Controls.Add(this.cancelTaskButton);
            this.Controls.Add(this.switchTaskButton);
            this.Controls.Add(this.completeTaskButton);
            this.Controls.Add(this.activeProjectLabel);
            this.Controls.Add(this.projectLabel);
            this.Controls.Add(this.taskLabel);
            this.Controls.Add(this.projectEntryTextBox);
            this.Controls.Add(this.taskEntryTextBox);
            this.Controls.Add(this.activeTaskLabel);
            this.Controls.Add(this.submitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GoldfishBrain";
            this.ShowIcon = false;
            this.Text = "Goldfish Brain";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GoldfishBrain_FormClosed);
            this.Load += new System.EventHandler(this.GoldfishBrain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label activeTaskLabel;
        private System.Windows.Forms.TextBox taskEntryTextBox;
        private System.Windows.Forms.TextBox projectEntryTextBox;
        private System.Windows.Forms.Label taskLabel;
        private System.Windows.Forms.Label projectLabel;
        private System.Windows.Forms.Label activeProjectLabel;
        private System.Windows.Forms.Button completeTaskButton;
        private System.Windows.Forms.Button cancelTaskButton;
        private System.Windows.Forms.Button submitTaskAndSwitchButton;
        private System.Windows.Forms.Button switchTaskButton;
    }
}

