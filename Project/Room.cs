using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public Room()
        {
            Name = Name;
            Description = Description;
            Items = new List<Item>();
            Exits = new Dictionary<string, Room>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }

        public void UseItem(Item item)
        {
            
        }
        public Room AddExit(Room CurrentRoom, string direction)
        {
            if(direction.Equals("n"))
            {
                CurrentRoom.Exits.Add("s", CurrentRoom);
                return CurrentRoom;
            }
            else
            {
                throw new System.ArgumentException { };
            }
        }
    }
}