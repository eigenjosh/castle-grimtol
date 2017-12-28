
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
            Console.Clear();
            var playing = true;

            while (playing)
            {
                Console.WriteLine(game.CurrentRoom.Description);
                var Input = game.GetUserInput().ToLower();
                if (Input == "q" || Input == "quit")
                {
                    playing = false;
                    continue;
                }
                else
                {
                    game.HandleUserInput(Input);
                }
            }
        }
    }
}