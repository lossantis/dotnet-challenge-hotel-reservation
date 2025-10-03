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
        public string FirstName { get; } = firstName;
        public string LastName { get; } = lastName;
    
        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }
    }
}