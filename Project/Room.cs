using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
            Exits = new Dictionary<string, Room>();
            // Contextual = new Dictionary<string, Room>();
            Locked = true;
        }

        public bool Locked { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionN { get; set; }
        public string DescriptionS { get; set; }
        public string DescriptionE { get; set; }
        public string DescriptionW { get; set; }

        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }

        //The Contextual Dict. is a WIP and may end up getting scrapped.
        //...Anyway, as its name might imply, it is a dictionary of commands that are only valid for certain rooms under specific circumstances.
        //For example, in the starting room, the player must first input "get up"(or some variation of which the parser will *hopefully* handle accordingly) in order to do anything other than look around the room.
        //In theory, the "get up" Contextual should only be able to be input for a valid response once, after which all cw's will return something to the effect of "You are already standing."
        // public Dictionary<string, Room> Contextual { get; set; }

        public void UseItem(Item item)
        {

        }
    }
}