using GefluegelBl;
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

namespace GefluegelGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stall stall;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stall = new Stall();
            this.DataContext = stall;
        }

        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            NeuesTier dlgNeuesTier = new NeuesTier();

            if (dlgNeuesTier.ShowDialog() == true)
            {
                stall.Tiere.Add(dlgNeuesTier.Tier);
            }

        }
    }
}
