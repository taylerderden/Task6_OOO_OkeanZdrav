﻿using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для Window_Guest.xaml
    /// </summary>
    public partial class Window_Guest : Window
    {
        public Window_Guest()
        {
            InitializeComponent();
            IEnumerable<Medicament> medicament = CoreModel.init().Medicaments
                .Include(p => p.SupplierIdSupplierNavigation)
                .Include(p => p.TypeIdTypeNavigation);
            ListViewMed.ItemsSource = medicament.ToList();
        }
    }
}
