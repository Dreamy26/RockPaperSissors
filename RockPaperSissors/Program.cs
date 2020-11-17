using System;

namespace RockPaperSissors
{
    class Program
    {
        static void Main(string[] args)
        {
            RunRoshambo();
        }

        public static void RunRoshambo()
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
}
