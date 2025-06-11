using BFMTools.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BFMTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentArea.Content = new Home();
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Home();
        }
        private void LiquiditesButton_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Liquidites();
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Settings();
        }
    }
}