using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadaxChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // To display game instructions
            GameMenu();
            Console.ReadKey();
        }

        private static void GameMenu()
        {
            Console.WriteLine("***********************************************************************************************");
            Console.WriteLine("Welcome to Quadax Master Mind Game");
            Console.WriteLine("By Kush Patel");
            Console.WriteLine("***********************************************************************************************");

            Console.WriteLine("Here are the rules:");
            Console.WriteLine("1- The game will generate four random numbers between 1-6");
            Console.WriteLine("2- you need to guess the correct four numbers");
            Console.WriteLine("3- a Minus sign (-) will appear if you guessed the correct number, but the wrong position");
            Console.WriteLine("4- a Plus sign (+) will appear if you guessed the correct number and the correct position");
            Console.WriteLine("5- Nothing will show if didn't guess a corecct number");
            Console.WriteLine("6- you will have only 10 attempts");
            Console.WriteLine("***********************************************************************************************");


            Console.Write("Let's play, ");
            Console.WriteLine("Are you ready?? y/n");
            // To read the user input.. If you enter "y" you'll get into the game. Anything else you'll exit.
            var input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                // To start the game
                StartGame();
            }
            else
            {
                // to exit the game
                Environment.Exit(0);
            }


        }

        private static void StartGame()
        {
            // initiate the list for random numbers
            List<int> randomNumber = new List<int>();
            // initiate the player picks
            int[] PlayerNumbers = new int[4];
            // To get the random numbers
            randomNumber = GenerateRandomNumber();
            // An array to check the matching picks
            string[] checks = new string[4];
            // counter for the while loop
            int attempts = 9;
            while (attempts >= 0)
            {
                // Allow the player to pick four numbers
                PlayerNumbers = PlayerPicks();
                // To match the picks
                checks = CheckTheNumbers(randomNumber, PlayerNumbers);
                // To diplay the result
                PlayerResult(checks, attempts, randomNumber);
                attempts -= 1; // every time it deducts when you get a false attempt
            }

        }

        private static void PlayerResult(string[] checks, int attempts, List<int> randomNumber)
        {
            // When all check indexes are correct and also a correct position
            if (checks[0] == "+" && checks[1] == "+" && checks[2] == "+" && checks[3] == "+")
            {
                Console.WriteLine("You got it right this time");
                Console.WriteLine("***********************************************************************************************");
                Console.WriteLine("Do you want to play again? y/n");
                var input = Console.ReadLine();
                if (input.ToUpper() == "Y")
                {
                    // To restart the game
                    StartGame();
                }
                else
                {
                    // To exit
                    Environment.Exit(0);
                }
            }
            // when user left with the last attempt
            else if (attempts == 1)
            {
                Console.WriteLine("This is your last chance");
                Console.WriteLine("***********************************************************************************************");
            }
            // No attempt left
            else if (attempts == 0)
            {
                Console.WriteLine("You lost!");
                Console.Write("The Number were:");
                Console.WriteLine(randomNumber[0] + "," + randomNumber[1] + "," + randomNumber[2] + "," + randomNumber[3]);
                Console.WriteLine("***********************************************************************************************");
                Console.WriteLine("Do you want to play again? y/n");
            }
            else
            {
                // To get the remaining attempt(s) as a string
                var remaining = (attempts).ToString();
                Console.WriteLine("Try again!!");
                Console.WriteLine("You have " + remaining + " attempt(s) left.");
                Console.WriteLine("***********************************************************************************************");

            }
        }

        private static string[] CheckTheNumbers(List<int> randomNumber, int[] playerNumbers)
        {
            // Hold the value to return
            string[] signs = new string[4];
            // Loop through the player's picks/numbers
            for (int p = 0; p < playerNumbers.Length; ++p)
            {
                // Loop through number which has been generated randomly
                for (int r = 0; r <= randomNumber.Count - 1; ++r)
                {
                    // If there is a match
                    if (playerNumbers[p] == randomNumber[r])
                    {
                        // If there is a match at the same position
                        if (p == r)
                        {
                            signs[p] = "+";
                            break;
                        }
                        // If there is a match at the different position
                        else
                        {
                            signs[p] = "-";
                            break;
                        }
                    }
                    // No match
                    else
                    {
                        signs[p] = " ";
                    }
                }
            }
            Console.WriteLine("Result:");
            Console.WriteLine(signs[0] + "," + signs[1] + "," + signs[2] + "," + signs[3]);
            return signs;
        }

        private static int[] PlayerPicks()
        {
            // Hold the value to return 
            int[] player = new int[4];
            Console.WriteLine("Pick a number between 1-6");
            // Loop through four times to pick four numbers
            for (int i = 0; i < 4; ++i)
            {
                try
                {
                    player[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("You need to pick a number. Don't enter empty value");
                    player[i] = Convert.ToInt32(Console.ReadLine());
                }

            }
            Console.WriteLine("Your Picks:");
            Console.WriteLine(player[0] + "," + player[1] + "," + player[2] + "," + player[3]);
            return player;
        }

        private static List<int> GenerateRandomNumber()
        {
            // Create an object of Random class
            Random rnd = new Random();
            // Hold the value to return
            List<int> randomNumber = new List<int>();
            int random;
            // Runs until the count hit the 4th item
            while (randomNumber.Count < 4)
            {
                // To save the random number
                random = rnd.Next(1, 7);
                // To avoid generating duplicate numbers into the list
                if (!randomNumber.Contains(random))
                {
                    randomNumber.Add(random);
                }
            }
            return randomNumber;
        }
    }
}
