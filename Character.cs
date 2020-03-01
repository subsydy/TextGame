using System;
using System.Collections.Generic;
using TextGame.Entities;
using TextGame.Entities.Common;
using TextGame.Flow;

namespace TextGame {
    public class Character
    {
        public string Name { get; private set; }
        public List<string> Debuffs { get; } = new List<string>();
        public Area Location { get; private set; }

        public static Character GatherCharacter()
        {
            Func<string, bool> emptyTest = str => !string.IsNullOrEmpty(str);
            var nameStep = Question.Continue(prompt: "What is your name?", validate: emptyTest);
            (var step, var name) = nameStep.HandleStep(arg => arg);
            
            return new Character { Name = name };
        }

        internal void SetLocation(Area location) 
        {
            Game.WriteLine($"You are now in a new location: {location.Name}.", ConsoleColor.DarkGreen);
            Location = location;
        }

        internal void AddDebuff(string v)
        {
            Game.WriteLine($"You have a new debuff: {v}.", ConsoleColor.Red);
            Debuffs.Add(v);
        }
    }
}
