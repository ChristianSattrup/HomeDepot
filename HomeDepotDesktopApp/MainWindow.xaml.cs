using HomeDepotWebApp.Storage;
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

namespace HomeDepotDesktopApp
{
    public partial class MainWindow : Window
    {
        private HomeDepotContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new HomeDepotContext();
        }
        private void CustomerClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new CustomerPage();
        }
        private void CreateCustomerClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateCustomerPage();
        }
    }
}
