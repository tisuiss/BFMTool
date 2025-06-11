using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace BFMTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            InitializeToolFolders();
        }

        private void InitializeToolFolders()
        {
            string basePath = @"C:\BFMTool";
            string[] requiredDirs = {"Log", "Script", "Report"};

            foreach (var dir in requiredDirs)
            {
                string fullPath = Path.Combine(basePath, dir);

                try
                {
                    // Crée le dossier s'il n'existe pas
                    Directory.CreateDirectory(fullPath);

                    // Purge selon le type de dossier
                    var files = Directory.GetFiles(fullPath);

                    if (dir == "Script")
                    {
                        // Supprime tous les fichiers
                        foreach (var file in files)
                        {
                            File.Delete(file);
                        }
                    }
                    else if (dir == "Log")
                    {
                        // Supprime uniquement les fichiers plus vieux que 30 jours
                        foreach (var file in files)
                        {
                            DateTime lastWriteTime = File.GetLastWriteTime(file);
                            if (lastWriteTime < DateTime.Now.AddDays(-30))
                            {
                                File.Delete(file);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la gestion du dossier {dir}: {ex.Message}");
                }
            }
        }


    }



}
