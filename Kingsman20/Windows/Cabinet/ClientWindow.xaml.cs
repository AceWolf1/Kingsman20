﻿using Kingsman20.Windows.Cabinet;
using Kingsman20.Windows.Login;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            SetClientList();
        }
        public void SetClientList()
        {
            ObservableCollection<DB.Client> listEmployee = new ObservableCollection<DB.Client>(ClassHelper.EF.Context.Client.ToList());
            LvClients.ItemsSource = listEmployee.ToList();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            DB.Client client = button.DataContext as DB.Client;

            EditClientWindow editClientWindow = new EditClientWindow(client);
            editClientWindow.ShowDialog();
            SetClientList();
        }
        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            RegWindow registrationWindow = new RegWindow();
            registrationWindow.ShowDialog();
            SetClientList();
        }
        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var client = button.DataContext as DB.Client;

            ClassHelper.EF.Context.Client.Remove(client);
            SetClientList();
        }

        private void LvClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
