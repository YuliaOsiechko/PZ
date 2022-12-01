using AutoMapper;
using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Concrete
{
    public class DoctorDAL : IDoctor
    {
        private readonly IMapper _mapper;
        public DoctorDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public DoctorDTO CreateDoctor(DoctorDTO doctor)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var doctorInDB = _mapper.Map<Doctor>(doctor);
                entites.Doctors.Add(doctorInDB);
                entites.SaveChanges();
                return _mapper.Map<DoctorDTO>(doctorInDB);
            }
        }

        public List<DoctorDTO> GetAllDoctor()
        {
            using (var entities = new OnlineRegistrationContext())
            {
                var doctors = entities.Doctors.ToList();
                return _mapper.Map<List<DoctorDTO>>(doctors);
            }
        }


        public DoctorDTO DeleteDoctorByID(int id)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var doctorInDB = entites.Doctors.SingleOrDefault(x => x.Id == id);
                if (doctorInDB != null)
                {
                    entites.Doctors.Remove(doctorInDB);
                    entites.SaveChanges();
                    return _mapper.Map<DoctorDTO>(doctorInDB);
                }
                return null;
            }
        }

        public DoctorDTO EditDoctorByID(DoctorDTO doctor, int id)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var doctorInDB = _mapper.Map<Doctor>(doctor);
                doctorInDB = entites.Doctors.SingleOrDefault(x => x.Id == id);
                if (doctorInDB != null)
                {
                    doctorInDB.Specielization = doctor.Specielization;
                    doctorInDB.PersonId = doctor.PersonId;
                    entites.SaveChanges();
                    return _mapper.Map<DoctorDTO>(doctorInDB);
                }
                return null;
            }
        }

        public DoctorDTO DeleteDoctor(DoctorDTO doctor)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var doctorInDB = entites.Doctors.SingleOrDefault(x => x.Id == doctor.Id);
                if (doctorInDB != null)
                {
                    entites.Doctors.Remove(doctorInDB);
                    entites.SaveChanges();
                    return _mapper.Map<DoctorDTO>(doctorInDB);
                }
                return null;
            }
        }

        public DoctorDTO EditDoctor(DoctorDTO doctor)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var doctorInDB = _mapper.Map<Doctor>(doctor);
                doctorInDB = entites.Doctors.SingleOrDefault(x => x.Id == doctor.Id);
                if (doctorInDB != null)
                {
                    doctorInDB.Specielization = doctor.Specielization;
                    doctorInDB.PersonId = doctor.PersonId;
                    entites.SaveChanges();
                    return _mapper.Map<DoctorDTO>(doctorInDB);
                }
                return null;
            }
        }

    }
}
