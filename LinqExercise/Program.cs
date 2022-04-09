using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Average: {numbers.Average()}");


            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(x => x);
            foreach (var number in ascending)
                Console.WriteLine(number);

            Console.WriteLine("------------");

            var descending = numbers.OrderByDescending(x => x);
            foreach (var number in descending)
                Console.WriteLine(number);

            Console.WriteLine("------------");

            //Print to the console only the numbers greater than 6
            var only6 = numbers.Where(x => x > 6);
            foreach (var number in only6)
                Console.WriteLine(number);

            Console.WriteLine("------------");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            foreach (var num in descending.Take(4))
                Console.WriteLine(num);

            Console.WriteLine("------------");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers.SetValue(22, 4);
            foreach (var number in numbers)
                Console.WriteLine(number);

            Console.WriteLine("------------");

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var filtered = employees.Where(person => person.FirstName.ToLower().StartsWith('c') 
            || person.FirstName.ToLower()[0] == 's')
                .OrderBy(person => person.FirstName);

            foreach (var employee in filtered)
                Console.WriteLine(employee.FullName);

            Console.WriteLine("------------");


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var twentySix = employees.Where(x => x.Age > 26)
                .OrderByDescending(x => x.Age)
                .ThenBy(x => x.FirstName);

            foreach(var employee in twentySix)
                Console.WriteLine(employee.FullName);

            Console.WriteLine("------------");

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var sumAndYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            Console.WriteLine($"Total YOE: {sumAndYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Avg YOE: {sumAndYOE.Average(x => x.YearsOfExperience)}");


            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Morgan", "Fulbright", 22, 0)).ToList();
            //employees.ForEach(x => Console.WriteLine(x.FullName));

            foreach(var employee in employees)
                Console.WriteLine(employee.FullName);


            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
