using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityEngine;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CloneDroneSaveEditor
{
    public partial class HighScoreDataEditor : Form
    {
        public List<HighScoreData> DataCollection = new List<HighScoreData>();

        private string file;

        public HighScoreDataEditor()
        {
            InitializeComponent();
            file = "";
            this.fileNameLabel.Text = "File:";
            this.levelReachedNumericUpDown.Value = 0;
            this.firstNameTextBox.Text = "";
            this.lastNameTextBox.Text = "";
            this.occupationTextBox.Text = "";
            this.genderComboBox.SelectedIndex = 0;
            this.ageNumericUpDown.Value = 0;
        }

        public HighScoreDataEditor(string file)
        {
            InitializeComponent();
            this.file = file;
            this.DataCollection = new List<HighScoreData>();
            this.DataCollection.Add(new HighScoreData() { HumanFacts = new HumanFactSet() });
            this.fileNameLabel.Text = "File: " + file;
            this.levelReachedNumericUpDown.Value = 0;
            this.firstNameTextBox.Text = "";
            this.lastNameTextBox.Text = "";
            this.occupationTextBox.Text = "";
            this.genderComboBox.SelectedIndex = 0;
            this.ageNumericUpDown.Value = 0;
        }

        public HighScoreDataEditor(string file, List<HighScoreData> data)
        {
            InitializeComponent();
            this.file = file;
            this.DataCollection = data;
            this.fileNameLabel.Text = "File: " + file;
            itemNumericUpDown.Minimum = 0;
            itemNumericUpDown.Maximum = data.Count - 1;
            itemNumericUpDown.Value = 0;
            LoadItemData(0);
        }

        private void LoadItemData(int index)
        {
            this.levelReachedNumericUpDown.Value = DataCollection[index].LevelReached;
            this.firstNameTextBox.Text = DataCollection[index].HumanFacts.FirstName;
            this.lastNameTextBox.Text = DataCollection[index].HumanFacts.LastName;
            this.occupationTextBox.Text = DataCollection[index].HumanFacts.Occupation;
            this.genderComboBox.SelectedIndex = DataCollection[index].HumanFacts.GenderIsFemale == false ? 0 : 1;
            this.ageNumericUpDown.Value = DataCollection[index].HumanFacts.Age;
            this.favouriteColorNumericUpDown.Value = DataCollection[index].HumanFacts.FavouriteColorIndex;
        }

        private void itemNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LoadItemData((int)itemNumericUpDown.Value);
        }

        private void discardButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure that you want to save? All the old data from this file will be overwritten.", "Save", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (var item in this.DataCollection)
                {
                    item.LevelReached = (int)this.levelReachedNumericUpDown.Value;
                    item.HumanFacts.FirstName = this.firstNameTextBox.Text;
                    item.HumanFacts.LastName = this.lastNameTextBox.Text;
                    item.HumanFacts.Occupation = this.occupationTextBox.Text;
                    item.HumanFacts.GenderIsFemale = this.genderComboBox.SelectedIndex == 2 ? true : false;
                    item.HumanFacts.Age = (int)this.ageNumericUpDown.Value;
                    item.HumanFacts.FavouriteColorIndex = (int)this.favouriteColorNumericUpDown.Value;
                }
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", @"LocalLow\Doborog\Clone Drone in the Danger Zone") + "\\" + file, JsonConvert.SerializeObject(this.DataCollection));
                this.Close();
            }
        }
    }
}
