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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainF.Content = new Schedule();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainF.Content = new Student();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainF.Content = new Group();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainF.Content = new Course();
        }
    }
}
