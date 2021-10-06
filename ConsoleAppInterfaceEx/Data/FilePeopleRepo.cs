using ConsoleAppInterfaceEx.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAppInterfaceEx.Data
{
    public class FilePeopleRepo : IPeopleRepo
    {

        private static List<Person> peopleList;

        public FilePeopleRepo()
        {
            ReadPeopleFile();
        }

        private void ReadPeopleFile()
        {
            List<Person> people = new List<Person>();

            try
            {
                using (StreamReader reader = new StreamReader("people.txt"))
                {
                    while (true)
                    {
                        string id = reader.ReadLine();
                        if (id == null)
                        {
                            break;
                        }
                        string firstName = reader.ReadLine();
                        string lastName = reader.ReadLine();

                        people.Add(new Person() { Id = Guid.Parse(id), FirstName = firstName, LastName = lastName });
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("File not found.");
            }
            
            peopleList = people;
        }

        private void SavePeopleFile()
        {
            using (StreamWriter writer = new StreamWriter("people.txt"))
            {
                foreach (Person person in peopleList)
                {
                    writer.WriteLine(person.Id);
                    writer.WriteLine(person.FirstName);
                    writer.WriteLine(person.LastName);
                }
            }
        }

        public Person Create(Person person)
        {
            person.Id = Guid.NewGuid();
            peopleList.Add(person);

            SavePeopleFile();

            return person;
        }

        public void Delete(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException();
            }
            if(peopleList.Remove(person))
            {
                SavePeopleFile();
            }
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

            SavePeopleFile();
        }
    }
}
