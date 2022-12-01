using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRegistration.Command
{
    internal class Person
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(PersonDLA).Assembly)
                );


            return config.CreateMapper();
        }

        internal void CreatePersonCommand(string name, string address, string phone)
        {
            var dal = new PersonDLA(Mapper);

            var person = new PersonDTO
            {
                Name = name,
                Address = address,
                Phone = phone
            };
            person = dal.CreatePerson(person);
            Console.WriteLine($"New person ID : {person.Id}");
        }


        internal void PrintAllPersonCommand()
        {
            var dal = new PersonDLA(Mapper);

            var personList = dal.GetAllPerson();

            Console.WriteLine($"\n|{"ID",-3}|{"Name",-30}|{"Phone",-18}|{"Address",-50}|\n");
            foreach (var person in personList)
            {
                Console.WriteLine(person.ToString());
            }
        }

        internal void EditPersonCommand(int Id, string name, string address, string phone)
        {
            var dal = new PersonDLA(Mapper);

            var person = new PersonDTO
            {
                Name = name,
                Address = address,
                Phone = phone
            };
            person = dal.EditPersonByID(person, Id);
            Console.WriteLine($"Edited person ID : {(person != null ? $"{ person.Id}" : "null")}");
        }

        internal void DeletePersonCommand(int Id)
        {
            var dal = new PersonDLA(Mapper);
            var person = dal.DeletePersonByID(Id);

            Console.WriteLine($"Deleted person ID : {(person != null ? $"{person.Id}" : "null")}");
        }
    }
}

