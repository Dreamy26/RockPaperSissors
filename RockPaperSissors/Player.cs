using System;

namespace RockPaperSissors
{
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

}
