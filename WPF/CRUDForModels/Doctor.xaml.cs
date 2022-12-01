using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF.CRUDForModels
{
    /// <summary>
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctor : Window
    {
        public Doctor()
        {
            InitializeComponent();
            GetDoctor();

            AddNewDoctorGrid.DataContext = NewDoctor;
        }

        static IMapper Mapper = SetupMapper();
        DoctorDTO NewDoctor = new DoctorDTO();
        DoctorDTO selectedDoctor = new DoctorDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(DoctorDAL).Assembly)
                );
            return config.CreateMapper();
        }

        private void GetDoctor()
        {
            var dal = new DoctorDAL(Mapper);

            var doctorList = dal.GetAllDoctor();
            DoctorDG.ItemsSource = doctorList;
        }

        private void AddDoctor(object s, RoutedEventArgs e)
        {
            var dal = new DoctorDAL(Mapper);

            NewDoctor = dal.CreateDoctor(NewDoctor);

            GetDoctor();
            NewDoctor = new DoctorDTO();
            AddNewDoctorGrid.DataContext = NewDoctor;
        }

        private void DeleteDoctor(object s, RoutedEventArgs e)
        {
            var doctorToBeDeleted = (s as FrameworkElement).DataContext as DoctorDTO;

            var dal = new DoctorDAL(Mapper);
            dal.DeleteDoctor(doctorToBeDeleted);
            GetDoctor();
        }

        private void UpdateDoctorForEdit(object s, RoutedEventArgs e)
        {
            selectedDoctor = (s as FrameworkElement).DataContext as DoctorDTO;
            UpdateDoctorGrid.DataContext = selectedDoctor;
        }

        private void UpdateDoctor(object s, RoutedEventArgs e)
        {
            var dal = new DoctorDAL(Mapper);
            dal.EditDoctor(selectedDoctor);
            GetDoctor();
        }
    }
}
