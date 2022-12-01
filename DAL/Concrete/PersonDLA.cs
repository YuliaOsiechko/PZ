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
    public class PersonDLA : IPerson
    {
        private readonly IMapper _mapper;
        public PersonDLA(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PersonDTO CreatePerson(PersonDTO person)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var personInDB = _mapper.Map<Person>(person);
                entites.People.Add(personInDB);
                entites.SaveChanges();
                return _mapper.Map<PersonDTO>(personInDB);
            }
        }

        public List<PersonDTO> GetAllPerson()
        {
            using (var entities = new OnlineRegistrationContext())
            {
                var persons = entities.People.ToList();
                return _mapper.Map<List<PersonDTO>>(persons);
            }
        }


        public PersonDTO DeletePersonByID(int id)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var personInDB = entites.People.SingleOrDefault(x => x.Id == id);
                if (personInDB != null)
                {
                    entites.People.Remove(personInDB);
                    entites.SaveChanges();
                    return _mapper.Map<PersonDTO>(personInDB);
                }
                return null;
            }
        }

        public PersonDTO EditPersonByID(PersonDTO person, int id)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var personInDB = _mapper.Map<Person>(person);
                personInDB = entites.People.SingleOrDefault(x => x.Id == id);
                if (personInDB != null)
                {
                    personInDB.Name = person.Name;
                    personInDB.Phone = person.Phone;
                    personInDB.Address = person.Address;
                    entites.SaveChanges();
                    return _mapper.Map<PersonDTO>(personInDB);
                }
                return null;
            }
        }

        public PersonDTO DeletePerson(PersonDTO person)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var personInDB = entites.People.SingleOrDefault(x => x.Id == person.Id);
                if (personInDB != null)
                {
                    entites.People.Remove(personInDB);
                    entites.SaveChanges();
                    return _mapper.Map<PersonDTO>(personInDB);
                }
                return null;
            }
        }

        public PersonDTO EditPerson(PersonDTO person)
        {
            using (var entites = new OnlineRegistrationContext())
            {
                var personInDB = _mapper.Map<Person>(person);
                personInDB = entites.People.SingleOrDefault(x => x.Id == person.Id);
                if (personInDB != null)
                {
                    personInDB.Name = person.Name;
                    personInDB.Phone = person.Phone;
                    personInDB.Address = person.Address;
                    entites.SaveChanges();
                    return _mapper.Map<PersonDTO>(personInDB);
                }
                return null;
            }
        }
    }
}

