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
            //GenderComboBox.ItemsSource = ClassHelper.EF.Context.Gender.ToList();

            //MessageBox.Show(ClassHelper.EF.Context.Gender.ToList().Count.ToString());
            GenderComboBox.DisplayMemberPath = "Gender1";
            GenderComboBox.SelectedIndex = 0;
        }

        private void VxodReg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBFirsName.Text))
            {
                MessageBox.Show("Поле FirstName не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBLastName.Text))
            {
                MessageBox.Show("Поле LastName не заполнено");
                return;
            }
        
            if (string.IsNullOrWhiteSpace(TBPhone.Text))
            {
                MessageBox.Show("Поле Phone не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBEmail.Text))
            {
                MessageBox.Show("Поле Email не заполнено");
                return;
            }
            if (string.IsNullOrWhiteSpace(PBPassword.Password))
            {
                MessageBox.Show("Поле Password не заполнено");
                return;

            }
            DB.Client addClient = new DB.Client();
            addClient.LName = TBLastName.Text;
            addClient.FName = TBFirsName.Text;
            addClient.Patronymic = TBPatronymic.Text;
            addClient.Phone = TBPhone.Text;
            addClient.Email = TBEmail.Text;
            addClient.Password = PBPassword.Password;
            if (TBPatronymic.Text != string.Empty)
            {
                addClient.Patronymic = TBPatronymic.Text;
            }
            //addClient.Gender = (GenderComboBox.SelectedItem as DB.Gender).Gender1();
            ClassHelper.EF.Context.SaveChanges();
            //MessageBox.Show("Пользователь успешно добавлен");
            MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OKCancel, MessageBoxImage.Information);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TBPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TBLastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
