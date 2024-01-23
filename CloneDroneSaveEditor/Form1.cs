using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CloneDroneSaveEditor
{
    public partial class Form1 : Form
    {
        private string Path;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", @"LocalLow\Doborog\Clone Drone in the Danger Zone");
            foreach (var file in Directory.GetFiles(Path, "*.json"))
            {
                var name = new FileInfo(file).Name;
                this.filesListBox.Items.Add(name);
            }
        }

        private void LoadData(string file, bool clear = true)
        {
            if (clear)
            {
                this.dataListBox.Items.Clear();
            }
            try
            {
                if (!file.Contains("HighScores") && !file.Contains("GameplayAchievementsData") && !file.Contains("TwitchHighScores") && !file.Contains("TwitchData") && !file.Contains("SettingsData") && !file.Contains("SequencePlayCounts") && !file.Contains("Multiplayer1v1CustomGameSettings") && !file.Contains("MetagameData") && !file.Contains("GameplayAchievementsData") && !file.Contains("EndlessHighScores") && !file.Contains("CoopCustomGameSettings"))
                {
                    var data = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(Path + $"\\{file}"));
                    if (data == null)
                    {
                        return;
                    }
                    foreach (var field in typeof(GameData).GetFields())
                    {
                        if (field.FieldType.IsValueType)
                        {
                            this.dataListBox.Items.Add($"{field.Name} ({field.FieldType.Name}): {field.GetValue(data)}");
                        }
                        else if (field.FieldType.IsEnum)
                        {
                            this.dataListBox.Items.Add($"{field.Name} ({field.FieldType.Name}): {Enum.GetName(field.FieldType, field.GetValue(data))}");
                        }
                        else if (field.FieldType.IsArray)
                        {
                            this.dataListBox.Items.Add($"{field.Name} ({field.FieldType.Name}): {field.GetValue(data)}");
                        }
                        else if (field.FieldType.IsGenericType)
                        {
                            var value = field.GetValue(data);
                            if (value == null)
                            {
                                this.dataListBox.Items.Add($"{field.Name} ({field.FieldType.Name}): null");
                            }
                            else if (value is List<string>)
                            {
                                var v = (List<string>)value;
                                this.dataListBox.Items.Add($"{field.Name} ({field.FieldType.Name}): ({v.Count})");
                                foreach (var item in v)
                                {
                                    this.dataListBox.Items.Add("\t" + item);
                                }
                            }
                            else if (value is Dictionary<UpgradeType, int>)
                            {
                                var v = (Dictionary<UpgradeType, int>)value;
                                this.dataListBox.Items.Add($"{field.Name} ({field.FieldType.Name}): ({v.Count})");
                                foreach (var item in v)
                                {
                                    this.dataListBox.Items.Add($"\t{Enum.GetName(typeof(UpgradeType), item.Key)}, {item.Value}");
                                }
                            }
                            else if (value is List<MechBodyPartType>)
                            {
                                var v = (List<MechBodyPartType>)value;
                                this.dataListBox.Items.Add($"{field.Name} ({field.FieldType.Name}): ({v.Count})");
                                foreach (var item in v)
                                {
                                    this.dataListBox.Items.Add("\t" + Enum.GetName(typeof(MechBodyPartType), item));
                                }
                            }
                            else if (value is List<MechBodyPartDamage>)
                            {
                                var v = (List<MechBodyPartDamage>)value;
                                this.dataListBox.Items.Add($"{field.Name} ({field.FieldType.Name}): ({v.Count})");
                                foreach (var item in v)
                                {
                                    foreach (var f in item.GetType().GetFields())
                                    {
                                        this.dataListBox.Items.Add($"\t{f.Name} ({field.FieldType.Name}): {f.GetValue(item)}");
                                    }
                                }
                            }
                            else
                            {
                                this.dataListBox.Items.Add($"Unexpected type: {value.GetType()}");
                            }
                        }
                    }
                }
                else if (file.Contains("ChallengeHighScores") || file.Contains("EndlessHighScores") || file.Contains("TwitchHighScores"))
                {
                    var data = JsonConvert.DeserializeObject<List<HighScoreData>>(File.ReadAllText(Path + $"\\{file}"));
                    if (data == null)
                    {
                        return;
                    }
                    if (data.Count == 0)
                    {
                        this.dataListBox.Items.Add("Empty");
                        return;
                    }
                    foreach (var item in data)
                    {
                        this.dataListBox.Items.Add($"LevelReached: {item.LevelReached}");
                        this.dataListBox.Items.Add($"HumanFactSet:");
                        this.dataListBox.Items.Add($"\tFirstName: {item.HumanFacts.FirstName}");
                        this.dataListBox.Items.Add($"\tLastName: {item.HumanFacts.LastName}");
                        this.dataListBox.Items.Add($"\tOccupation: {item.HumanFacts.Occupation}");
                        this.dataListBox.Items.Add($"\tGenderIsFemale: {item.HumanFacts.GenderIsFemale}");
                        this.dataListBox.Items.Add($"\tAge: {item.HumanFacts.Age}");
                        this.dataListBox.Items.Add($"\tFavouriteColorIndex: {item.HumanFacts.FavouriteColorIndex}");
                    }
                }
                else if (file.Contains("CoopCustomGameSettings"))
                {
                    var data = JsonConvert.DeserializeObject<CoopCustomGameSettings>(File.ReadAllText(Path + $"\\{file}"));
                    if (data == null)
                    {
                        return;
                    }
                    this.dataListBox.Items.Add($"StartingTier: {Enum.GetName(data.StartingTier)}");
                    this.dataListBox.Items.Add($"FriendlyFire: {data.FriendlyFire}");
                    this.dataListBox.Items.Add($"StartSkillPoints: {data.StartSkillPoints}");
                }
                else if (file.Contains("GameplayAchievementsData"))
                {
                    var data = JsonConvert.DeserializeObject<GameplayAchievementsData>(File.ReadAllText(Path + $"\\{file}"));
                    if (data == null)
                    {
                        return;
                    }
                    this.dataListBox.Items.Add("ProgressDictionary:");
                    foreach (var pair in data.ProgressDictionary)
                    {
                        this.dataListBox.Items.Add($"\t{pair.Key}: {pair.Value}");
                    }
                    this.dataListBox.Items.Add("NewAchievements:");
                    foreach (var item in data.NewAchievements)
                    {
                        this.dataListBox.Items.Add($"\t{item}");
                    }
                }
                else if (file.Contains("MetagameData"))
                {
                    var data = JsonConvert.DeserializeObject<MetagameProgressManager.MetagameData>(File.ReadAllText(Path + $"\\{file}"));
                    if (data == null)
                    {
                        return;
                    }
                    this.dataListBox.Items.Add($"CurrentProgress: {Enum.GetName(data.CurrentProgress)}");
                    this.dataListBox.Items.Add($"HighestProgressReached: {Enum.GetName(data.HighestProgressReached)}");
                    this.dataListBox.Items.Add($"NumHumansEscaped: {data.NumHumansEscaped}");
                    this.dataListBox.Items.Add($"HasBeatenFirstLevelOnce: {data.HasBeatenFirstLevelOnce}");
                    this.dataListBox.Items.Add($"LastLevelDiedOn: {data.LastLevelDiedOn}");
                    this.dataListBox.Items.Add($"LastGameModeDiedOn: {Enum.GetName(data.LastGameModeDiedOn)}");
                    this.dataListBox.Items.Add($"FirstEscapedHumansData:");
                    this.dataListBox.Items.Add($"\tHumanFacts: {data.FirstEscapedHumansData.HumanFacts}");
                    this.dataListBox.Items.Add($"\t\tFirstName: {data.FirstEscapedHumansData.HumanFacts.FirstName}");
                    this.dataListBox.Items.Add($"\t\tLastName: {data.FirstEscapedHumansData.HumanFacts.LastName}");
                    this.dataListBox.Items.Add($"\t\tOccupation: {data.FirstEscapedHumansData.HumanFacts.Occupation}");
                    this.dataListBox.Items.Add($"\t\tGenderIsFemale: {data.FirstEscapedHumansData.HumanFacts.GenderIsFemale}");
                    this.dataListBox.Items.Add($"\t\tAge: {data.FirstEscapedHumansData.HumanFacts.Age}");
                    this.dataListBox.Items.Add($"\t\tFavouriteColorIndex: {data.FirstEscapedHumansData.HumanFacts.FavouriteColorIndex}");
                    this.dataListBox.Items.Add("\tUpgrades:");
                    foreach (var pair in data.FirstEscapedHumansData.Upgrades)
                    {
                        this.dataListBox.Items.Add($"\t\t{pair.Key}: {pair.Value}");
                    }
                    this.dataListBox.Items.Add($"SecondEscapedHumansData:");
                    this.dataListBox.Items.Add($"\tHumanFacts: {data.SecondEscapedHumansData.HumanFacts}");
                    this.dataListBox.Items.Add($"\t\tFirstName: {data.SecondEscapedHumansData.HumanFacts.FirstName}");
                    this.dataListBox.Items.Add($"\t\tLastName: {data.SecondEscapedHumansData.HumanFacts.LastName}");
                    this.dataListBox.Items.Add($"\t\tOccupation: {data.SecondEscapedHumansData.HumanFacts.Occupation}");
                    this.dataListBox.Items.Add($"\t\tGenderIsFemale: {data.SecondEscapedHumansData.HumanFacts.GenderIsFemale}");
                    this.dataListBox.Items.Add($"\t\tAge: {data.SecondEscapedHumansData.HumanFacts.Age}");
                    this.dataListBox.Items.Add($"\t\tFavouriteColorIndex: {data.SecondEscapedHumansData.HumanFacts.FavouriteColorIndex}");
                    this.dataListBox.Items.Add("\tUpgrades:");
                    foreach (var pair in data.SecondEscapedHumansData.Upgrades)
                    {
                        this.dataListBox.Items.Add($"\t\t{pair.Key}: {pair.Value}");
                    }
                    this.dataListBox.Items.Add($"MinDifficultyLevelForChapter: {Enum.GetName(data.MinDifficultyLevelForChapter)}");
                    this.dataListBox.Items.Add($"DifficultyLastMeasuredForLevelID: {data.DifficultyLastMeasuredForLevelID}");
                }
                else if (file.Contains("Multiplayer1v1CustomGameSettings"))
                {
                    var data = JsonConvert.DeserializeObject<Multiplayer1v1CustomGameSettings>(File.ReadAllText(Path + $"\\{file}"));
                    if (data == null)
                    {
                        return;
                    }
                    this.dataListBox.Items.Add($"StartClones: {data.StartClones}");
                    this.dataListBox.Items.Add($"StartSkillPoints: {data.StartSkillPoints}");
                    this.dataListBox.Items.Add($"SkillPointsPerDeath: {data.SkillPointsPerDeath}");
                }
                else if (file.Contains("SequencePlayCounts"))
                {
                    var data = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(Path + $"\\{file}"));
                    if (data == null)
                    {
                        return;
                    }
                    foreach (var pair in data)
                    {
                        this.dataListBox.Items.Add($"{pair.Key}: {pair.Value}");
                    }
                }
                else if (file.Contains("TwitchData"))
                {
                    var data = JsonConvert.DeserializeObject<TwitchData>(File.ReadAllText(Path + $"\\{file}"));
                    if (data == null)
                    {
                        return;
                    }
                    this.dataListBox.Items.Add($"AudienceVotesOnUpgrades: {data.AudienceVotesOnUpgrades}");
                    this.dataListBox.Items.Add($"SubscribersGuaranteedSelection: {data.SubscribersGuaranteedSelection}");
                    this.dataListBox.Items.Add($"HasMigratedTwitchSettings: {data.HasMigratedTwitchSettings}");
                    this.dataListBox.Items.Add($"CoinsEarnedPerMinute: {data.CoinsEarnedPerMinute}");
                    this.dataListBox.Items.Add($"NewViewerStartingCoins: {data.NewViewerStartingCoins}");
                    this.dataListBox.Items.Add($"HasMigratedTwitchSettings02: {data.HasMigratedTwitchSettings02}");
                    this.dataListBox.Items.Add($"ModsCanAdmin: {data.ModsCanAdmin}");
                    this.dataListBox.Items.Add($"HasMigratedTwitchSettings03: {data.HasMigratedTwitchSettings03}");
                    this.dataListBox.Items.Add($"EliteBotsCostBits: {data.EliteBotsCostBits}");
                }
                else
                {
                    foreach (var line in File.ReadAllLines(Path + $"\\{file}"))
                    {
                        this.dataListBox.Items.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                this.dataListBox.Items.Add($"Error: {ex.Message}");
                foreach (var line in File.ReadAllLines(Path + $"\\{file}"))
                {
                    this.dataListBox.Items.Add(line);
                }
            }
        }

        private void filesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(this.filesListBox.SelectedItem.ToString(), true);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.filesListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select a file to edit first");
                return;
            }
            var file = this.filesListBox.SelectedItem.ToString();
            if (file.Contains("ChallengeHighScores") || file.Contains("EndlessHighScores") || file.Contains("TwitchHighScores"))
            {
                var data = JsonConvert.DeserializeObject<List<HighScoreData>>(File.ReadAllText(Path + $"\\{file}"));
                if (data == null || data.Count == 0)
                {
                    HighScoreDataEditor editor = new HighScoreDataEditor(file);
                    editor.Show();
                }
                else
                {
                    HighScoreDataEditor editor = new HighScoreDataEditor(file, data);
                    editor.Show();
                }
            }
            else if (file.Contains("CoopCustomGameSettings"))
            {
                var data = JsonConvert.DeserializeObject<CoopCustomGameSettings>(File.ReadAllText(Path + $"\\{file}"));
                if (data == null)
                {
                    CoopCustomGameSettingsEditor editor = new CoopCustomGameSettingsEditor(file);
                    editor.Show();
                }
                else
                {
                    CoopCustomGameSettingsEditor editor = new CoopCustomGameSettingsEditor(file, data);
                    editor.Show();
                }
            }
            else
            {
                var data = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(Path + $"\\{file}"));
                if (data == null)
                {
                    GameDataEditor editor = new GameDataEditor(file);
                    editor.Show();
                }
                else
                {
                    GameDataEditor editor = new GameDataEditor(file, data);
                    editor.Show();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.filesListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select a file to delete first");
                return;
            }
            var file = this.filesListBox.SelectedItem.ToString();
            var result = MessageBox.Show("Are you sure that you want to delete this file's contents?", "Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                File.WriteAllText(Path + $"\\{file}", "");
            }
        }
    }
}