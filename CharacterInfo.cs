using System;
using System.Collections.Generic;
using TextGame.Entities;
using TextGame.Flow;

namespace TextGame {
    public class CharacterInfo
    {
        public string Name { get; private set; }
        public List<string> Debuffs { get; } = new List<string>();
        public Area Location { get; set; }

        public static CharacterInfo GatherCharacterInfo()
        {
            Func<string, bool> emptyTest = str => !string.IsNullOrEmpty(str);
            var nameStep = StepInfo.Continue(prompt: "What is your name?", validate: emptyTest);
            (var step, var name) = Game.HandleStep(nameStep, arg => arg);
            
            return new CharacterInfo
            {
                Name = name
            };
        }

        internal void AddDebuff(string v)
        {
            Debuffs.Add("head wound");
        }
    }
}
