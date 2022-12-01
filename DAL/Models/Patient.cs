using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int FamilyDoctorId { get; set; }

        public virtual Doctor FamilyDoctor { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
