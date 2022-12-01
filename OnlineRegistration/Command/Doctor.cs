using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRegistration.Command
{
    internal class Doctor
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(DoctorDAL).Assembly)
                );


            return config.CreateMapper();
        }

        internal void CreateDoctorCommand(string specielization, int personId)
        {
            var dal = new DoctorDAL(Mapper);

            var doctor = new DoctorDTO
            {
                Specielization = specielization,
                PersonId = personId,
            };
            doctor = dal.CreateDoctor(doctor);
            Console.WriteLine($"New doctor ID : {doctor.Id}");
        }


        internal void PrintAllDoctorCommand()
        {
            var dal = new DoctorDAL(Mapper);

            var doctorList = dal.GetAllDoctor();

            Console.WriteLine($"\n|{"ID",-3}|{"Specielization",-20}|{"PersonId",-5}|\n");
            foreach (var doctor in doctorList)
            {
                Console.WriteLine(doctor.ToString());
            }
        }

        internal void EditDoctorCommand(int Id, string specielization, int personId)
        {
            var dal = new DoctorDAL(Mapper);

            var doctor = new DoctorDTO
            {
                Specielization = specielization,
                PersonId = personId,
            };
            doctor = dal.EditDoctorByID(doctor, Id);
            Console.WriteLine($"Edited doctor ID : {(doctor != null ? $"{ doctor.Id}" : "null")}");
        }

        internal void DeleteDoctorCommand(int Id)
        {
            var dal = new DoctorDAL(Mapper);
            var doctor = dal.DeleteDoctorByID(Id);

            Console.WriteLine($"Deleted doctor ID : {(doctor != null ? $"{doctor.Id}" : "null")}");
        }
    }
}
