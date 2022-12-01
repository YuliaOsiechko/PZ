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
using WPF.CRUDForModels;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenDoctorWindow(object sender, RoutedEventArgs e)
        {
            Doctor doctor = new Doctor();
            doctor.ShowDialog();
        }

        private void OpenPersonWindow(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.ShowDialog();
        }
    }
}

