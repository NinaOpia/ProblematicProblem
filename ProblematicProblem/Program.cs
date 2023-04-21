using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            while (cont)
            {
                Console.WriteLine("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
                //cont = bool.Parse(Console.ReadLine());

                var contResponse = Console.ReadLine();
                if (contResponse == "yes")
                {
                    cont = true;
                }
                else
                {
                    cont = false;
                    Environment.Exit(0);
                }

                Console.WriteLine();
                Console.WriteLine("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("What is your age? ");
                int userAge = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Would you like to see the current list of activities? Sure/No thanks: ");
                //bool seeList = bool.Parse(Console.ReadLine());

                contResponse = Console.ReadLine().ToLower();

                bool seeList = (contResponse == "sure") ? true : false; //bool seeList = (contResponse);

                if (seeList) //Same as (seeList == true)
                {
                    foreach (string activity in activities)
                    {
                        Console.WriteLine($"{activity} ");
                        Thread.Sleep(250); //250 is in miliseconds which is same as 1/4 of a second.
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add any activities before we generate one? yes/no: ");
                    //bool addToList = bool.Parse(Console.ReadLine());

                    contResponse = Console.ReadLine().ToLower();

                    bool addToList = (contResponse == "yes");

                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.WriteLine("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.WriteLine($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        //addToList = bool.Parse(Console.ReadLine());
                        contResponse = Console.ReadLine().ToLower();

                        addToList = (contResponse == "yes");
                    }
                }

                while (cont)
                {
                    Console.WriteLine("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.WriteLine(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Random rng = new Random();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];
                    if (userAge > 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    //cont = bool.Parse(Console.ReadLine());

                    cont = (Console.ReadLine().ToLower() == "redo") ? true : false;
                }
            }
        }
    }
}