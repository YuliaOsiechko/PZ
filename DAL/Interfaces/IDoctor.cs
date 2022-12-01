using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IDoctor
    {
        List<DoctorDTO> GetAllDoctor();
        DoctorDTO CreateDoctor(DoctorDTO doctor);
        DoctorDTO DeleteDoctorByID(int id);
        DoctorDTO EditDoctorByID(DoctorDTO doctor, int id);

    }
}
