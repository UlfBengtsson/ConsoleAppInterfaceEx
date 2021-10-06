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

        Person Create(string firstName, string lastname)
        {
            //Person person = new Person();
            //person.FirstName = firstName;
            //person.LastName = lastname;

            Person person = new Person() { FirstName = firstName, LastName = lastname };

            person = _peopleRepo.Create(person);

            return person;
        }
    }
}
