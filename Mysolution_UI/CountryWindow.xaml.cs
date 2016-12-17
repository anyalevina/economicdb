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
using Mysolution_Data;


namespace Mysolution_UI
{
    /// <summary>
    /// Interaction logic for CountryWindow.xaml
    /// </summary>
    public partial class CountryWindow : Window
    {
        ExportWindow ew;
        Repository rep;
        List<country> cl;
       
        public CountryWindow()
        {
            rep = new Repository();
            InitializeComponent();
            SearchButton.IsEnabled = false;
            CountryMenu.IsEnabled = false;
            cl = rep.GetListOfCountries();
            

        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            var str = SearchTextBox.Text.Trim();
           
            if (!String.IsNullOrEmpty(str))
            {

                var res = from c in cl
                      where (c.Name.Contains(str.ToLower()))
                      select c;
                CountryListBox.ItemsSource = res;
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(SearchTextBox.Text))
                SearchButton.IsEnabled = true;
        }

        private  void AllCountriesButtonClick(object sender, RoutedEventArgs e)
        {
            
            CountryListBox.ItemsSource = cl;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CountryListBox.SelectedItem != null)
                CountryMenu.IsEnabled = true;
        }

        private void Inflation_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cry = CountryListBox.SelectedItem as country;
                if (cry != null)
                {
                    var tem = cry;
                    
                    ew = new ExportWindow(tem, "Inflation (per cent)");
                    ew.ShowDialog();

                }
                else
                    MessageBox.Show("Error!");

            }
            catch(Exception ex1)
            {

                MessageBox.Show(ex1.Message);
            }
        }

        private void ExportItem_Click(object sender, RoutedEventArgs e)
        {

            var cry = CountryListBox.SelectedItem as country;
            var templist = new List<export>();
            if (cry != null)
            {
                var tem = cry;
                
                ew = new ExportWindow(tem, "Export (bln USD)");
                
                ew.ShowDialog();

            }
            else
                MessageBox.Show("Error!");
            
        }

        private void Unemployment_Click(object sender, RoutedEventArgs e)
        {
            var cry = CountryListBox.SelectedItem as country;
            if (cry != null)
            {
                var tem = cry;
                
                ew = new ExportWindow(tem, "Unemployment (per cent)");
                ew.ExportListView.ItemsSource = rep.GetunemploymentForCountry(tem);
                ew.ShowDialog();

            }
            else
                MessageBox.Show("Error!");
        }

        private void PopulationItemClick(object sender, RoutedEventArgs e)
        {
            var cry = CountryListBox.SelectedItem as country;
            if (cry != null)
            {
                var tem = cry;
                
                ew = new ExportWindow(tem, "Population (mln people)");
                ew.ShowDialog();

            }
            else
                MessageBox.Show("Error!");
        }

        private void NatDebtItem_Click(object sender, RoutedEventArgs e)
        {
            var cry = CountryListBox.SelectedItem as country;
            if (cry != null)
            {
                var tem = cry;
                
                ew = new ExportWindow(tem, "National Debt (bln USD)");
                ew.ShowDialog();

            }
            else
                MessageBox.Show("Error!");
        }

        private void ImportItem_Click(object sender, RoutedEventArgs e)
        {
            var cry = CountryListBox.SelectedItem as country;
            if (cry != null)
            {
                var tem = cry;
                
                ew = new ExportWindow(tem, "Import (bln USD)");
                ew.ShowDialog();

            }
            else
                MessageBox.Show("Error!");
        }

        private void GDPGrowthItem_Click(object sender, RoutedEventArgs e)
        {
            var cry = CountryListBox.SelectedItem as country;
            if (cry != null)
            {
                var tem = cry;
                
                ew = new ExportWindow(tem, "GDP Growth (per cent of GDP)");
                ew.ShowDialog();

            }
            else
                MessageBox.Show("Error!");
        }

        private void GdpItem_Click(object sender, RoutedEventArgs e)
        {
            var cry = CountryListBox.SelectedItem as country;
            if (cry != null)
            {
                var tem = cry;
                
                ew = new ExportWindow(tem, "GDP (bln USD)");
                ew.ShowDialog();

            }
            else
                MessageBox.Show("Error!");
        }
    }
    
    
}
