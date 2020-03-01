using System;
using System.Collections.Generic;
using TextGame.Entities;
using TextGame.Flow;

namespace TextGame {
    public class CharacterInfo
    {
        public string Name { get; private set; }
        public List<string> Debuffs { get; } = new List<string>();
        public Area Location { get; private set; }

        public static CharacterInfo GatherCharacterInfo()
        {
            Func<string, bool> emptyTest = str => !string.IsNullOrEmpty(str);
            var nameStep = Question.Continue(prompt: "What is your name?", validate: emptyTest);
            (var step, var name) = Game.HandleStep(nameStep, arg => arg);
            
            return new CharacterInfo
            {
                Name = name
            };
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
