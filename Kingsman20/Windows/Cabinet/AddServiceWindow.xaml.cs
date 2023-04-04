using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    { 
        private string pathImage = null;

    
        public AddServiceWindow()
        {
            InitializeComponent();
           
            CmbTypeService.DisplayMemberPath = "TypeName";
            CmbTypeService.SelectedIndex = 0;
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            DB.Service newService = new DB.Service();

            newService.Cost = Convert.ToDecimal(TbPriceService.Text);
            newService.Title = TbNameService.Text;
            newService.Comment = TbDiscService.Text;
            //newService.ServiceTypeID = (CmbTypeService.SelectedItem as DB.ServiceType).ID;
            //if (pathImage != null)
            //{
            //    newService.Image = pathImage;
            //}

            ClassHelper.EF.Context.Service.Add(newService);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Услуга добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgImageService.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImage = openFileDialog.FileName;
            }
        }

        private void BtnChooseImage_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
