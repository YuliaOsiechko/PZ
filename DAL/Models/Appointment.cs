using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
