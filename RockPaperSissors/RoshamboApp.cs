using System;

namespace RockPaperSissors
{
    public enum Roshambo
    {
        Rock = 0,
        Paper = 1,
        Sissors = 2
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
