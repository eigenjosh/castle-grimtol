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

            Room Room0 = new Room("Storage Room 0", description: "A single skylight, cracked and yellowing from age, provides barely enough light to see that you are in some sort of dilapidated storage room.\nTwo rows of metal shelves stand near the wall to your right (east). A heap of black garbage bags lay against the opposing wall.")
            {
                //Rooms[0]
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
            Room Room1 = new Room("Corridor 0", "You find yourself in a corridor, leading East and nowhere else.")
            {
                //Rooms[1]
                Description = "You find yourself in a corridor, leading East and nowhere else.",
                DescriptionN = "This is the north wall of Corridor 0",
                Name = "Room 2",
                Items = new List<Item>(),
                Exits = new Dictionary<string, Room>()

            };

            Item pipe = new Item("pipe", "A metal pipe, about forearm-length and capped on one end.");
            Room0.Items.Add(pipe);
            Room0.Exits.Add("north", Room1);
            Room0.Contextual.Add("get up", Room0);
            Room1.Exits.Add("south", Room0);
            CurrentRoom = Room0;
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
                var preposition = choice[1];
                if (command == "go")
                {
                    if (preposition == "n" || preposition == "north")
                    {
                        Move("north");
                    }
                    if (preposition == "s" || preposition == "south")
                    {
                        Move("south");
                    }
                    if (preposition == "e" || preposition == "east")
                    {
                        Move("east");
                    }
                    if (preposition == "w" || preposition == "west")
                    {
                        Move("west");
                    }
                }
                else if (command == "look" || command == "l")
                {
                    if (preposition == "n" || preposition == "north")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionN);
                    }
                    if (preposition == "s" || preposition == "south")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionS);
                    }
                    if (preposition == "e" || preposition == "east")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionE);
                    }
                    if (preposition == "w" || preposition == "west")
                    {
                        System.Console.WriteLine(CurrentRoom.DescriptionW);
                    }
                    if (preposition == "at ")
                    {
                        var context = choice[2];                
                        if (context == "shelves" || context == "shelving" && CurrentRoom == Rooms[0])
                        {
                            System.Console.WriteLine(CurrentRoom.DescriptionE);
                        }
                        else if(context == "trash" || context == "bags" || context == "garbage" && CurrentRoom == Rooms[0])
                        {
                            System.Console.WriteLine(CurrentRoom.DescriptionW);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("That's not a direction I recognize.");
                    }
                }
                else if (command == "take")
                {
                    if (CurrentRoom == Rooms[0])
                    {
                        if (preposition == "pipe")
                        {
                            CurrentPlayer.Inventory.Add((new Item("pipe", "A metal pipe, about forearm-length and capped on one end.")));
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("You can't do that here.");
                    }
                }
                else
                {
                    System.Console.WriteLine("Unknown command. Type \"h\" for a list of commands.");
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
            else if (Input =="help" || Input == "h")
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
            }
            else
            {
                System.Console.WriteLine("Unrecognized input.");
            }
        }
    }
}





















// # Console Game Checkpoint

// ### The Setup

// As you begin working on a console game the basic requirements of any good console game will allow users to:
//   - Move about a set of rooms
//   - Get a description of the room they are in
//   - Get Help - Shows a list of all available commands
//   - Use Items
//   - Give Up 
//   - Restart
  
// To help you out with some of these basic features will notice that you already have some interfaces that have been built. These interfaces are designed to help ensure you implement the basic requirements of a console game. 

// ### Step 1 -  Satisfy the Interfaces 

// To satisfy the interfaces you will need to ensure that your classes implement all of the features of the provided interfaces... You cannot remove anything from any of the interfaces. 
//   The Basic Features of the game:
//   - `Go <Direction>` Moves the player from room to room
//   - `Use <ItemName>` Uses an item in a room or from your inventory
//   - `Take <ItemName>` Places an item into the player inventory and removes it from the room
//   - `Help` Shows a list of commands and actions
//   - `Quit` Quits the Game

// ### Step 2 - Control the Game Loop

// We have provided a basic story and map if you are not creative or simply don't want to spend your time thinking of a story to play your game. Following the provided story is not required however creating some sort of experience is. 

// Your Game must implement the following features
//   - At least 4 rooms
//   - At least 1 usable item
//   - At least 1 item that can be taken (can be the same as the usable item)
//   - At least 1 room that changes based on an item use
//   - When the player enters a room they get the room description
//   - Players can see the items in their inventory
//   - Players lose the game due to a bad decision
//   - Players can win the game
  
  
//  ## Functionality: 
//  - Players can move room to room with the `go <direction>` command
//  - Players can `use` items to change the state of the room (use key or use light)
//  - Items exist for the player to `take` from rooms (not required for these to be used in a room)
//  - `quit` ends the game
//  - At least 4 rooms, 1 usable item, and 1 takeable item
//  - Players can lose the game due to a bad decision
//  - The game is winnable 

// ## Visualization: 
//  - `help` Provides the user a list of commands for your game
//  - `look` Re-prints the room description
//  - `inventory` prints a list of the items in the players inventory
//  -  When the player enters a room they get the room description
  
// ### BONUS IDEAS - Some enhancing features
// - Try changing the console color or adding some beeps for dramatic effect
// - Clear the console when appropriate
// - The user should know when its their turn try formatting the users input with something like this everytime its the users turn to type
//   - What do you do: __________________ // <- Their Answer on the same line
// - Add some riddles or puzzles for users to solve to get from room to room

// ### Finished?
// When You are finished please slack the url for your github repo to your mentor in a DM. Be sure you add this project to your gh-pages if you want credit for it.
