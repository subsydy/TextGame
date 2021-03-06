﻿using System;
using TextGame.Flow;
using TextGame.ExampleCampaign;

namespace TextGame
{
    class Game
    {
        private static Character _character;

        static void Main(string[] args)
        {
            while(true) {
                Frame.Do(TitleScreen.Play);
                _character = Frame.Do(Character.GatherCharacter);

                ITakeAFrame frame = null;
                while(_character != null)
                {
                    frame = Frame.Do(() => frame.HandleFrame(_character, () => new ExampleCampaign.ExampleCampaign()));
                    if (frame == null) {
                        _character = null;
                    }
                }
            }
        }

        public static void WriteHelpText()
        {
            Console.WriteLine("Help text coming soon...", ConsoleColor.Green);
        }
        
        public static string WritePrompt(string prompt){
            WriteLine(prompt, ConsoleColor.Green);
            Console.Write(" > ");
            return Console.ReadLine();
        }

        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.Gray) 
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
