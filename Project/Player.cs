using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public List<Item> Inventory { get; set; }
        public int Score { get; set; }
        public Player()
        {
            Score = 0;
            Inventory = new List<Item>();
        }
    }
}