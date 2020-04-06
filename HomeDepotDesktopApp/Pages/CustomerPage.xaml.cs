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
    public partial class CustomerPage : Page
    {
        private HomeDepotContext _context;
        public CustomerPage()
        {
            InitializeComponent();
            _context = new HomeDepotContext();
            loadCustomers();
        }
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            saveCustomerInfo();
        }
            private void lbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadBookings();
            loadCustomerInfo();
        }
        private void lbBookings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Booking booking = (Booking)lbBookings.SelectedItem;
            if (booking!=null)
            {
                if (booking.Status == "Booked")
                {
                    cbStatus.SelectedIndex = 0;
                }
                else
                {
                    if (booking.Status == "Delivered")
                    {
                        cbStatus.SelectedIndex = 1;
                    }
                    else
                    {
                        cbStatus.SelectedIndex = 2;
                    }
                }
            }
            
        }
        private void cbStatusClosed(object sender, EventArgs e)
        {
            Booking booking = (Booking)lbBookings.SelectedItem;
            if (booking != null)
            {
                booking.Status = cbStatus.Text;
                _context.SaveChanges();
            }
            loadBookings();
        }
        private void loadCustomers()
        {
            lbCustomers.Items.Clear();
            _context.Customers.ToList().ForEach(e => lbCustomers.Items.Add(e));
        }
        private void loadBookings()
        {
            Customer customer = _context.Customers.Find(lbCustomers.SelectedIndex + 1);
            if (customer != null)
            {
                lbBookings.Items.Clear();
                _context.Bookings.ToList().ForEach((e) => {
                    if (e.CustomerID == customer.Id)
                    {
                        lbBookings.Items.Add(e);
                    }
                });
            }
        }
        private void loadCustomerInfo()
        {
            Customer customer = _context.Customers.Find(lbCustomers.SelectedIndex + 1);
            if (customer!=null)
            {
                Name.Text = customer.Name;
                Address.Text = customer.Address;
                Email.Text = customer.Email;
                Username.Text = customer.Username;
                Password.Text = customer.Password;
            }
        }
        private void saveCustomerInfo()
        {
            Customer customer = _context.Customers.Find(lbCustomers.SelectedIndex + 1);
            if (customer != null)
            {
                customer.Name = Name.Text;
                customer.Address = Address.Text;
                customer.Email = Email.Text;
                customer.Username = Username.Text;
                customer.Password = Password.Text;
                _context.SaveChanges();
                loadCustomers();
                loadCustomerInfo();
            }
        }
    }
}
