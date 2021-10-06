using ConsoleAppInterfaceEx.Data;
using ConsoleAppInterfaceEx.Models;
using ConsoleAppInterfaceEx.Services;
using System;
using System.Collections.Generic;

namespace ConsoleAppInterfaceEx
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleService _peopleService = new PeopleService(new FilePeopleRepo());

            Console.WriteLine("Hello People!");

            bool keepLooping = true;

            while (keepLooping)
            {
                Console.WriteLine("---- Menu ----\n1: List People\n2: Add person\n9: Quit");

                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        ListPeople(_peopleService);
                        break;
                    case '2':
                        AddPerson(_peopleService);
                        break;
                    case '9'://quit
                        keepLooping = false;
                        break;

                    default:
                        break;
                }
                if (keepLooping)
                {
                    PressAnyKeyTo("continue");
                }
            }
            PressAnyKeyTo("exit");
        }

        private static void PressAnyKeyTo(string endSentensWith)
        {
            Console.WriteLine("Press any key to " + endSentensWith);
            Console.ReadKey(true);
        }

        private static void AddPerson(PeopleService _peopleService)
        {
            _peopleService.Create(AskFor("Firstname"), AskFor("Lastname"));
        }

        private static string AskFor(string what)
        {
            Console.Write($"Please enter {what}: ");
            return Console.ReadLine();
        }

        private static void ListPeople(PeopleService _peopleService)
        {
            List<Person> people = _peopleService.GetPeople();

            Console.WriteLine("--- People list ---");
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine(people[i]);
            }
        }
    }
}
