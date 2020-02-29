using System;
using TextGame.Flow;

namespace TextGame {
    public class CharacterInfo
    {
        public string Name { get; private set; }

        public static CharacterInfo GatherCharacterInfo()
        {
            Func<string, bool> emptyTest = str => !string.IsNullOrEmpty(str);
            var nameStep = StepInfo.Continue(message: "What about you? Who are you? Why are you here?", prompt: "What is your name?", validate: emptyTest);
            (var step, var name) = Game.HandleStep(nameStep, arg => arg);
            Console.WriteLine($"Welcome, {name}!");
            
            return new CharacterInfo
            {
                Name = name
            };
        }
    }
}
