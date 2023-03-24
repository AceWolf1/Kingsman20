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

namespace Kingsman20.Windows.Login
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
            GenderComboBox.ItemsSource = ClassHelper.EF.Context.Gender.ToList();

            //MessageBox.Show(ClassHelper.EF.Context.Gender.ToList().Count.ToString());
            GenderComboBox.DisplayMemberPath = "Gender1";
        }

        private void VxodReg_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AutWindow autWindow = new AutWindow();
            autWindow.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
