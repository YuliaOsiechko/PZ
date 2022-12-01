using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"|{Id,-3}|{Name,-30}|{Phone,-18}|{Address,-50}|";
        }
    }
}
