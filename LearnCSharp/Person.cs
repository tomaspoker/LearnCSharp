using System;
namespace LearnCSharp
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string MiddleName { get; } = "";
        public string LastName { get; private set; }

        public Person():this("", "", "")
        {

        }

        public Person(string first, string last) : this(first, "", last)
        {

        }

        public Person(string first, string middle, string last)
        {
            FirstName = first;
            MiddleName = middle;
            LastName = last;
        }

        public override string ToString() => $"{FirstName} {LastName}";

        public string AllCaps() => ToString().ToUpper();
    }
}
