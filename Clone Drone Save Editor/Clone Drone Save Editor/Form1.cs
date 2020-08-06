using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clone_Drone_Save_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileSelector.ShowDialog();
        }

        private void fileSelector_FileOk(object sender, CancelEventArgs e)
        {
            Output.Text = File.ReadAllText(fileSelector.FileName);
        }

        private void Output_MouseLeave(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(Output.SelectedText);
        }

        public void ReplaceSelectedText()
        {
            string textToReplace = Output.SelectedText;
            int startOfSelection = Output.SelectionStart;
            int selectionCount = Output.SelectionLength;
            Output.Text = Output.Text.Remove(startOfSelection, selectionCount);
            Output.Text = Output.Text.Insert(startOfSelection, textBox1.Text);
        }

        private void SetValue_Click(object sender, EventArgs e)
        {
            ReplaceSelectedText();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            File.WriteAllText(fileSelector.FileName, Output.Text);
            File.Copy(fileSelector.FileName, fileSelector.FileName + ".bak", true);
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            fileSelector.ShowDialog();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Output.Height = Form1.ActiveForm.Height - 60;
        }
    }
}
