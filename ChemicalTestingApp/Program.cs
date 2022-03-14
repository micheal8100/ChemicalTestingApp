using System;
using System.Collections.Generic;
using System.Globalization;
namespace ChemicalTestingApp
{
    class Program
    {
        static List<string> chemicalname = new List<string>() { };
        static void Main(string[] args)
        {
            Console.WriteLine("************************************************\nHello and welcome to chemical testing app\n************************************************");
            bool flag1 = true;
            while (flag1)
            {
                Console.WriteLine("click 1 to contiune and test your chemical or click 2 to quit");
                int userAnswer = Convert.ToInt32(Console.ReadLine());
                if (userAnswer == 1)
                {
                    ChemicalTest();
                }
                else if (userAnswer == 2)
                {
                    flag1 = false;
                }
            }

        }
        static void ChemicalTest()
        {
            Console.WriteLine("please enter the name of your chemical");
            List<string> result = names.Split(',').ToList(Console.ReadLine());
            
        }
    }

}
