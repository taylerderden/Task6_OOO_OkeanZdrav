using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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
    /// Логика взаимодействия для Window_Zakaz.xaml
    /// </summary>
    public partial class Window_Zakaz : Window
    {
        Purchase purchase;
        int medicam;
        public Window_Zakaz(Purchase purchase, int idMed)
        {
            InitializeComponent();

            medicam = idMed;
            this.purchase = purchase;
            DataContext = purchase;

            List<Client> clients = CoreModel.init().Clients.ToList();
            cbClient.ItemsSource = clients;

            Medicament medicament = CoreModel.init().Medicaments.FirstOrDefault(p => Convert.ToString(p.IdMedicament).Contains(Convert.ToString(medicam)));
            if (medicament != null)
            {
                tbMedicament.Text = medicament.MedicamentName;

            }
        }
        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            if (tbMedicament.Text != "" && tbCount.Text != "" && cbClient.Text != "")
            {
                purchase.MedicamentIdMedicament = medicam;

                DateOnly dateRec = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                purchase.PurchaseDate = dateRec;

                CoreModel.init().Purchases.Add(purchase);
                CoreModel.init().SaveChanges();

                MessageBox.Show("Запись добавлена");

                Window_Farm windowFarm = new Window_Farm();
                windowFarm.Show();
                Hide();
            }
            else
                MessageBox.Show("Заполните все поля!");
        }

        private void cbClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client clients = CoreModel.init().Clients.FirstOrDefault(p => p.ClientPhone.Contains(cbClient.Text));
            if (clients != null)
            {
                purchase.ClientsIdClients = clients.IdClients;
            }
        }
    }
}
