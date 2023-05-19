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
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            SetEmployeeList();
        }

        public void SetEmployeeList()
        {
            ObservableCollection<DB.Staff> listEmployee = new ObservableCollection<DB.Staff>(ClassHelper.EF.Context.Staff.ToList());
            LvEmployees.ItemsSource = listEmployee.Distinct();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            DB.Staff employee = button.DataContext as DB.Staff;

            EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow(employee);
            editEmployeeWindow.ShowDialog();
        }
        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.ShowDialog();
        }
        private void BtnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var employee = button.DataContext as DB.Staff;

            ClassHelper.EF.Context.Staff.Remove(employee);
            SetEmployeeList();
        }
    }
}
