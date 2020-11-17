namespace RockPaperSissors
{
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

}
