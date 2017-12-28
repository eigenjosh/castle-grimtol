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
        public string DescriptionN { get; set; }
        public string DescriptionS { get; set; }
        public string DescriptionE { get; set; }
        public string DescriptionW { get; set; }

        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }

        public void UseItem(Item item)
        {

        }
    }
}