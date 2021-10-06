using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppInterfaceEx.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Name: {FirstName} {LastName}";
        }
    }
}
