using System;

namespace RockPaperSissors
{
    class Program
    {
        static void Main(string[] args)
        {
            RunRoshambo();

        }

        private static void RunRoshambo()
        {
            var userPlayer = RoshamboApp.AskAndCreateUserPlayer();
            Console.WriteLine($"Welcome {userPlayer.Name}!");

            bool shouldContinue = true;
            while (shouldContinue)
            {
                var villain = RoshamboApp.AskAndDetermineOpponent();
                Console.WriteLine($"You chose {villain.Name}");

                userPlayer.RoshamboValue = userPlayer.generateRoshambo();
                Console.WriteLine($"You picked {userPlayer.RoshamboValue}!");
                villain.RoshamboValue = villain.generateRoshambo();
                Console.WriteLine($"{villain.Name} picked {villain.RoshamboValue}!");

                Console.WriteLine(RoshamboApp.CompareAndDetermineWinner(userPlayer, villain));
                shouldContinue = RoshamboApp.PlayAgain();
            }
        }
    }

    // Create enumeration called Roshambo that stores Rock, Paper, Sissors

    public enum Roshambo
    {
        Rock = 0,
        Paper = 1,
        Sissors = 2
    }

    // Create abstract class named player that stores a name and a Roshambo value
    // Class should contain abstract method name generateRoshambo that allows an
    // inheriting class to generate and return a roshambo value.

    public abstract class Player 
    {
        public string Name { get; set; }
        public Roshambo RoshamboValue { get; set; }

        public virtual Roshambo generateRoshambo() 
        {
            var rnd = new Random();
            var rndRoll = rnd.Next(0, 3);
            if (rndRoll == 0)
            {
                return Roshambo.Rock;
            }
            else if (rndRoll == 1)
            {
                return Roshambo.Paper;
            }
            else 
            {
                return Roshambo.Sissors;
            }
        }
    }

    // Create 2 player classes. One always rock. Other, random.
    public class RockLee : Player
    {
        public RockLee()
        {
            Name = "RockLee";
            RoshamboValue = Roshambo.Rock;
        }

        public override Roshambo generateRoshambo()
        {
            return Roshambo.Rock;
        }
    }

    public class Randy : Player
    {
        public Randy()
        {
            Name = "Randy";
            RoshamboValue = base.generateRoshambo();
        }

    }

    // Create third player class that inherits Player and implements
    // Roshambo method

    public class ThirdPlayerClass : Player 
    {
        public ThirdPlayerClass(string name)
        {
            Name = name;
        }

        public override Roshambo generateRoshambo()
        {

            while (true)
            {
                Console.WriteLine("Pick one:");
                Console.WriteLine("[1]: Rock");
                Console.WriteLine("[2]: Paper");
                Console.WriteLine("[3]: Sissors");

                if (uint.TryParse(Console.ReadLine(), out uint userChoice) && userChoice < 4)
                {
                    if (userChoice == 1)
                    {
                        return Roshambo.Rock;
                    }
                    else if (userChoice == 2)
                    {
                        return Roshambo.Paper;
                    }
                    else
                    {
                        return Roshambo.Sissors;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid selection");
                }
            } 
        }
    }

    public static class RoshamboApp 
    {
        public static Player AskAndCreateUserPlayer() 
        {
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            return new ThirdPlayerClass(userName);
        }
        public static Player AskAndDetermineOpponent() 
        {
            while (true)
            {
                Console.WriteLine("Who would you like to play against?");
                Console.WriteLine("[1]: RockLee!");
                Console.WriteLine("[2]: Random Randy!");

                if (uint.TryParse(Console.ReadLine(), out uint userChoice) && userChoice < 3)
                {
                    if (userChoice == 1)
                    {
                        return new RockLee();
                    }
                    else return new Randy();
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                }
            } 
        }

        public static Player RollAgain(Player player) 
        {
            player.RoshamboValue = player.generateRoshambo();
            return player;
        }

        public static string CompareAndDetermineWinner(Player userPlayer, Player villain) 
        {
            if (userPlayer.RoshamboValue == Roshambo.Rock && villain.RoshamboValue == Roshambo.Rock || userPlayer.RoshamboValue == Roshambo.Paper && villain.RoshamboValue == Roshambo.Paper || userPlayer.RoshamboValue == Roshambo.Sissors && villain.RoshamboValue == Roshambo.Sissors)
            {
                return "You tied!";
            }
            else if (userPlayer.RoshamboValue == Roshambo.Rock && villain.RoshamboValue == Roshambo.Paper || userPlayer.RoshamboValue == Roshambo.Paper && villain.RoshamboValue == Roshambo.Sissors || userPlayer.RoshamboValue == Roshambo.Sissors && villain.RoshamboValue == Roshambo.Rock)
            {
                return $"{villain.Name} has won!";
            }
            else 
            {
                return $"{userPlayer.Name} has won!";
            }
        }

        public static bool PlayAgain()
        {

            while (true)
            {
                Console.WriteLine("Would you like to:");
                Console.WriteLine("[1]: Play Again?");
                Console.WriteLine("[2]: Quit");
                if (uint.TryParse(Console.ReadLine(), out uint userChoice) && userChoice < 3)
                {
                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Let's Play Again!");
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                }
            }
        }
    }

}
