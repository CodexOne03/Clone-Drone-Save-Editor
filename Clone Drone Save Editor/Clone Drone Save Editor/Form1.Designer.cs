namespace Clone_Drone_Save_Editor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Output = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SetValue = new System.Windows.Forms.Button();
            this.fileSelector = new System.Windows.Forms.OpenFileDialog();
            this.apply = new System.Windows.Forms.Button();
            this.selectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.SystemColors.Control;
            this.Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Output.Location = new System.Drawing.Point(12, 12);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Output.Size = new System.Drawing.Size(264, 78);
            this.Output.TabIndex = 0;
            this.Output.MouseLeave += new System.EventHandler(this.Output_MouseLeave);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(282, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 43);
            this.listBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(408, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 2;
            // 
            // SetValue
            // 
            this.SetValue.Location = new System.Drawing.Point(408, 38);
            this.SetValue.Name = "SetValue";
            this.SetValue.Size = new System.Drawing.Size(62, 23);
            this.SetValue.TabIndex = 3;
            this.SetValue.Text = "Set Value";
            this.SetValue.UseVisualStyleBackColor = true;
            this.SetValue.Click += new System.EventHandler(this.SetValue_Click);
            // 
            // fileSelector
            // 
            this.fileSelector.FileName = "openFileDialog1";
            this.fileSelector.FileOk += new System.ComponentModel.CancelEventHandler(this.fileSelector_FileOk);
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(408, 67);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(62, 23);
            this.apply.TabIndex = 4;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(282, 67);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(120, 23);
            this.selectFile.TabIndex = 5;
            this.selectFile.Text = "Select File";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 96);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.SetValue);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Output);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Clone Drone in the Danger Zone Save Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SetValue;
        private System.Windows.Forms.OpenFileDialog fileSelector;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button selectFile;
    }
}

