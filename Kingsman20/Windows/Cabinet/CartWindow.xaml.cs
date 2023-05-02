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
using Kingsman20.ClassHelper;
using System.Collections.ObjectModel;

namespace Kingsman20.Windows.Cabinet
{
    /// <summary>
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            GetListServise();
        }
        private void GetListServise()
        {
            ObservableCollection<DB.Service> listCart = new ObservableCollection<DB.Service>(ClassHelper.CartServiceClass.ServiceCart);
            LvService.ItemsSource = listCart;
        }

        private void BtnDeleteCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if  (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service;

            service.Quantity = 0;

            ClassHelper.CartServiceClass.ServiceCart.Remove(service);

            GetListServise();
        }





        private void DeleteCor_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service; // получаем выбранную запись

            ClassHelper.CartServiceClass.ServiceCart.Remove(service);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LvService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service;
            service.Quantity
        }

    

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            EF.Context.Order.Add(new DB.Order
            {
                ClientID = 1,
                StaffID = UserDataClass.Staff.ID,
                SaleDate = DateTime.Now,
            }
           );

            foreach (var item in ClassHelper.CartServiceClass.ServiceCart)
            {
                DB.ProductSale orderService = new DB.ProductSale();
                orderService.OrderID = 1;
                orderService.ProductID = item.ID;
                orderService.Quatity = 1;

                EF.Context.ProductSale.Add(orderService);

            }

        }

        private void BtnLowerCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null) 
            {
                return;
            }
            var service = button.DataContext as DB.Service;

            if (service.Quantity > 1)

            {
                service.Quantity--;
                GetListServise();
            }
        }

        private void BtnHigherCart_Click(object sender, RoutedEventArgs e)

        {
            var button = sender as Button;

            if (button == null)
            {
                return;

            }
            var service = button.DataContext as DB.Service;

            if (service.Quantity < 20)
            {

                service.Quantity++;
                GetListServise();
            }
        }


    }
}
