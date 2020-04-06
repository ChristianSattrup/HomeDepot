using HomeDepotWebApp.Models;
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
    public partial class CreateCustomerPage : Page
    {
        private HomeDepotContext _context;
        public CreateCustomerPage()
        {
            InitializeComponent();
            _context = new HomeDepotContext();
        }
        private void CreateCustomerClick(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.Name = Name.Text;
            customer.Address = Address.Text;
            customer.Email = Email.Text;
            customer.Username = Username.Text;
            customer.Password = Password.Text;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            var window = new MainWindow();
            window.Show();
            Application.Current.Windows[0].Close();
        }
    }
}
