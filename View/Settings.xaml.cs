using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BFMTools.Views
{
    public partial class Settings : UserControl
    {
        public ObservableCollection<ClientSettings> Clients { get; set; }
        public ClientSettings? SelectedClient { get; set; }

        public Settings()
        {
            InitializeComponent();
            Clients = new ObservableCollection<ClientSettings>(SettingsService.Load());
            this.DataContext = this;
        }

        private void ClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientComboBox.SelectedItem is ClientSettings selected)
            {
                NameBox.Text = selected.Name;
                FriendlyNameBox.Text = selected.FriendlyName;
                LogoBox.Text = selected.LogoPath;
                Color1Box.SelectedColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(selected.PrimaryColor);
                Color2Box.SelectedColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(selected.SecondaryColor);
            }
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            var newClient = new ClientSettings
            {
                Name = NameBox.Text,
                FriendlyName = FriendlyNameBox.Text,
                LogoPath = LogoBox.Text,
                PrimaryColor = Color1Box.SelectedColor.HasValue ? $"#{Color1Box.SelectedColor.Value.R:X2}{Color1Box.SelectedColor.Value.G:X2}{Color1Box.SelectedColor.Value.B:X2}" : "",
                SecondaryColor = Color2Box.SelectedColor.HasValue ? $"#{Color2Box.SelectedColor.Value.R:X2}{Color2Box.SelectedColor.Value.G:X2}{Color2Box.SelectedColor.Value.B:X2}" : ""
            };

            if (Clients.Any(c => c.Name.Equals(newClient.Name, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ce client existe déjà. Utilisez Modifier.");
                return;
            }

            Clients.Add(newClient);
            SettingsService.Save(Clients.ToList());
            MessageBox.Show("Client ajouté.");
            ClearForm();
        }

        private void ModifyClient_Click(object sender, RoutedEventArgs e)
        {
            if (ClientComboBox.SelectedItem is ClientSettings selected)
            {
                selected.Name = NameBox.Text;
                selected.FriendlyName = FriendlyNameBox.Text;
                selected.LogoPath = LogoBox.Text;
                selected.PrimaryColor = Color1Box.SelectedColor.HasValue ? $"#{Color1Box.SelectedColor.Value.R:X2}{Color1Box.SelectedColor.Value.G:X2}{Color1Box.SelectedColor.Value.B:X2}" : "";
                selected.SecondaryColor = Color2Box.SelectedColor.HasValue ? $"#{Color2Box.SelectedColor.Value.R:X2}{Color2Box.SelectedColor.Value.G:X2}{Color2Box.SelectedColor.Value.B:X2}" : "";

                SettingsService.Save(Clients.ToList());
                MessageBox.Show("Client modifié.");
                ClearForm();
            }
            else
            {
                MessageBox.Show("Aucun client sélectionné.");
            }
        }

        private void ClearForm()
        {
            NameBox.Text = "";
            FriendlyNameBox.Text = "";
            LogoBox.Text = "";
            Color1Box.SelectedColor = null;
            Color2Box.SelectedColor = null;
            ClientComboBox.SelectedItem = null;
            LogoPreview.Source = null;
        }

        private void LogoBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string url = LogoBox.Text.Trim();

            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                try
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(url);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    LogoPreview.Source = bitmap;
                }
                catch
                {
                    LogoPreview.Source = null;
                }
            }
            else
            {
                LogoPreview.Source = null;
            }
        }

        private void Color1Picker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            // Tu peux ajouter un aperçu ou sauvegarde ici si besoin
        }

        private void Color2Picker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color?> e)
        {
            // Tu peux ajouter un aperçu ou sauvegarde ici si besoin
        }
    }
}
