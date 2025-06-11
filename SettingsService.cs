using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BFMTools
{
    public static class SettingsService
    {
        private static string SharePointFolder => Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
    @"FIDUCIAIRE MAUCERI\BFMTool - DATA\Data"
);

        private static string SettingsFilePath => Path.Combine(SharePointFolder, "clients.json");

        public static List<ClientSettings> Load()
        {
            if (!File.Exists(SettingsFilePath))
                return new List<ClientSettings>();

            var json = File.ReadAllText(SettingsFilePath);
            return JsonSerializer.Deserialize<List<ClientSettings>>(json) ?? new List<ClientSettings>();
        }

        public static void Save(List<ClientSettings> settings)
        {
            Directory.CreateDirectory(SharePointFolder); // Ensure folder exists
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFilePath, json);
        }
    }

}
