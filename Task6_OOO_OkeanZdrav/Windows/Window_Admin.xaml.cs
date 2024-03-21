using Microsoft.EntityFrameworkCore;
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
using Task6_OOO_OkeanZdrav.DbModels;

namespace Task6_OOO_OkeanZdrav.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window_Admin.xaml
    /// </summary>
    public partial class Window_Admin : Window
    {
        public Window_Admin()
        {
            InitializeComponent();
            IsBolshMenshe();
            IEnumerable<Medicament> medicament = CoreModel.init().Medicaments
                .Include(p => p.SupplierIdSupplierNavigation)
                .Include(p => p.TypeIdTypeNavigation);
            ListViewMed.ItemsSource = medicament.ToList();
        }

        private void btnProsmZakaz_Click(object sender, RoutedEventArgs e)
        {
            Window_ProsmZak windowprosmzak = new Window_ProsmZak();
            windowprosmzak.Show();
            this.Close();
        }

        private void btnIns_Click(object sender, RoutedEventArgs e)
        {
            Window_AddMedicament add_Window = new Window_AddMedicament(new Medicament());
            add_Window.Show();
            this.Close();
        }

        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMed.SelectedItems.Count > 1 || ListViewMed.SelectedItems.Count < 1)
            {
                MessageBox.Show("выберите 1 элемент");
                return;
            }

            Medicament medEdit = ListViewMed.SelectedItem as Medicament;
            Window_AddMedicament add_Window = new Window_AddMedicament(medEdit);
            add_Window.Show();
            this.Close();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewMed.SelectedItems.Count > 1 || ListViewMed.SelectedItems.Count < 1)
            {
                MessageBox.Show("выберите 1 элемент");
                return;
            }

            Medicament medDel = ListViewMed.SelectedItem as Medicament;
            int a = medDel.IdMedicament;
            if (medDel != null && MessageBox.Show("Delete?", "Realy delete?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {                           
                CoreModel.init().Purchases.RemoveRange(CoreModel.init().Purchases.Where(p => Convert.ToString(p.MedicamentIdMedicament).Contains(Convert.ToString(medDel.IdMedicament))));
                CoreModel.init().Recipes.RemoveRange(CoreModel.init().Recipes.Where(p => Convert.ToString(p.MedicamentIdMedicament).Contains(Convert.ToString(medDel.IdMedicament))));
                CoreModel.init().Medicaments.Remove(medDel);
                CoreModel.init().SaveChanges();

                IEnumerable<Medicament> medicament = CoreModel.init().Medicaments
                .Include(p => p.SupplierIdSupplierNavigation)
                .Include(p => p.TypeIdTypeNavigation);
                ListViewMed.ItemsSource = medicament.ToList();
            }
        }

        public bool IsBolshMenshe()
        {
            IEnumerable<Medicament> medicament = CoreModel.init().Medicaments.Where(p => p.MedicamentCount < 10);

            for(int i = 0; i < medicament.Count(); i++)
            {
                return true;
                i++;
            }
            return false;
        }
        
    }
}
