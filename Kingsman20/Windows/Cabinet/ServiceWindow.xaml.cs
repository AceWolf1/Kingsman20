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
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public ServiceWindow()
        {
            InitializeComponent();
            GetListService();
            if (ClassHelper.UserDataClass.Staff.PositionID == 2)
            {
                Spisok.Visibility = Visibility.Collapsed;
            }
        }
        private void GetListService()
        {
            LvService.ItemsSource = ClassHelper.EF.Context.Service.ToList();
        }

        



        private void Spisok_Click(object sender, RoutedEventArgs e)
        {

           
                AddServiceWindow addServiceWindow = new AddServiceWindow();
                addServiceWindow.ShowDialog();

                //GetListService();
            
        }

    

      

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service;
            EditServiceWindow editServiceWindow = new EditServiceWindow(service);
            editServiceWindow.ShowDialog();
        }

        private void Cor_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись


            ClassHelper.CartServiceClass.ServiceCart.Add(service);

            MessageBox.Show($"Услуга {service.Title} добавлена в корзину!");
        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            cartWindow.ShowDialog();
        }

        private void LvService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
