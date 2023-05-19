using Kingsman20.DB;
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

namespace Kingsman20.Windows.Cabinet
{
    /// <summary>
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        DB.Client newClient = null;
        public EditClientWindow()
        {
            InitializeComponent();
        }

        public EditClientWindow(Client client)
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";

            TbFirstName.Text = client.FName;
            TbLastName.Text = client.LName;
            TbPatronymic.Text = client.Patronymic;
            TbNewLogin.Text = client.Email;
            TbNewPassword.Text = client.Password;
            CmbGender.SelectedItem = ClassHelper.EF.Context.Gender.ToList().Where(i => i.ID == client.GenderCodeID).FirstOrDefault();

            newClient = client;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0)
            {
                (sender as TextBox).Foreground = Brushes.DarkGray;
                (sender as TextBox).Text = (string)(sender as TextBox).Tag;
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length != 0 && (sender as TextBox).Text == (string)(sender as TextBox).Tag)
            {
                (sender as TextBox).Foreground = Brushes.Black;
                (sender as TextBox).Text = "";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            newClient.FName = TbFirstName.Text;
            newClient.LName = TbLastName.Text;
            newClient.Patronymic = TbPatronymic.Text;
            newClient.Email = TbNewLogin.Text;
            newClient.Password = TbNewPassword.Text;
            newClient.GenderCodeID = (CmbGender.SelectedItem as DB.Gender).ID;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("OK");
            this.Close();
        }

        private void TbBack_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
