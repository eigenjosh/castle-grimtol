using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public bool Playing;
        public string Response;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<Room> Rooms { get; set; }

        public void Reset()
        {

        }

        public void Setup()
        {
            Rooms = new List<Room>();

            Room room1 = new Room()
            {
                Description = "This is room 1",
                Name = "Room 1",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room room2 = new Room()
            {
                Description = "This is room 2",
                DescriptionN = "This is the north wall of room 2",
                Name = "Room 2",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()

            };
            Room room3 = new Room()
            {
                Description = "This is room 3",
                Name = "Room 3",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };

            room1.Exits.Add("north", room2);
            room2.Exits.Add("south", room1);
            room1.Exits.Add("east", room3);
            room3.Exits.Add("west", room1);

            CurrentRoom = room1;
        }

        public void Move(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
            }
            else
            {
                Console.WriteLine("");
            }
        }

        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
        public string GetUserInput()
        {
            Console.WriteLine("What would you like to do: ");
            return Console.ReadLine();
        }
        public void HandleUserInput(string Input)
        {
            if (Input.Contains(" "))
            {
                var choice = Input.Split(' ');
                var command = choice[0];
                var option = choice[1];
                if (command == "go")
                {
                    if (option == "n" || option == "north")
                    {
                        Move("north");
                    }
                    if (option == "s" || option == "south")
                    {
                        Move("south");
                    }
                    if (option == "e" || option == "east")
                    {
                        Move("east");
                    }
                    if (option == "w" || option == "west")
                    {
                        Move("west");
                    }
                }
                else if (command == "look" || command == "l")
                {
                    System.Console.WriteLine(CurrentRoom.Description);
                }
                else if (command == "inventory" || command == "i")
                {
                    if(CurrentPlayer.Inventory == null)
                    {
                        System.Console.WriteLine("You currently do not have any items.");
                    }
                    else
                    {
                    System.Console.WriteLine(CurrentPlayer.Inventory);
                    }
                }
            }
        }
    }
}