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
                if (!file.Contains("HighScores"))
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
                            this.dataListBox.Items.Add($"{field.Name}: {field.GetValue(data)}");
                        }
                        else if (field.FieldType.IsEnum)
                        {
                            this.dataListBox.Items.Add($"{field.Name}: {Enum.GetName(field.FieldType, field.GetValue(data))}");
                        }
                        else if (field.FieldType.IsArray)
                        {
                            this.dataListBox.Items.Add($"{field.Name}: {field.GetValue(data)}");
                        }
                        else if (field.FieldType.IsGenericType)
                        {
                            var value = field.GetValue(data);
                            if (value == null)
                            {
                                this.dataListBox.Items.Add($"{field.Name}: null");
                            }
                            else if (value is List<string>)
                            {
                                var v = (List<string>)value;
                                this.dataListBox.Items.Add($"{field.Name}: ({v.Count})");
                                foreach (var item in v)
                                {
                                    this.dataListBox.Items.Add("\t" + item);
                                }
                            }
                            else if (value is Dictionary<UpgradeType, int>)
                            {
                                var v = (Dictionary<UpgradeType, int>)value;
                                this.dataListBox.Items.Add($"{field.Name}: ({v.Count})");
                                foreach (var item in v)
                                {
                                    this.dataListBox.Items.Add($"\t{Enum.GetName(typeof(UpgradeType), item.Key)}, {item.Value}");
                                }
                            }
                            else if (value is List<MechBodyPartType>)
                            {
                                var v = (List<MechBodyPartType>)value;
                                this.dataListBox.Items.Add($"{field.Name}: ({v.Count})");
                                foreach (var item in v)
                                {
                                    this.dataListBox.Items.Add("\t" + Enum.GetName(typeof(MechBodyPartType), item));
                                }
                            }
                            else if (value is List<MechBodyPartDamage>)
                            {
                                var v = (List<MechBodyPartDamage>)value;
                                this.dataListBox.Items.Add($"{field.Name}: ({v.Count})");
                                foreach (var item in v)
                                {
                                    foreach (var f in item.GetType().GetFields())
                                    {
                                        this.dataListBox.Items.Add($"\t{f.Name}: {f.GetValue(item)}");
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
                else
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
            if (file.Contains("HighScore"))
            {
                var data = JsonConvert.DeserializeObject<List<HighScoreData>>(File.ReadAllText(Path + $"\\{file}"));
                if (data == null || data.Count == 0)
                {
                    return;
                }
                HighScoreDataEditor editor = new HighScoreDataEditor(file, data);
                editor.Show();
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