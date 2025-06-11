using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BFMTools.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public ObservableCollection<ClientSettings> Clients { get; set; }
        public Settings()
        {
            InitializeComponent();
            Clients = new ObservableCollection<ClientSettings>(SettingsService.Load());
            this.DataContext = this;
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsService.Save(Clients.ToList());
            MessageBox.Show("Paramètres enregistrés !");
        }
    }
}
