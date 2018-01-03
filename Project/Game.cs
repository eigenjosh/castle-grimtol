using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public bool Playing;
        public string Response;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public List<Room> Rooms { get; set; }
        public Player Player1 { get; set; }

        public void BuildRooms()
        {
            Rooms = new List<Room>();

            Room Room0 = new Room("Storage Room 0", description: "--A single skylight, cracked and yellowing from age, provides barely enough light to see that you are in some sort of dilapidated storage room.\nTwo rows of metal shelves stand near the wall to your right (east). A heap of black garbage bags lay against the opposing wall.")
            {
                DescriptionE = @"--After allowing your eyes to adjust to the low light, you think you can make out what looks like a metal pipe, roughly forearm-length and capped at one end.",
                DescriptionW = @"--Using your hands to feel around the trash bags, you hear something small and metal fall onto the concrete floor.",
                DescriptionN = "--A door leading out of the storage room",
                DescriptionS = "--A simple white brick wall. Squinting your eyes, you can see an externally mounted electrical outlet near the bottom of the wall.",
                Items = new List<Item>(),

                Exits = new Dictionary<string, Room>()
            };
            Room Room1 = new Room(name: "Corridor 1", description: "--You find yourself in a corridor, leading East and nowhere else.")
            {
                DescriptionN = "This is the north wall of Corridor 1",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room Room2 = new Room(name: "Empty Room 2", description: "--This room hasn't been built yet.")
            {
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            Room Room3 = new Room(name: "Empty Room 3", description: "--This room hasn't been built yet.")
            {
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()
            };
            AddRooms();
            AddExits();
            BuildItems();
            void AddRooms()
            {
                Rooms.Add(Room0);
                Rooms.Add(Room1);
                Rooms.Add(Room2);
                Rooms.Add(Room3);
            }
            void AddExits()
            {
                Room0.Exits.Add("north", Room1);
                Room1.Exits.Add("south", Room0);
                Room1.Exits.Add("east", Room2);
                Room2.Exits.Add("west", Room1);
                Room2.Exits.Add("north", Room3);
                Room3.Exits.Add("south", Room2);
            }
            CurrentRoom = Room0;
            void BuildItems()
            {
                Item pipe = new Item("pipe", "--A metal pipe, about forearm-length and capped on one end.");
                Item bentKey = new Item("bent key", "--A small brass key that is bent just slightly.");
                Room0.Items.Add(pipe);
                Room0.Items.Add(bentKey);
            }
        }
        public void TakeItem(string itemName)
        {
            Item item = CurrentRoom.Items.Find(Item => Item.Name.ToLower() == itemName);
            if (item != null)
            {
                CurrentRoom.Items.Remove(item);
                CurrentPlayer.Inventory.Add(item);
                Console.ForegroundColor = ConsoleColor.Yellow;
                CurrentPlayer.ShowInventory(CurrentPlayer);
                Console.ResetColor();
            }
            else
            {
                System.Console.WriteLine($"--Cannot take {itemName}.");
            }
        }
        public void UseItem(string itemName)
        {
            Item item = CurrentPlayer.Inventory.Find(Item => Item.Name.ToLower() == itemName);
            if(item != null && item.Name == "pipe")
            {
                if(CurrentRoom == Rooms[0])
                {
                    
                }
            }
        }
        public void Reset()
        {

            Item pipe = new Item("pipe", "--A metal pipe, about forearm-length and capped on one end.");
            Item bentKey = new Item("bent key", "--A small brass key that is bent just slightly.");
            Room0.Items.Add(pipe);
            Room0.Exits.Add("north", Room1);
            // Room0.Contextual.Add("get up", Room0);

            Room1.Exits.Add("south", Room0);
            Room1.Exits.Add("east", Room2);
            Room2.Exits.Add("west", Room1);
            Room2.Exits.Add("north", Room3);
            Room3.Exits.Add("south", Room2);

            CurrentRoom = Room0;
            CurrentPlayer = Player1;
        }

        public void Move(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
                System.Console.WriteLine(CurrentRoom.Description);
            }
            else
            {
                Console.WriteLine("--You cannot move in that direction.");
            }
        }
        public string GetUserInput()
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.WriteLine(@"
            What would you like to do?");
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
                var preposition = choice[1];
                if (command == "go")
                {
                    if (preposition == "n" || preposition == "north")
                    {
                        Move("north");
                        return;
                    }
                    if (preposition == "s" || preposition == "south")
                    {
                        Move("south");
                        return;
                    }
                    if (preposition == "e" || preposition == "east")
                    {
                        Move("east");
                        return;
                    }
                    if (preposition == "w" || preposition == "west")
                    {
                        Move("west");
                        return;
                    }
                    else
                    {
                        System.Console.WriteLine("--Unrecognized direction.");
                    }
                }
                else if (command == "look" || command == "l")
                {
                    if (preposition == "n" || preposition == "north")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionN);
                        return;
                    }
                    if (preposition == "s" || preposition == "south")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionS);
                        return;
                    }
                    if (preposition == "e" || preposition == "east")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionE);
                        return;
                    }
                    if (preposition == "w" || preposition == "west")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionW);
                        return;
                    }
                    if (preposition == "at ")
                    {
                        var context = choice[2];
                        if (context == "shelves" || context == "shelving" && CurrentRoom == Rooms[0])
                        {
                            System.Console.WriteLine(CurrentRoom.DescriptionE);
                            return;
                        }
                        else if (context == "trash" || context == "bags" || context == "garbage" && CurrentRoom == Rooms[0])
                        {
                            System.Console.WriteLine(CurrentRoom.DescriptionW);
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Unrecognized direction.");
                    }
                }
                else if (command == "take")
                {
                    // Predicate<Item> ItemFinder = (Item i) => { return i.Name == preposition; };
                    foreach (Item item in CurrentRoom.Items)
                    {
                        if(item.Name == preposition)
                        {
                            CurrentPlayer.Inventory.Add(item);
                            CurrentPlayer.ShowInventory();
                        }
                        else
                        {
                            System.Console.WriteLine("You can't do that here.");
                            return;
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Unknown command. Type \"h\" for a list of commands.");
                    return;
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
                    return;
                }
                else
                {
                    System.Console.WriteLine(CurrentPlayer.Inventory);
                    return;
                }
            }
            else if (Input == "help" || Input == "h")
            {
                System.Console.WriteLine(@"
               < Commands:
                  |>  take: 'take {Item}' adds item to player inventory.
                  |>  go: 'go <direction>'
                  |>  look/l: 'look' returns current room description.
                      |>  prepositions: 'look at', 'look <direction>', NOTE TO SELF ADD MORE PREPOSITIONS
                  |>  inventory/i: returns CurrentPlayer.Inventory
                  |>  help/h: displays this message.
                ");
                return;
            }
            else
            {
                System.Console.WriteLine("Unrecognized input.");
                return;
            }
        }
    }
}