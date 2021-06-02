using System;

namespace DiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {

            bool onContinue = true;
            while(onContinue == true)
            {
                //user pick how many sides the dice have
                string input = GetUserInput("Please enter how many side you would like the pair of dice to have.");
                

                //test converting string to int for num sides
                int sides = -1;

                try
                {
                    sides = int.Parse(input);
                    Console.WriteLine($"Great, Dice have: {input} sides");
                    RollDice(sides);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number of side for the dice");

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Please enter a valid number of sides for the dice");
                    //continue;
                }

                onContinue = PickAgain();
            }

        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;

        }

        public static bool PickAgain()
        {
            Console.WriteLine("Would you like to roll the dice again? yes/no");
            string input = Console.ReadLine().ToLower().Trim();

            if(input == "yes" || input == "y")
            {
                Console.Clear();
                return true;
            }
            else if(input == "no" || input == "n")
            {
                Console.WriteLine("Goodbye");
                return false;
            }
            else
            {
                try
                {
                    input.ToString();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter yes or no");
                }
                Console.Clear();
                return PickAgain();
            }
        }

        public static void RollDice(int sides)
        {
            //create random num object
            Random dice = new Random();
            int roll1 = dice.Next(1, sides + 1);
            int roll2 = dice.Next(1, sides + 1);
            int total = roll1 + roll2;
            Console.WriteLine($"Dice1 roll: {roll1}");
            Console.WriteLine($"Dice2 roll: {roll2}");
            Console.WriteLine($"The total of the dice is: {total}");

            if(sides == 6)
            {
                SpecialRoll(roll1, roll2);
            }
        }

        public static void SpecialRoll(int num1, int num2)
        {
            int total = num1 + num2;
            if(num1 == 1 && num2 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Snake eyes...");
                Console.WriteLine("CRAP OUT, next shooter.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(num1 == 1 && num2 == 2 || num1 == 2 && num2 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ace Deuce");
                Console.WriteLine("CRAP OUT... next shooter up.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(num1 == 6 && num2 == 6)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Box cars! double sixes");
                Console.WriteLine("Pay the hard 12");
                Console.WriteLine("Crap out on 12");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(total == 12)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("12 on the dice, crap out");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if(total == 7 || total == 11)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Front line WINNER!");
                Console.WriteLine("Pay the passline");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
