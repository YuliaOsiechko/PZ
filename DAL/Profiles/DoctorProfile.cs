using AutoMapper;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
        }
    }
}
