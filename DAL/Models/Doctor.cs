using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            Patients = new HashSet<Patient>();
            Stuffs = new HashSet<Stuff>();
        }

        public int Id { get; set; }
        public string Specielization { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Stuff> Stuffs { get; set; }
    }
}
