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
    public partial class GameDataEditor : Form
    {
        private string file;
        private GameData Data;

        public GameDataEditor()
        {
            InitializeComponent();
        }

        public GameDataEditor(string file)
        {
            InitializeComponent();
            this.file = file;
            this.fileLabel.Text = $"File: {file}";
            numClonesNumericUpDown.Value = 0;
            numTwitchClonesNumericUpDown.Value = 0;
            numLevelsWonNumericUpDown.Value = 0;
            availableSkillPointsNumericUpDown.Value = 0;
            numHumansInStorageNumericUpDown.Value = 0;
            cheerBitPoolNumericUpDown.Value = 0;
            numConsciousnessTransfersLeftNumericUpDown.Value = 0;
            foreach (var item in Enum.GetValues<EnemyType>())
            {
                transferredToEnemyTypeListBox.Items.Add(Enum.GetName(item));
            }
            transferredToEnemyTypeListBox.SelectedIndex = -1;
            foreach (var item in Enum.GetValues<EnemyType>())
            {
                allyTransferredToEnemyTypeListBox.Items.Add(Enum.GetName(item));
            }
            allyTransferredToEnemyTypeListBox.SelectedIndex = -1;
            foreach (var item in Enum.GetValues<EnemyType>())
            {
                oldAllyTransferredToEnemyTypeListBox.Items.Add(Enum.GetName(item));
            }
            oldAllyTransferredToEnemyTypeListBox.SelectedIndex = -1;
            foreach (var item in Enum.GetValues<EnemyType>())
            {
                oldTransferredToEnemyTypeListBox.Items.Add(Enum.GetName(item));
            }
            oldTransferredToEnemyTypeListBox.SelectedIndex = -1;
            characterModelOverrideNumericUpDown.Value = 0;
            ignoreFavouriteColorCheckBox.Checked = false;
        }

        public GameDataEditor(string file, GameData data)
        {
            InitializeComponent();
            this.file = file;
            this.fileLabel.Text = $"File: {file}";
            this.Data = data;
            numClonesNumericUpDown.Value = Data.NumClones;
            numTwitchClonesNumericUpDown.Value = Data.NumTwitchClones;
            numLevelsWonNumericUpDown.Value = Data.NumLevelsWon;
            foreach (var item in Data.CurrentLevelSectionsVisible)
            {
                currentLevelSectionsVisibleListBox.Items.Add(item);
            }
            foreach (var pair in Data.PlayerUpgrades)
            {
                playerUpgradesListBox.Items.Add($"{pair.Key}: {pair.Value}");
            }
            foreach (var item in Data.PlayerArmorParts)
            {
                playerArmorPartsListBox.Items.Add(Enum.GetName(item));
            }
            availableSkillPointsNumericUpDown.Value = Data.AvailableSkillPoints;
            foreach (var item in Data.LevelIDsBeatenThisPlaythrough)
            {
                levelIDsBeatenThisPlaythroughListBox.Items.Add(item);
            }
            foreach (var item in Data.LevelPrefabsBeatenThisPlaythrough)
            {
                levelPrefabsBeatenThisPlaythroughListBox.Items.Add(item);
            }
            foreach (var item in Data.LevelIDsExcludedThisGame)
            {
                levelIDsExcludedThisGameListBox.Items.Add(item);
            }
            numHumansInStorageNumericUpDown.Value = Data.NumHumansInStorage;
            foreach (var item in Data.PlayerBodyPartDamages)
            {
                var damaged = item.IsDamaged ? "damaged" : "not damaged";
                var severed = item.IsSevered ? "severed" : "severed";
                playerBodyPartDamagesListBox.Items.Add($"{item.BodyPartID}: {damaged}, {severed}");
            }
            cheerBitPoolNumericUpDown.Value = Data.CheerBitPool;
            numConsciousnessTransfersLeftNumericUpDown.Value = Data.NumConsciousnessTransfersLeft;
            foreach (var item in Enum.GetValues<EnemyType>())
            {
                transferredToEnemyTypeListBox.Items.Add(Enum.GetName(item));
            }
            transferredToEnemyTypeListBox.SelectedIndex = (int)Data.TransferredToEnemyType;
            foreach (var item in Enum.GetValues<EnemyType>())
            {
                allyTransferredToEnemyTypeListBox.Items.Add(Enum.GetName(item));
            }
            allyTransferredToEnemyTypeListBox.SelectedIndex = (int)Data.AllyTransferredToEnemyType;
            foreach (var item in Enum.GetValues<EnemyType>())
            {
                oldAllyTransferredToEnemyTypeListBox.Items.Add(Enum.GetName(item));
            }
            oldAllyTransferredToEnemyTypeListBox.SelectedIndex = (int)Data.OldAllyTransferredToEnemyType;
            foreach (var item in Enum.GetValues<EnemyType>())
            {
                oldTransferredToEnemyTypeListBox.Items.Add(Enum.GetName(item));
            }
            oldTransferredToEnemyTypeListBox.SelectedIndex = (int)Data.OldTransferredToEnemyType;
            characterModelOverrideNumericUpDown.Value = Data.CharacterModelOverride;
            ignoreFavouriteColorCheckBox.Checked = Data.IgnoreFavouriteColor;
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
                Data.NumClones = (int)numClonesNumericUpDown.Value;
                Data.NumTwitchClones = (int)numTwitchClonesNumericUpDown.Value;
                Data.NumLevelsWon = (int)numLevelsWonNumericUpDown.Value;
                Data.AvailableSkillPoints = (int)availableSkillPointsNumericUpDown.Value;
                Data.NumHumansInStorage = (int)numHumansInStorageNumericUpDown.Value;
                Data.CheerBitPool = (int)cheerBitPoolNumericUpDown.Value;
                Data.NumConsciousnessTransfersLeft = (int)numConsciousnessTransfersLeftNumericUpDown.Value;
                Data.TransferredToEnemyType = Enum.Parse<EnemyType>(transferredToEnemyTypeListBox.SelectedItem.ToString());
                Data.AllyTransferredToEnemyType = Enum.Parse<EnemyType>(allyTransferredToEnemyTypeListBox.SelectedItem.ToString());
                Data.OldAllyTransferredToEnemyType = Enum.Parse<EnemyType>(oldAllyTransferredToEnemyTypeListBox.SelectedItem.ToString());
                Data.OldTransferredToEnemyType = Enum.Parse<EnemyType>(oldTransferredToEnemyTypeListBox.SelectedItem.ToString());
                Data.CharacterModelOverride = (int)characterModelOverrideNumericUpDown.Value;
                Data.IgnoreFavouriteColor = ignoreFavouriteColorCheckBox.Checked;
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", @"LocalLow\Doborog\Clone Drone in the Danger Zone") + "\\" + file, JsonConvert.SerializeObject(this.Data));
                this.Close();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
