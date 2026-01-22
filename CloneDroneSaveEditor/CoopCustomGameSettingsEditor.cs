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

namespace CloneDroneSaveEditor
{
    public partial class CoopCustomGameSettingsEditor : Form
    {
        private string file;
        private CoopCustomGameSettings Data;

        public CoopCustomGameSettingsEditor()
        {
            InitializeComponent();
        }

        public CoopCustomGameSettingsEditor(string file)
        {
            InitializeComponent();
            this.file = file;
            this.fileLabel.Text = $"File: {file}";
            foreach (var item in Enum.GetNames<DifficultyTier>())
            {
                startingTierListBox.Items.Add(item);
            }
            startingTierListBox.SelectedIndex = -1;
            friendlyFireCheckBox.Checked = false;
            startSkillPointsNumericUpDown.Value = 0;
        }

        public CoopCustomGameSettingsEditor(string file, CoopCustomGameSettings data)
        {
            InitializeComponent();
            this.file = file;
            this.Data = data;
            this.fileLabel.Text = $"File: {file}";
            foreach (var item in Enum.GetNames<DifficultyTier>())
            {
                startingTierListBox.Items.Add(item);
            }
            startingTierListBox.SelectedIndex = (int)data.StartingTier;
            friendlyFireCheckBox.Checked = data.FriendlyFire;
            startSkillPointsNumericUpDown.Value = data.StartSkillPoints;
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
                Data.StartingTier = Enum.Parse<DifficultyTier>(startingTierListBox.SelectedItem.ToString());
                Data.FriendlyFire = friendlyFireCheckBox.Checked;
                Data.StartSkillPoints = (int)startSkillPointsNumericUpDown.Value;
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", @"LocalLow\Doborog\Clone Drone in the Danger Zone") + "\\" + file, JsonConvert.SerializeObject(this.Data));
                this.Close();
            }
        }
    }
}
