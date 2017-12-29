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

            Room StorageRoom = new Room("Storage Room 0", @"A single skylight, cracked and yellowing from age, provides barely enough light to see that you are in some sort of dilapidated storage room.
Two rows of metal shelves stand near the wall to your right (east).
A heap of black garbage bags lay against the opposing wall.")
            {
                //Rooms[0]
                Description = @"A single skylight, cracked and yellowing from age, provides barely enough light to see that you are in some sort of dilapidated storage room.
Two rows of metal shelves stand near the wall to your right (east).
A heap of black garbage bags lay against the opposing wall.",
                DescriptionE = @"After allowing your eyes to adjust to the low light, you think you can make out what looks like a metal pipe, roughly forearm-length and capped at one end.",
                DescriptionW = @"Using your hands to feel around the trash bags, you hear something small and metal fall onto the concrete floor.",
                DescriptionN = "A door leading out of the storage room",
                DescriptionS = "A simple white brick wall. Squinting your eyes, you can see an externally mounted electrical outlet near the bottom of the wall.",
                Name = "Storage Room 0",
                Items = new List<Item>(),
                //pipe
                //bent key
                Exits = new Dictionary<string, Room>()
                //north to corridor (Rooms[1])
            };
            Room Corridor0 = new Room("Corridor 0", "You find yourself in a corridor, leading East and nowhere else.")
            {
                //Rooms[1]
                Description = "You find yourself in a corridor, leading East and nowhere else.",
                DescriptionN = "This is the north wall of Corridor 0",
                Name = "Room 2",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()

            };

            Item pipe = new Item("pipe", "A metal pipe, about forearm-length and capped on one end.");
            StorageRoom.Items.Add(pipe);
            StorageRoom.Exits.Add("north", Corridor0);
            StorageRoom.Contextual.Add("get up", StorageRoom);
            Corridor0.Exits.Add("south", StorageRoom);
            CurrentRoom = StorageRoom;
        }

        public void Move(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
            }
            else
            {
                Console.WriteLine("You cannot move in that direction.");
            }
        }

        public void UseItem(string name)
        {

        }
        public string GetUserInput()
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.WriteLine("What would you like to do?");
            Console.ResetColor();
            return Console.ReadLine();
        }
        public void HandleUserInput(string Input)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.BackgroundColor = ConsoleColor.Black;
            if (Input.Contains(" "))
            {
                var choice = Input.Split(" ");
                var command = choice[0];
                var option = choice[1];
                var context = choice[3];
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
                    if (option == "n" || option == "north")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionN);
                    }
                    if (option == "s" || option == "south")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionS);
                    }
                    if (option == "e" || option == "east")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionE);
                    }
                    if (option == "w" || option == "west")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionW);
                    }
                    if (option == "at")
                    {
                        if (context == "shelves" || context == "shelving" && CurrentRoom == Rooms[0])
                        {
                            System.Console.WriteLine(CurrentRoom.DescriptionE);
                        }
                        else if(context == "trash" || context == "bags" || context == "garbage" && CurrentRoom == Rooms[0])
                        {
                            System.Console.WriteLine(CurrentRoom.DescriptionW);
                        }
                    }
                }
                else if (command == "take")
                {
                    if (CurrentRoom == Rooms[0])
                    {
                        if (option == "pipe")
                        {
                        CurrentPlayer.Inventory.Add(pipe);
                        };
                    }
                }
            }
            else if (Input == "look")
            {
                System.Console.WriteLine(CurrentRoom.Description);
            }
            else if (Input == "inventory" || Input == "i")
            {
                if (CurrentPlayer.Inventory == null)
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