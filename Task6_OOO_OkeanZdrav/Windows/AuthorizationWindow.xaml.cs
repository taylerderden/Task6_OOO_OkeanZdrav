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
using Task6_OOO_OkeanZdrav.DbModels;
using Task6_OOO_OkeanZdrav.Windows;

namespace Task6_OOO_OkeanZdrav
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void BtnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == null || tbPassword.Text == null)
            {
                MessageBox.Show("Заполните данные для входа!");
            }
            else
            {
                Employee employee = CoreModel.init().Employees.FirstOrDefault(p => p.EmployeeEmail == tbLogin.Text && p.EmployeePassword == tbPassword.Text);

                if (employee != null)
                {
                    if (employee.PositionIdPosition == 1)
                    {
                        Window_Farm window_farm = new Window_Farm();
                        window_farm.Show();
                        Hide();
                    }
                    if (employee.PositionIdPosition == 2)
                    {
                        Window_Admin window_admin = new Window_Admin();
                        window_admin.Show();
                        Hide();
                    }
                }

            }

        }

        private void BtnGuest_Click(object sender, RoutedEventArgs e)
        {
            Window_Guest window_guest = new Window_Guest();
            window_guest.Show();
            Hide();
        }
    }
}
