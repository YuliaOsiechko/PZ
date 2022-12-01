using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Person
    {
        public Person()
        {
            Doctors = new HashSet<Doctor>();
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
