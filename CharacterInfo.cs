using System;
using System.Collections.Generic;
using System.Linq;

namespace TextGame {
    public class CharacterInfo
    {
        public string Name { get; }
        public Goal Goal {get;}

        public CharacterInfo(string name, Goal goal)
        {
            this.Name = name;
            this.Goal = goal;
        }

        public static CharacterInfo GatherCharacterInfo()
        {
            Func<string, bool> emptyTest = str => !string.IsNullOrEmpty(str);
            var name = Game.PromptUntilValidInput("What is your name?", emptyTest);
            Console.WriteLine($"Welcome, {name}!");

            var role = Game.PromptUntilValidInput("What is your goal?", arg => goalInputMap.ContainsKey(arg), GetGoalHint());
            Console.WriteLine($"You wouldn't be the first. I hope you're good at it.");
            
            Console.WriteLine("-------------------------------------------------------\n");
            return new CharacterInfo(name, goalInputMap[role]);
        }

        private static string GetGoalHint()
        {
            return string.Join("\n", goalInputMap.Select(g => $"* {g.Key}"));
        }

        public static Dictionary<string, Goal> goalInputMap = new Dictionary<string, Goal>  { 
            {"create",  Goal.Create},
            {"destroy", Goal.Destroy}
        };
    }

    public enum Goal
    {
        Create,
        Destroy
    }
}
