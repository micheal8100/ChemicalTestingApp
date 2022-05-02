using System;
using System.Collections.Generic;


namespace ChemicalTestingApp
{
    class Program
    {
        static int num = 0;
        static List<string> chemicalnames = new List<string>();
        static List<float> avgefficiencies = new List<float>();


        static void Main(string[] args)
        {
            Console.WriteLine("************************************************\nHello and welcome to Chemical Testing App\n************************************************");
            bool flag1 = true;
            
            while (flag1)
            {

                int userAnswer = Checkint("click 1 to test a chemical or click 2 to quit", 1, 2);
                if (userAnswer == 1)
                {
                    ChemicalTest();
                }
                else if (userAnswer == 2)
                {
                    //sort the the list biggest to smallest
                    for (int leftpointer = 0; leftpointer < avgefficiencies.Count - 1; leftpointer++)
                    {
                        for (int rightpointer = leftpointer + 1; rightpointer < avgefficiencies.Count; rightpointer++)
                        {
                            if (avgefficiencies[leftpointer] < avgefficiencies[rightpointer])
                            {
                                float floattemp = avgefficiencies[leftpointer];
                                avgefficiencies[leftpointer] = avgefficiencies[rightpointer];
                                avgefficiencies[rightpointer] = floattemp;

                                string stringtemp = chemicalnames[leftpointer];
                                chemicalnames[leftpointer] = chemicalnames[rightpointer];
                                chemicalnames[rightpointer] = stringtemp;
                            }
                        }
                    }
                    //if they only enterd one chemical
                    if (num == 1)
                    {
                        Console.WriteLine($"************************************************\n{chemicalnames[0]} had an efficiency of {avgefficiencies[0]}");
                    }
                    //if they enterd more then one
                    if (num > 1)
                    {
                        Console.WriteLine($"************************************************\nThe most efficient chemical is {chemicalnames[0]} with a rating of {avgefficiencies[0]}." +
                            $"\nThe least efficient chemical is {chemicalnames[num - 1]} with a rating of {avgefficiencies[num - 1]}.\n");
                    }

                    //if the enter 6 or more
                    if (num >= 6)
                    {
                        Console.WriteLine(
                            $"The top three chemicals you enter where\n" +
                            $"{chemicalnames[0]} with an effiency of {avgefficiencies[0]}\n" +
                            $"{chemicalnames[1]} with an effiency of {avgefficiencies[1]}\n" +
                            $"{chemicalnames[2]} with an effiency of {avgefficiencies[2]}.\n\n" +
                            $"The bottom three chemicals you enter where\n" +
                            $"{chemicalnames[num - 1]} with an effiency of {avgefficiencies[num - 1]}\n" +
                            $"{chemicalnames[num - 2]} with an effiency of {avgefficiencies[num - 2]}\n" +
                            $"{chemicalnames[num - 3]} with an effiency of {avgefficiencies[num - 3]}.");
                    }

                    Console.WriteLine("\nThank you for using Chemical Testing App\n" +
                        "************************************************\n");
                    //ending the program
                    flag1 = false;
                }
            }

        }

        static void ChemicalTest()
        {
            bool chem_test_flag = true;
            while (chem_test_flag)
            {
                string chemname = CheckString("************************************************\nplease enter the name of your chemical");


                //check if they have already enter this chemical
                if (!chemicalnames.Contains(chemname))
                {
                    chemicalnames.Add(chemname);
                    chem_test_flag = false;
                }
                else
                {
                    Console.WriteLine("ERROR: You have already entered this chemical");
                }
            }

            float allefficiency = 0;

            num++;

            for (int loop = 0; loop < 5; loop++)
            {
                //live grems in sample
                Random rndn = new Random();

                //starting amount
                int liveGremStart = rndn.Next(50, 1000);

                //amount after test
                int liveGremEnd = rndn.Next(0, liveGremStart);

                //efficiency
                float efficiency = (liveGremStart - liveGremEnd) / 30;
                //display 
                Console.WriteLine($"\n************************************************\nafter 30 sceonds grems in the sample went from {liveGremStart} to {liveGremEnd}\nthe efficiency was {efficiency}\n");

                allefficiency = efficiency + allefficiency;
            }

            avgefficiencies.Add((float)Math.Round(allefficiency / 5, 2));
            Console.WriteLine($"\n************************************************\n{chemicalnames[num - 1]} had an average efficiency of {avgefficiencies[num - 1]}\n\n************************************************");




        }


        static int Checkint(string question, int min, int max)
        {
            int user_choice = 0;
            while (true)
            {
                Console.WriteLine(question);
                try
                {
                    user_choice = Convert.ToInt32(Console.ReadLine());
                    if (user_choice >= min && user_choice <= max)
                    {
                        return user_choice;
                    }

                    else
                    {
                        Console.WriteLine($"ERROR: Input mustbbe a number between {min} and {max}");
                    }
                }
                catch
                {
                    Console.WriteLine($"ERROR: Input mustbbe a number between {min} and {max}");
                }

            }
        }
        static string CheckString(string question)
        {
            string user_answer;
            while (true)
            {
                try
                {

                    Console.WriteLine(question);
                    user_answer = Console.ReadLine();

                    if (user_answer != "")
                    {
                        user_answer = char.ToUpper(user_answer[0]) + user_answer.Substring(1);
                        return user_answer;
                    }
                    Console.WriteLine("ERROR:You have not enterd anything");
                }
                catch { Console.WriteLine("ERROR:You have not enterd anything"); }
            }
        }
    }
}