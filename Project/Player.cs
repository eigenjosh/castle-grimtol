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
        public void ShowInventory(Player player)
        {
            System.Console.WriteLine("\nYour inventory:\n");
            for (int i = 0; i < player.Inventory.Count; i++)
            {
                System.Console.WriteLine($"{player.Inventory[i].Name}");
                System.Console.WriteLine($"{player.Inventory[i].Description}\n");
            }
        }
    }
}