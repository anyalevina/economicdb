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
    /// Interaction logic for YearWindow.xaml
    /// </summary>
    public partial class YearWindow : Window
    {
        Repository rep;
        string ind;
      
        public YearWindow(string indicator)
        {
            ind = indicator;
            rep = new Repository();
            InitializeComponent();

        }

        private void DisplayButtonClick(object sender, RoutedEventArgs e)
        {
            string yearstr0 = YearComboBox.SelectedItem.ToString();
            var yearstr1 = yearstr0.Substring(yearstr0.Length - 4);
            int localint;
            int yearint;
            if ((int.TryParse(QuantityTextBox.Text, out localint)) && (int.TryParse(yearstr1, out yearint)))
            {
                if (localint > 0 && localint < 172)
                {
                    switch (ind)
                    {
                        case "topGDP":
                            YearListView.ItemsSource = rep.GetLargestEconomiesForYear(yearint, localint);
                            RequestTextBox.Text = "Largest GDPs in bln USD";
                            break;
                        case "bottomGDP":
                            YearListView.ItemsSource = rep.GetSmallestEconomiesForYear(yearint, localint);
                            RequestTextBox.Text = "Smallest GDPs in bln USD";
                            break;
                        case "fastGDP":
                            YearListView.ItemsSource = rep.GetFastestGrowingEconomies(yearint, localint);
                            RequestTextBox.Text = "Countries with largest GDP Growth Percent ";
                            break;
                        case "slowGDP":
                            YearListView.ItemsSource = rep.GetSlowestGrowingEconomies(yearint, localint);
                            RequestTextBox.Text = "Countries with largest GDP Growth Percent ";
                            break;
                        default: throw new ArgumentOutOfRangeException("Invalid Argumant!");

                    } }
            }
        }


        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
   

    }
}
