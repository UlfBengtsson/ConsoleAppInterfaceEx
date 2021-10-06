using ConsoleAppInterfaceEx.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppInterfaceEx.Data
{
    public interface IPeopleRepo
    {
        //C
        Person Create(Person person);

        //R
        Person FindById(Guid id);
        List<Person> GetAll();

        //U
        void Update(Person person);

        //D
        void Delete(Person person);
    }
}
