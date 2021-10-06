using ConsoleAppInterfaceEx.Data;
using ConsoleAppInterfaceEx.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppInterfaceEx.Services
{
    public class PeopleService
    {
        IPeopleRepo _peopleRepo;

        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }

        public Person Create(string firstName, string lastname)
        {
            if (string.IsNullOrWhiteSpace(firstName) && firstName.Length < 2)
            {
                throw new ArgumentException("Firstname can´t be empty or blank");
            }
            if (string.IsNullOrWhiteSpace(lastname) && lastname.Length < 2)
            {
                throw new ArgumentException("Lastname can´t be empty or blank");
            }

            //Person person = new Person();
            //person.FirstName = firstName;
            //person.LastName = lastname;

            Person person = new Person() { FirstName = firstName, LastName = lastname };

            person = _peopleRepo.Create(person);

            return person;
        }

        public Person FindById(Guid id)
        {
            return _peopleRepo.FindById(id);
        }

        public List<Person> GetPeople()
        {
            return _peopleRepo.GetAll();
        }

        public Person Edit(Guid id, string firstName, string lastName)
        {
            Person tempPerson = new Person() { Id = id, FirstName = firstName, LastName = lastName };
            
            _peopleRepo.Update(tempPerson);

            return _peopleRepo.FindById(id);
        }

        public bool Remove(Guid id)
        {
            _peopleRepo.Delete(_peopleRepo.FindById(id));

            if (_peopleRepo.FindById(id) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
