using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void Reset()
        {

        }

        public void Setup()
        {
            Room0 = new Room("Starting room", "A dimly lit room, the only source of light being a cracked, dusty skylight overhead. There is a large mound of refuse heaped against the south wall");
            Room1 = new Room("", "");
            Room2 = new Room("", "");
            Room3= new Room("", "");
            Room4 = new Room("", "");
            Room5 = new Room("", "");
            Room6 = new Room("", "");
            Room7 = new Room("", "");
            Room8 = new Room("", "");
            Room9 = new Room("", "");
            Room10 = new Room("", "");

            Pipe = new Item("Pipe", "An old lead pipe capped on one end, ")
        }

        public void UseItem(string itemName)
        {
            switch(itemName)
            {
                case pipe:
                System.Console.WriteLine("After several blows to the door's handle, the knob clatters to the ground and the door opens slightly.");
                    break;
                case bentKey:
                System.Console.WriteLine("The shank of the key is slightly bent enough to the point where it is unusable. Perhaps it can be bent back into shape?");
                    break;
            }
        }
    }
}