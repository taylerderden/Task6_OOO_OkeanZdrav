using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
using Type = System.Type;

namespace Task6_OOO_OkeanZdrav.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window_Farm.xaml
    /// </summary>
    public partial class Window_Farm : Window
    {
        Medicament medicament;
        public Window_Farm()
        {
            InitializeComponent();
            update();

            List<Medicament> medicament = CoreModel.init().Medicaments.ToList();
            ListViewMed.ItemsSource = medicament.ToList();

            FiltrAnalog.Items.Add("Все");
            FiltrAnalog.Items.Add("Есть аналог");
            FiltrAnalog.Items.Add("Нет аналога");
            FiltrAnalog.SelectedIndex = 0;

            Sort.Items.Add("По возрастанию");
            Sort.Items.Add("По убыванию");
            Sort.Items.Add("По алфавиту");
            Sort.Items.Add("Против алфавита");
            Sort.SelectedIndex = 1;

            List<DbModels.Type> types = CoreModel.init().Types.ToList();
            FiltrOtpusk.ItemsSource = types;
            types.Insert(0, new DbModels.Type { TypeName = "Все виды отпуска" });
            FiltrOtpusk.SelectedIndex = 0;

            List<Supplier> supplier = CoreModel.init().Suppliers.ToList();
            FiltrPostav.ItemsSource = supplier;
            supplier.Insert(0, new Supplier { SupplierName = "Все поставщики" });
            FiltrPostav.SelectedIndex = 0;

        }

        private void btnZakaz_Click(object sender, RoutedEventArgs e)
        {
            Medicament medicament = ListViewMed.SelectedItem as Medicament;
            if (medicament != null)
            {
                Window_Zakaz WindowZakaz = new Window_Zakaz(new Purchase(), medicament.IdMedicament);
                WindowZakaz.Show();
                this.Close();
            }
            else
                MessageBox.Show("Выбери препарат!");
        
        }

        private void btnBonus_Click(object sender, RoutedEventArgs e)
        {
            Window_Bonus windowbonus = new Window_Bonus(new Client());
            windowbonus.Show();
            this.Close();
        }

        private void update()
        {
            IEnumerable<Medicament> medicament = CoreModel.init().Medicaments
                .Include(p => p.SupplierIdSupplierNavigation)
                .Include(p => p.TypeIdTypeNavigation)
                .Where(p => p.MedicamentPart.Contains(Search.Text)
                || p.SupplierIdSupplierNavigation.SupplierName.Contains(Search.Text)
                || p.MedicamentAnalog.Contains(Search.Text)
                || p.MedicamentName.Contains(Search.Text)
                || Convert.ToString(p.MedicamentCost).Contains(Search.Text)
                || Convert.ToString(p.MedicamentCount).Contains(Search.Text)
                || p.TypeIdTypeNavigation.TypeName.Contains(Search.Text));

            switch (Sort.SelectedIndex)
            {
                case 0:
                    medicament = medicament.OrderBy(p => p.MedicamentName);
                    break;

                case 1:
                    medicament = medicament.OrderByDescending(p => p.MedicamentName);
                    break;

                case 2:
                    medicament = medicament.OrderBy(p => p.MedicamentCost);
                    break;

                case 3:
                    medicament = medicament.OrderByDescending(p => p.MedicamentCost);
                    break;
            }
            if (FiltrOtpusk.SelectedIndex > 0)
            {
                medicament = medicament.Where(p => p.TypeIdType == (FiltrOtpusk.SelectedItem as DbModels.Type).IdType);
            }
            if (FiltrPostav.SelectedIndex > 0)
            {
                medicament = medicament.Where(p => p.SupplierIdSupplier == (FiltrPostav.SelectedItem as Supplier).IdSupplier);
            }
            if (FiltrAnalog.SelectedIndex > 0)
            {
                if (FiltrAnalog.SelectedIndex == 1)
                {
                    medicament = medicament.Where(p => p.MedicamentAnalog == "Да");
                }
                if (FiltrAnalog.SelectedIndex == 2)
                {
                    medicament = medicament.Where(p => p.MedicamentAnalog == "Нет");
                }      
            }

            ListViewMed.ItemsSource = medicament.ToList();
        }

        private void SearchChange(object sender, TextChangedEventArgs e)
        {
            update();
        }

        private void SortChange(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void FiltrTypeChange(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void FiltrSupplierChange(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void FiltrMedicamentChange(object sender, SelectionChangedEventArgs e)
        {
            update();
        }
    }
}
