using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Window_AddMedicament.xaml
    /// </summary>
    public partial class Window_AddMedicament : Window
    {
        Medicament medicament;
        public Window_AddMedicament(Medicament medicament)
        {
            InitializeComponent();
            this.medicament = medicament;
            DataContext = medicament;

            List<Supplier> suppliers = CoreModel.init().Suppliers.ToList();
            cbSupplier.ItemsSource = suppliers;

            List<DbModels.Type> types = CoreModel.init().Types.ToList();
            cbType.ItemsSource = types;
            this.medicament = medicament;
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            if (medicament.IdMedicament == 0)
            {
                CoreModel.init().Medicaments.Add(medicament);
            }

            CoreModel.init().SaveChanges();

            Window_Admin window_Admin = new Window_Admin();
            window_Admin.Show();
            this.Close();
        }

        private void imageEditClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All Files|*.*" };
            if (openFile.ShowDialog() == true)
            {
                medicament.MedicamentImage = File.ReadAllBytes(openFile.FileName);
                imgPhoto.Source = new BitmapImage(new Uri(openFile.FileName, UriKind.Absolute));
            }
        }
    }
}
