﻿using System;
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

namespace Kingsman20.Windows.Cabinet
{
    /// <summary>
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public ServiceWindow()
        {
            InitializeComponent();
        }

       

        private void Spisok_Click(object sender, RoutedEventArgs e)
        {
           
                AddServiceWindow addServiceWindow = new AddServiceWindow();
                addServiceWindow.ShowDialog();

                //GetListService();
            
        }

    

        private void LvService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
