using System;
using System.Collections.Generic; 
using System.Threading;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Reflection.Metadata.Ecma335;

public class Program
{
    public static Random rng = new Random(); 

    static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

    static void Main(string[] args)
    {
        Console.Write(" Hello, welcome to the random activity generator! \n Would you like to generate a random activity? yes/no: ");
        string input = Console.ReadLine()?.Trim().ToLower();
        
        bool cont = input == "yes";

        if (input != "yes" && input != "no" )
        {
            Console.WriteLine(" Please enter 'yes' or 'no'.");
        }
        else if (input == "no")
        {
            Console.WriteLine(" Your mom"); 
            Environment.Exit(0);
        }

            Console.WriteLine();

        Console.Write(" We are going to need your information first! What is your name?");

        string userName = Console.ReadLine(); 

        while (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine(" Please enter you name.");
            userName = Console.ReadLine();
        }

        Console.WriteLine();

        Console.Write(" What is your age?");
        bool isAge = int.TryParse(Console.ReadLine(), out int userAge);

        if (isAge)
        {
            Console.WriteLine($" Thank you! It seems you are {userAge} years old, {userName}.");
        }
        else
        {
            Console.WriteLine(" That was not a valid age"); 
        }

        Console.WriteLine();

        Console.Write(" Would you like to see the current list of activities? yes/no: ");
        string seeList = Console.ReadLine()?.Trim().ToLower();

        bool theList = seeList == "yes";

        if (theList)
        {
            foreach (string activity in activities)
            {
                Console.Write($"{activity} ");

                Thread.Sleep(500);
            }
        }

        else
        {
            Console.WriteLine(" Okay!"); 
        }

        Console.WriteLine();

        Console.Write(" Would you like to add any activities before we generate one? yes/no: ");
        string areAddingActivities = Console.ReadLine()?.Trim().ToLower();

        bool addToList = areAddingActivities == "yes";
        
        if (areAddingActivities !=  "yes")
        {
            Console.WriteLine(" Rodger!"); 
        }

         while (addToList)
         {
            Console.Write(" What would you like to add? ");
                
            string userAddition = Console.ReadLine();


                if (string.IsNullOrEmpty(userAddition))
                {
                    Console.WriteLine(" Please enter a valid activity.");
                    continue;
                }

            activities.Add(userAddition);

            Console.WriteLine(" In the currently list of activities, we have:");
                foreach (string activity in activities)
                {

                    Console.Write($"{activity} ");

                    Thread.Sleep(500);
                }

            Console.WriteLine("\n");

            Console.WriteLine(" Would you like to add more? yes/no: ");
            string continueAddingActivities = Console.ReadLine()?.Trim().ToLower();

            if (continueAddingActivities == "no")
            {
                Console.WriteLine($" Looks like we have everything you want on the list then {userName}. ");
                break;
            }
            else if (continueAddingActivities != "yes")
            {
                Console.WriteLine(" Please type 'yes' or 'no' to continue");
                continue; 
            }
         }
    

        while (cont)
        {
            Console.Write(" Connecting to the database");

            for (int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }

            Console.WriteLine();

            Console.Write(" Choosing your random activity");

            for (int i = 0; i < 9; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }

            Console.WriteLine();



            int randomNumber = rng.Next(activities.Count);

            string randomActivity = activities[randomNumber];

            if (userAge < 21 && randomActivity == "Wine Tasting")
            {
                Console.WriteLine($" Oh no! Looks like you are too young to do {randomActivity}");

                Console.WriteLine(" Pick something else!");

                activities.Remove(randomActivity);

                randomNumber = rng.Next(activities.Count);

                randomActivity = activities[randomNumber];
            }

            Console.Write($" Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
            string generateAnotherActivity = Console.ReadLine()?.Trim().ToLower();

            Console.WriteLine();

            bool redo = generateAnotherActivity == "redo";

            if (redo)
            {
                continue;
            }

            else
            {
                Console.WriteLine($" Enjoy {randomActivity}, {userName}! ");
                break; 
            }

        }
    }

}

