using System;

namespace TextGame.Flow
{
    public interface ITakeAFrame 
    {
        string Message { get; }
        ITakeAFrame Next(Character character, string input);
    }

    public static class ITakeAFrameExtensions 
    {
        public static void WriteMessage(this ITakeAFrame step) 
        {
            if(!string.IsNullOrEmpty(step.Message)) 
            {
                Game.WriteLine(step.Message, ConsoleColor.Yellow);
            }
        }

        public static ITakeAFrame HandleFrame(this ITakeAFrame step, Character character, Func<ICampaign> bootstrap) 
        {
            if(step == null) step = bootstrap().Play(character);
            return step.HandleFrame(character);
        }

        public static ITakeAFrame HandleFrame(this ITakeAFrame step, Character character) 
        {
            step.WriteMessage();
            var takesInput = step as ITakeInput;
            if (takesInput != null) return takesInput.HandleStep(character);

            return step.Next(character, null);
        }

        public static string PromptUntilValidInput(this ITakeInput step) {
            string input = null;
            bool validInput = false;
            while(string.IsNullOrEmpty(input) || !validInput) {
                input = Game.WritePrompt(step.Prompt);
                if(input.Trim() == "?") {
                    Game.WriteHelpText();
                    continue;
                }
                if(input.Trim() == "hint?") {
                    var hasHint = step as IHaveAHint;
                    hasHint.HandleHints();
                    continue;
                }
                if(input.Trim() == "repeat?") {
                    step.WriteMessage();
                    continue;
                }
                validInput = step.IsValid(input);
            }
            return input;
        }
    }
}