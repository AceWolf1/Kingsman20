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
    /// Логика взаимодействия для EditServiceWindow.xaml
    /// </summary>
    public partial class EditServiceWindow : Window
    {
        DB.Service editService = null;

        public EditServiceWindow()
        {
            InitializeComponent();
        }

        
        public EditServiceWindow(DB.Service service)
        {
            InitializeComponent();


            editService = service;

            // Заполнение типа услуги

            CmbTypeService.ItemsSource = ClassHelper.EF.Context.ServiceType.ToList();
            CmbTypeService.DisplayMemberPath = "TypeName";

            // выгрузка изображения 
            ImgImageService.Source = new BitmapImage(new Uri(service.Image));

            // заполнение полей
            TbNameService.Text = service.Title;
            TbDiscService.Text = service.Comment;
            TbPriceService.Text = Convert.ToString(service.Cost);

            // заполнение типа услуги
            CmbTypeService.SelectedItem = ClassHelper.EF.Context.ServiceType.Where(i => i.id == service.ServiceTypeID).FirstOrDefault();

        }

        private void BtnEditService_Click(object sender, RoutedEventArgs e)
        {


            // валидация

            editService.Title = TbNameService.Text;
            editService.Comment = TbDiscService.Text;
            editService.Cost = Convert.ToDecimal(TbPriceService.Text);
            editService.ServiceTypeID = (CmbTypeService.SelectedItem as DB.ServiceType).id;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранны");

            this.Close();
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
