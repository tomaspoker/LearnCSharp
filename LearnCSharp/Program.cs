using System;
using System.Linq;
using System.Collections.Generic;

namespace LearnCSharp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var men = new MenPerson("Tomas", "Wilson", 2);

            Console.WriteLine(men.Sex);
        }

        private static bool LogException(Exception e)
        {
            Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
            Console.WriteLine($"\tMessage: {e.Message}");
            return true;
        }
    }
}
