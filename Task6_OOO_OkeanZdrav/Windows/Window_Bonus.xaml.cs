using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Task6_OOO_OkeanZdrav.DbModels;

namespace Task6_OOO_OkeanZdrav.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window_Bonus.xaml
    /// </summary>
    public partial class Window_Bonus : Window
    {
        Client client;
        public Window_Bonus(Client cl)
        {
            InitializeComponent();
            this.client = cl;
            DataContext = client;
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            if (tbFam.Text != "" && tbName.Text != "" && tbSurname.Text != "" && tbPhone.Text != "" && tbEmail.Text != "" && tbDiscont.Text != "")
            {
                if (client.IdClients == 0)
                {
                    CoreModel.init().Clients.Add(client);
                }

                else
                {
                    MessageBox.Show("Запись добавлена");

                    Window_Farm windowFarm = new Window_Farm();
                    windowFarm.Show();
                    Hide();
                }

            }
            else
                MessageBox.Show("Заполните все поля!");
        }
    }
}
