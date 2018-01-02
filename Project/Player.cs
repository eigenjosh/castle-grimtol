using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public Player()
        {
            Inventory = new List<Item>();
        }
        public string ShowInventory()
        {
            foreach(Item item in Inventory)
            {
                System.Console.WriteLine(item.Name);
                System.Console.WriteLine(item.Description);
            }
        }
        public int Score { get; set; }
        public List<Item> Inventory { get; set; }
    }
}