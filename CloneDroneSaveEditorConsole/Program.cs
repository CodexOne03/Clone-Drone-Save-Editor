using Newtonsoft.Json;
using System.Collections;

namespace CloneDroneSaveEditorConsole
{
    internal class Program
    {
        private static string Path;

        static void Main(string[] args)
        {
            Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", @"LocalLow\Doborog\Clone Drone in the Danger Zone");
            Console.WriteLine(Path);
            GameData data = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(Path + @"\EndlessModeData.json"));
            foreach (var field in typeof(GameData).GetFields())
            {
                if (field.FieldType.IsValueType)
                {
                    Console.WriteLine($"{field.Name}: {field.GetValue(data)}");
                }
                else if (field.FieldType.IsEnum)
                {
                    Console.WriteLine($"{field.Name}: {Enum.GetName(field.FieldType, field.GetValue(data))}");
                }
                else if (field.FieldType.IsArray)
                {
                    Console.WriteLine($"{field.Name}: {field.GetValue(data)}");
                }
                else if (field.FieldType.IsGenericType)
                {
                    var value = field.GetValue(data);
                    if (value is List<string>)
                    {
                        var v = (List<string>)value;
                        Console.WriteLine($"{field.Name}: ({v.Count})");
                        foreach (var item in v)
                        {
                            Console.WriteLine("\t" + item);
                        }
                    }
                    else if (value is Dictionary<UpgradeType, int>)
                    {
                        var v = (Dictionary<UpgradeType, int>)value;
                        Console.WriteLine($"{field.Name}: ({v.Count})");
                        foreach (var item in v)
                        {
                            Console.WriteLine($"\t{Enum.GetName(typeof(UpgradeType), item.Key)}, {item.Value}");
                        }
                    }
                    else if (value is List<MechBodyPartType>)
                    {
                        var v = (List<MechBodyPartType>)value;
                        Console.WriteLine($"{field.Name}: ({v.Count})");
                        foreach (var item in v)
                        {
                            Console.WriteLine("\t" + Enum.GetName(typeof(MechBodyPartType), item));
                        }
                    }
                    else if (value is List<MechBodyPartDamage>)
                    {
                        var v = (List<MechBodyPartDamage>)value;
                        Console.WriteLine($"{field.Name}: ({v.Count})");
                        foreach (var item in v)
                        {
                            foreach (var f in item.GetType().GetFields())
                            {
                                Console.WriteLine($"\t{f.Name}: {f.GetValue(item)}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Unexpected type: {value.GetType()}");
                    }
                }
            }
        }
    }
}