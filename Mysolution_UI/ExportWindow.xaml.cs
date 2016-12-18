using Mysolution_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mysolution_UI
{
    
    /// <summary>
    /// Interaction logic for ExportWindow.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {
        Repository rep;
        public ExportWindow(country cry, string varname )
        {
            rep = new Repository();
            InitializeComponent();
            switch (varname)
            {
                case "Export (bln USD)":
                    ExportListView.ItemsSource = rep.GetExportForCountry(cry);
                    break;
                case "Unemployment (per cent)":
                    ExportListView.ItemsSource = rep.GetunemploymentForCountry(cry);
                    break;
                case "Population (mln people)":
                    ExportListView.ItemsSource = rep.GetpopulationForCountry(cry);
                    break;
                case "National Debt (bln USD)":
                    ExportListView.ItemsSource = rep.GetNatDebtForCountry(cry);
                    break;
                case "Import (bln USD)":
                    ExportListView.ItemsSource = rep.GetImportForCountry(cry);
                    break;
                case "GDP Growth (per cent of GDP)":
                    ExportListView.ItemsSource = rep.GetGDPGrowthForCountry(cry);
                    break;
                case "GDP (bln USD)":
                    ExportListView.ItemsSource = rep.GetGDPForCountry(cry);
                    break;
                case "Inflation (per cent)":
                    ExportListView.ItemsSource = rep.GetInflationForCountry(cry);
                    break;
                default:throw new ArgumentOutOfRangeException("Incorrect argument!");
            }
            VarTextBlock.Text = varname;
            CountryTextBlock.Text = cry.Name;
        }

        private void CloseItemClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ExitItemClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
