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
            InitializeComponent();
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
    }
}
