using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Setup();

            bool playing = true;
            while (playing)
            {
                System.Console.WriteLine(game.CurrentRoom.Description);
                var choice = game.GetUserInput(game.input).Split(" "); // go n
                var command = choice[0];
                var option = choice[1];
                //figure out what to do with the user input
                switch (command)
                {
                    case "go":
                        switch (option)
                        {
                            case "n":
                               game
                                break;
                        }
                        break;
                }

            }
        }
    }
}
