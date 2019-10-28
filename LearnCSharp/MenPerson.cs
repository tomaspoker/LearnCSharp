using System;
namespace LearnCSharp
{
    public class MenPerson : Person
    {
        private int m_Sex;

        public int Sex { get => m_Sex; set => m_Sex = value; }

        public MenPerson()
        {

        }

        public MenPerson(string first, string last, int sex) : base(first, "", last)
        {
            Sex = sex;
        }

        override public string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
