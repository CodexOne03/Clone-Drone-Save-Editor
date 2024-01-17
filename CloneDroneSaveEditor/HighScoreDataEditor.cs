using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public HighScoreDataEditor()
        {
            InitializeComponent();
            this.fileNameLabel.Text = "File:";
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
            this.genderComboBox.SelectedIndex = DataCollection[index].HumanFacts.GenderIsFemale == false ? 2 : 1;
            this.ageNumericUpDown.Value = DataCollection[index].HumanFacts.Age;
            this.favouriteColorNumericUpDown.Value = DataCollection[index].HumanFacts.FavouriteColorIndex;
        }

        private void itemNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LoadItemData((int)itemNumericUpDown.Value);
        }
    }
}
