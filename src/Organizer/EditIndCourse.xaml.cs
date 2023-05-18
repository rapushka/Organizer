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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Organizer
{
    /// <summary>
    /// Логика взаимодействия для EditIndCourse.xaml
    /// </summary>
    public partial class EditIndCourse : Page
    {
        public EditIndCourse()
        {
            InitializeComponent();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Course());
        }
    }
}
