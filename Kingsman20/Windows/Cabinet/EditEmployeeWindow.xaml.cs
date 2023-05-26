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
    /// Логика взаимодействия для EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        DB.Staff addedStaff = null;
        public EditEmployeeWindow()
        {
            InitializeComponent();
        }
        public EditEmployeeWindow(DB.Staff staff)
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";

            TbFirstName.Text = staff.FName;
            TbLastName.Text = staff.LName;
            TbPatronymic.Text = staff.Patronymic;
            TbNewLogin.Text = staff.Email;
            TbNewPassword.Text = staff.Password;
            CmbGender.SelectedItem = ClassHelper.EF.Context.Gender.ToList().Where(i => i.ID == staff.GenderCodeID).FirstOrDefault();

            addedStaff = staff;
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
            addedStaff.FName = TbFirstName.Text;
            addedStaff.LName = TbLastName.Text;
            addedStaff.Patronymic = TbPatronymic.Text;
            addedStaff.Email = TbNewLogin.Text;
            addedStaff.Password = TbNewPassword.Text;
            addedStaff.GenderCodeID = (CmbGender.SelectedItem as DB.Gender).ID;

            //ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("OK");
            this.Close();
        }

        private void TbBack_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }


    }
}
