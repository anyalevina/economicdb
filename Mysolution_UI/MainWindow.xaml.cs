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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mysolution_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository rep;
        public MainWindow()
        {
            rep = new Repository();
            InitializeComponent();
            
        }

        private void ViewBycountry_Click(object sender, RoutedEventArgs e)
        {
            var c = new CountryWindow();
            c.ShowDialog();
        }

        private void YearViewItemClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void TopEcItemClick(object sender, RoutedEventArgs e)
        {
            var yw = new YearWindow("topGDP");
            yw.ShowDialog();
        }

        private void BottomGDPItemClick(object sender, RoutedEventArgs e)
        {
            var yw = new YearWindow("bottomGDP");
            yw.ShowDialog();
        }

        private void FastGDPGrowthItem_Click(object sender, RoutedEventArgs e)
        {
            var yw = new YearWindow("fastGDP");
            yw.ShowDialog();
        }

        private void sloGDPGrwthItem_Click(object sender, RoutedEventArgs e)
        {
            var yw = new YearWindow("slowGDP");
            yw.ShowDialog();
        }
    }
}
