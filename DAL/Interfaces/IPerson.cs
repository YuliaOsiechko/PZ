using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPerson
    {
        List<PersonDTO> GetAllPerson();
        PersonDTO CreatePerson(PersonDTO person);
        PersonDTO DeletePersonByID(int id);
        PersonDTO EditPersonByID(PersonDTO person, int id);

    }
}
