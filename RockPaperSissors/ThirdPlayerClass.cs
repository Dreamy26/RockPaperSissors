using System;

namespace RockPaperSissors
{
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

}
