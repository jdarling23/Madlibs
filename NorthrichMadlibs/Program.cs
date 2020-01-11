using Models;
using System;
using System.Linq;

namespace NorthrichMadlibs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Define some variables for starters
            string studentName = "";
            bool askForName = true;
            Madlib studentData = new Madlib();

            //Kick off our shenanigans
            Console.WriteLine("Hello, Northrich Elementary!");
            Console.WriteLine("What's your name?");

            while (askForName)
            {
                studentName = Console.ReadLine();
                studentData = GetMadlibByStudentName(studentName);

                if (studentData != null)
                    askForName = false;
                else
                    Console.WriteLine("Hmm, I don't know anybody with that name! Seriously, what is it?");
            }

            //Print the madlib
            Console.WriteLine();
            Console.WriteLine($"It was a bright and sunny day outside of Northrich Elementary");
            Console.WriteLine($"and {studentData.StudentName} was sitting down to enjoy a nice helping of {studentData.FavoriteFood}.");
            Console.WriteLine($"Suddenly, a wild pack of {studentData.FavoriteNumber} {studentData.FavoriteColor} {studentData.FavoriteAnimal}s jumped out");
            Console.WriteLine($"and tried to steal {studentData.StudentName}'s {studentData.FavoriteFood}!");
            Console.WriteLine($"\"Hey\" cried {studentData.StudentName}. \"You can't take my food! According to Immanuel Kant, you are violating my personal autonomy!\"");
            Console.WriteLine($"\"Hmm,\" said one of the {studentData.FavoriteAnimal}s. \"You make a well reasoned point, and your logic is truly infallible. Let's just be friends!\"");
            Console.WriteLine($"So {studentData.StudentName} and the pack of {studentData.FavoriteColor} {studentData.FavoriteAnimal}s lived happily ever after.");
            Console.WriteLine($"The end!");

            //Pause so we can read
            Console.ReadLine();
        }

        private static Madlib GetMadlibByStudentName(string name)
        {
            Madlib madlib = new Madlib();

            using (var context = new MadlibContext())
            {
                madlib = context.Madlibs
                            .Where(m => m.StudentName == name)
                            .FirstOrDefault();
            }

            return madlib;
        }
    }
}
