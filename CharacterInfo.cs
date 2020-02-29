using System;

namespace TextGame {
    public class CharacterInfo
    {
        public string Name { get; private set; }

        public static CharacterInfo GatherCharacterInfo()
        {
            Func<string, bool> emptyTest = str => !string.IsNullOrEmpty(str);
            (var step, var name) = Game.HandleStep(StepInfo.Continue(prompt: "What is your name?", validate: emptyTest), arg => arg);
            Console.WriteLine($"Welcome, {name}!");
            
            return new CharacterInfo
            {
                Name = name
            };
        }
    }
}
