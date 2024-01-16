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
            this.pathLabel.Text = Path;
            GameData data = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(Path + @"\EndlessModeData.json"));
            foreach (var field in typeof(GameData).GetFields())
            {
                if (field.FieldType.IsValueType)
                {
                    this.listBox1.Items.Add($"{field.Name}: {field.GetValue(data)}");
                }
                else if (field.FieldType.IsEnum)
                {
                    this.listBox1.Items.Add($"{field.Name}: {Enum.GetName(field.FieldType, field.GetValue(data))}");
                }
                else if (field.FieldType.IsArray)
                {
                    this.listBox1.Items.Add($"{field.Name}: {field.GetValue(data)}");
                }
                else if (field.FieldType.IsGenericType)
                {
                    var value = field.GetValue(data);
                    if (value is List<string>)
                    {
                        var v = (List<string>)value;
                        this.listBox1.Items.Add($"{field.Name}: ({v.Count})");
                        foreach (var item in v)
                        {
                            this.listBox1.Items.Add("\t" + item);
                        }
                    }
                    else if (value is Dictionary<UpgradeType, int>)
                    {
                        var v = (Dictionary<UpgradeType, int>)value;
                        this.listBox1.Items.Add($"{field.Name}: ({v.Count})");
                        foreach (var item in v)
                        {
                            this.listBox1.Items.Add($"\t{Enum.GetName(typeof(UpgradeType), item.Key)}, {item.Value}");
                        }
                    }
                    else if (value is List<MechBodyPartType>)
                    {
                        var v = (List<MechBodyPartType>)value;
                        this.listBox1.Items.Add($"{field.Name}: ({v.Count})");
                        foreach (var item in v)
                        {
                            this.listBox1.Items.Add("\t" + Enum.GetName(typeof(MechBodyPartType), item));
                        }
                    }
                    else if (value is List<MechBodyPartDamage>)
                    {
                        var v = (List<MechBodyPartDamage>)value;
                        this.listBox1.Items.Add($"{field.Name}: ({v.Count})");
                        foreach (var item in v)
                        {
                            foreach (var f in item.GetType().GetFields())
                            {
                                this.listBox1.Items.Add($"\t{f.Name}: {f.GetValue(item)}");
                            }
                        }
                    }
                    else
                    {
                        this.listBox1.Items.Add($"Unexpected type: {value.GetType()}");
                    }
                }
            }
        }
    }
}