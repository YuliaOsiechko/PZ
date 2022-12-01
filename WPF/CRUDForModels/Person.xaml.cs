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
    /// Interaction logic for Person.xaml
    /// </summary>
    public partial class Person : Window
    {
        public Person()
        {
            InitializeComponent();
            GetPerson();

            AddNewPersonGrid.DataContext = NewPerson;
        }

        static IMapper Mapper = SetupMapper();
        PersonDTO NewPerson = new PersonDTO();
        PersonDTO selectedPerson = new PersonDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(PersonDLA).Assembly)
                );
            return config.CreateMapper();
        }

        private void GetPerson()
        {
            var dal = new PersonDLA(Mapper);

            var personList = dal.GetAllPerson();
            PersonDG.ItemsSource = personList;
        }

        private void AddPerson(object s, RoutedEventArgs e)
        {
            var dal = new PersonDLA(Mapper);

            NewPerson = dal.CreatePerson(NewPerson);

            GetPerson();
            NewPerson = new PersonDTO();
            AddNewPersonGrid.DataContext = NewPerson;
        }

        private void DeletePerson(object s, RoutedEventArgs e)
        {
            var personToBeDeleted = (s as FrameworkElement).DataContext as PersonDTO;

            var dal = new PersonDLA(Mapper);
            dal.DeletePerson(personToBeDeleted);
            GetPerson();
        }

        private void UpdatePersonForEdit(object s, RoutedEventArgs e)
        {
            selectedPerson = (s as FrameworkElement).DataContext as PersonDTO;
            UpdatePersonGrid.DataContext = selectedPerson;
        }

        private void UpdatePerson(object s, RoutedEventArgs e)
        {
            var dal = new PersonDLA(Mapper);
            dal.EditPerson(selectedPerson);
            GetPerson();
        }
    }
}
