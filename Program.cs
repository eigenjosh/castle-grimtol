﻿using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Setup();
            game.BuildRooms();
            Console.Clear();
            var playing = true;

            while (playing)
            {
                var Input = game.GetUserInput().ToLower();
                System.Console.BackgroundColor = ConsoleColor.DarkGray;
                if (Input == "q" || Input == "quit")
                {
                    playing = false;
                    continue;
                }
                else
                {
                    game.HandleUserInput(Input);
                    continue;
                }
            }
        }
    }
}