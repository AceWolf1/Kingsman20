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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kingsman20.Windows.Cabinet;

namespace Kingsman20

/// <summary>
/// Логика взаимодействия для MainWindow.xaml
/// </summary>
{


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Услуги_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            this.Close();
        }

        private void Работники_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Клиенты_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}