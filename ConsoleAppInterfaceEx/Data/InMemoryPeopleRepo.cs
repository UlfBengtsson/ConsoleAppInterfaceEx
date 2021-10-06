using ConsoleAppInterfaceEx.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppInterfaceEx.Data
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {

        private static List<Person> peopleList = new List<Person>();

        public Person Create(Person person)
        {
            person.Id = Guid.NewGuid();
            peopleList.Add(person);
            return person;
        }

        public void Delete(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException();
            }
            peopleList.Remove(person);
        }

        public Person FindById(Guid id)
        {
            foreach (Person person in peopleList)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }

        public List<Person> GetAll()
        {
            return peopleList;
        }

        public void Update(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException();
            }

            Person oldPerson = FindById(person.Id);

            if (oldPerson == null)
            {
                throw new ArgumentNullException();
            }

            oldPerson.FirstName = person.FirstName;
            oldPerson.LastName = person.LastName;
        }
    }
}
