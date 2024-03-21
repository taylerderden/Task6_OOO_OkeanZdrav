using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для Window_ProsmZak.xaml
    /// </summary>
    public partial class Window_ProsmZak : Window
    {
        public Window_ProsmZak()
        {
            InitializeComponent();
            IEnumerable<Purchase> purchase = CoreModel.init().Purchases
                .Include(p => p.MedicamentIdMedicament)
                .Include(p => p.ClientsIdClients)
                .Include(p => p.RecipeIdRecipe);
            ListViewZak.ItemsSource = purchase.ToList();
        }
    }
}
