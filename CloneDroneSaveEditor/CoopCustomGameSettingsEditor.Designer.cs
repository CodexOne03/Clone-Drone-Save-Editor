namespace CloneDroneSaveEditor
{
    partial class CoopCustomGameSettingsEditor
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
            this.startingTierLabel = new System.Windows.Forms.Label();
            this.startingTierListBox = new System.Windows.Forms.ListBox();
            this.friendlyFireLabel = new System.Windows.Forms.Label();
            this.friendlyFireCheckBox = new System.Windows.Forms.CheckBox();
            this.startSkillPointsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startSkillPointsLabel = new System.Windows.Forms.Label();
            this.fileLabel = new System.Windows.Forms.Label();
            this.discardButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startSkillPointsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // startingTierLabel
            // 
            this.startingTierLabel.AutoSize = true;
            this.startingTierLabel.Location = new System.Drawing.Point(12, 24);
            this.startingTierLabel.Name = "startingTierLabel";
            this.startingTierLabel.Size = new System.Drawing.Size(71, 15);
            this.startingTierLabel.TabIndex = 0;
            this.startingTierLabel.Text = "Starting tier:";
            // 
            // startingTierListBox
            // 
            this.startingTierListBox.FormattingEnabled = true;
            this.startingTierListBox.ItemHeight = 15;
            this.startingTierListBox.Location = new System.Drawing.Point(121, 24);
            this.startingTierListBox.Name = "startingTierListBox";
            this.startingTierListBox.Size = new System.Drawing.Size(120, 94);
            this.startingTierListBox.TabIndex = 1;
            // 
            // friendlyFireLabel
            // 
            this.friendlyFireLabel.AutoSize = true;
            this.friendlyFireLabel.Location = new System.Drawing.Point(12, 123);
            this.friendlyFireLabel.Name = "friendlyFireLabel";
            this.friendlyFireLabel.Size = new System.Drawing.Size(72, 15);
            this.friendlyFireLabel.TabIndex = 2;
            this.friendlyFireLabel.Text = "Friendly fire:";
            // 
            // friendlyFireCheckBox
            // 
            this.friendlyFireCheckBox.AutoSize = true;
            this.friendlyFireCheckBox.Location = new System.Drawing.Point(121, 124);
            this.friendlyFireCheckBox.Name = "friendlyFireCheckBox";
            this.friendlyFireCheckBox.Size = new System.Drawing.Size(15, 14);
            this.friendlyFireCheckBox.TabIndex = 3;
            this.friendlyFireCheckBox.UseVisualStyleBackColor = true;
            // 
            // startSkillPointsNumericUpDown
            // 
            this.startSkillPointsNumericUpDown.Location = new System.Drawing.Point(121, 144);
            this.startSkillPointsNumericUpDown.Name = "startSkillPointsNumericUpDown";
            this.startSkillPointsNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.startSkillPointsNumericUpDown.TabIndex = 4;
            // 
            // startSkillPointsLabel
            // 
            this.startSkillPointsLabel.AutoSize = true;
            this.startSkillPointsLabel.Location = new System.Drawing.Point(12, 146);
            this.startSkillPointsLabel.Name = "startSkillPointsLabel";
            this.startSkillPointsLabel.Size = new System.Drawing.Size(93, 15);
            this.startSkillPointsLabel.TabIndex = 5;
            this.startSkillPointsLabel.Text = "Start skill points:";
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(12, 9);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(28, 15);
            this.fileLabel.TabIndex = 6;
            this.fileLabel.Text = "File:";
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(166, 173);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(75, 23);
            this.discardButton.TabIndex = 7;
            this.discardButton.Text = "Discard";
            this.discardButton.UseVisualStyleBackColor = true;
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 173);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // CoopCustomGameSettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.startSkillPointsLabel);
            this.Controls.Add(this.startSkillPointsNumericUpDown);
            this.Controls.Add(this.friendlyFireCheckBox);
            this.Controls.Add(this.friendlyFireLabel);
            this.Controls.Add(this.startingTierListBox);
            this.Controls.Add(this.startingTierLabel);
            this.Name = "CoopCustomGameSettingsEditor";
            this.Text = "CoopCustomGameSettingsEditor";
            ((System.ComponentModel.ISupportInitialize)(this.startSkillPointsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label startingTierLabel;
        private ListBox startingTierListBox;
        private Label friendlyFireLabel;
        private CheckBox friendlyFireCheckBox;
        private NumericUpDown startSkillPointsNumericUpDown;
        private Label startSkillPointsLabel;
        private Label fileLabel;
        private Button discardButton;
        private Button saveButton;
    }
}