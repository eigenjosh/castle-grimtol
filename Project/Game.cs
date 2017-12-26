using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Item> Items { get; set; }

        public void Reset()
        {

        }
        public string Go(string input, Room room)
        {
            if (room == null)
            {
                throw new System.ArgumentNullException(nameof(room));
            }

            string direction = input.Split(" ")[3];
            Move(direction);
            return direction;
        }

        public void Move(string direction)
        {
            //given string direction
            //check if currentRoom.exits contains a key for directions
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                //but what if locked
                CurrentRoom = CurrentRoom.Exits[direction];
                System.Console.WriteLine(CurrentRoom.Description);
            }
            else
            {
                System.Console.WriteLine("nuh uh");
            }
        }

        public void Setup()
        {
            Rooms = new List<Room>();
            Room room1 = new Room()
            {
                Description = "This is room1",
                Name = "room1",
                Items = new List<Item>()
            };
            Room room2 = new Room()
            {
                Description = "This is room2",
                Name = "room2",
                Items = new List<Item>()
            };

            room1.Exits.Add(key: "n", value: room2);
            room2.Exits.Add(key: "s", value: room1);

            Room CurrentRoom = room1;
        }
        // Rooms = new List<Room>();
        // Room room1 = new Room()
        // {
        //     Description = "This is room1",
        //     Name = "room1",
        //     Items = new List<Item>()
        // };
        // Room room2 = new Room()
        // {
        //     Description = "This is room2",
        //     Name = "room2",
        //     Items = new List<Item>()
        // };
        public string GetUserInput(string input)
        {
            return input;
        }
        public string input = System.Console.ReadLine().ToString().ToLower();
        public void UseItem(string itemName)
        {

        }
    }
}