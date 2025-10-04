using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.Models
{
    public class Person(
        string firstName,
        string lastName
    )
    {
        private readonly string _firstName = firstName;
        private readonly string _lastName = lastName;

        public string FirstName => _firstName;
        public string LastName => _lastName;

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
}