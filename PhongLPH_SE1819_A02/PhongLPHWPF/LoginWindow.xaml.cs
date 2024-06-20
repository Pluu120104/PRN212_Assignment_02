using BusinessObject;
using DataAccess.Repository;
using PhongLPHWPF.Admin;
using PhongLPHWPF.Customer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace PhongLPHWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IConfigurationRoot configuration;
        private CustomerRepository customerRepository = new CustomerRepository();
        public LoginWindow()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            BusinessObject.Customer customer = customerRepository.GetUserByEmailAndPassword(email, password);

            string adminEmail = configuration.GetSection("Admin:Email").Value;
            string adminPassword = configuration.GetSection("Admin:Password").Value;
            if (customerRepository.Login(email, password))
            {
                Application.Current.Properties["LoggedInUser"] = customerRepository.GetUserByEmailAndPassword(email, password);
                MessageBox.Show("Welcome Customer");
                WindowCustomer customerPage = new WindowCustomer();
                customerPage.Show();
                this.Close();
            }
          else
          if (email.Equals(adminEmail) && password.Equals(adminPassword))
          {
              MessageBox.Show("Welcome admin");
              WindowAdmin admin = new WindowAdmin();
              admin.Show();
              this.Close();
          }
            else
            {
                MessageBox.Show("Đăng nhập không thành công");
            }
        }
    }
}

