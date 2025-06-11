using Microsoft.Win32;
using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace BFMTools.Views
{
    /// <summary>
    /// Interaction logic for Liquidites.xaml
    /// </summary>
    public partial class Liquidites : UserControl
    {
        public Liquidites()
        {
            InitializeComponent();
            // Calcule le dernier jour du mois en cours
            var today = DateTime.Today;
            var lastDayOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            // Définit la date dans le DatePicker
            Date_Recurring_date.SelectedDate = lastDayOfMonth;

        }


        private void RunPowerShellScript(string scriptPath, string CrediteurFilePath, string DebiteurFilePath, string ReportAmount, string ReportDate, string SalaryAmount, string SalaryThirteen, string ReccuringAmount, string ReccuringDate, string ClientName)
        {
            try
            {
                using System.Diagnostics.Process ps = new System.Diagnostics.Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "powershell.exe",
                        Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\" -CreditorxlsPath \"{CrediteurFilePath}\" -DebtorxlsPath \"{DebiteurFilePath}\" -DepartSold \"{ReportAmount}\" -ReportDateTime \"{ReportDate}\" -Salary \"{SalaryAmount}\" -Salary13 \"{SalaryThirteen}\" -Reccurent \"{ReccuringAmount}\" -RecurringDate \"{ReccuringDate}\" -ClientName \"{ClientName}\"",
                        UseShellExecute = true,
                        CreateNoWindow = false
                    }
                };
                ps.Start();
                ps.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task DownloadFileAsync(string fileUrl, string destinationPath)
        {
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(fileUrl);
            response.EnsureSuccessStatusCode();
            await System.IO.File.WriteAllBytesAsync(destinationPath, await response.Content.ReadAsByteArrayAsync());
        }

        private void Btn_Liquidites_Crediteurs_File_Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                txt_xls_crediteur_file_path.Text = filePath;
            }
        }
        private void Btn_Liquidites_Débiteurs_File_Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                txt_xls_debiteur_file_path.Text = filePath;
            }
        }

        private async void Btn_Report_Creation_Click(object sender, RoutedEventArgs e)
        {
            string scriptUrl = "https://api.bitbucket.org/2.0/repositories/scripttisuiss/repo_bfmtool/src/main/Scripts/ReportAccounting.ps1";
            string scriptPath = @"C:\\BFMTool\\Script\\ReportAccounting.ps1";
            string CreditorxlsxPath = "C:\\BFMTool\\creditor.xlsx";
            string DebtorxlsxPath = "C:\\BFMTool\\debitor.xlsx";
            string CrediteurFilePath = txt_xls_crediteur_file_path.Text;
            string DebiteurFilePath = txt_xls_debiteur_file_path.Text;
            string ReportAmount = txt_report_amount.Text;
            string ReportDate = Date_report_date.Text;
            string SalaryAmount = txt_salary_amount.Text;
            Boolean ChoiceSalaryThirteen = (bool)chk_13th_salary.IsChecked;
            string ReccuringAmount = txt_reccuring_amount.Text;
            string ReccuringDate = Date_Recurring_date.Text;
            string ClientName = txt_client_name.Text;

            // default valeurs si null
            if (string.IsNullOrEmpty(ReportAmount))
            {
                txt_report_amount.Text = "0";
            }

            if (string.IsNullOrEmpty(SalaryAmount))
            {
                txt_salary_amount.Text = "0";
            }

            if (string.IsNullOrEmpty(ReccuringAmount))
            {
                txt_reccuring_amount.Text = "0";
            }

            // convert bool to string
            string SalaryThirteen = ChoiceSalaryThirteen ? "Yes" : "No";

            try
            {
                // Télécharger le script PowerShell depuis l'URL spécifiée
                await DownloadFileAsync(scriptUrl, scriptPath);

                // Vérifier si le script a bien été téléchargé
                if (!System.IO.File.Exists(scriptPath))
                {
                    MessageBox.Show("Le téléchargement du script a échoué.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Exécuter le script PowerShell en passant les fichiers JSON en paramètres
                RunPowerShellScript(scriptPath, CrediteurFilePath, DebiteurFilePath, ReportAmount, ReportDate, SalaryAmount, SalaryThirteen, ReccuringAmount, ReccuringDate , ClientName);

                // Supprimer les fichiers temporaires après utilisation
                System.IO.File.Delete(scriptPath);
                System.IO.File.Delete(CreditorxlsxPath);
                System.IO.File.Delete(DebtorxlsxPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
