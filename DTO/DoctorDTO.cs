using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Specielization { get; set; }
        public int PersonId { get; set; } 

        public override string ToString()
        {
            return $"|{Id,-3}|{Specielization,-20}|{PersonId,-5}|";
        }
    }
}
