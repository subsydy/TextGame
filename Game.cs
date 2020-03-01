using System;
using TextGame.Flow;
using TextGame.Campaigns;

namespace TextGame
{
    class Game
    {
        private static CharacterInfo _character;

        static void Main(string[] args)
        {
            while(true) {
                Frame.Do(TitleScreen.Play);
                _character = Frame.Do(CharacterInfo.GatherCharacterInfo);

                ITakeAFrame frame = null;
                while(_character != null)
                {
                    frame = Frame.Do(() => EvaluateFrame(frame));
                    if (frame == null) {
                        _character = null;
                    }
                }
            }
        }

        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.Gray) 
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static ITakeAFrame EvaluateFrame(ITakeAFrame step) {
            if(step == null) {
                var nextStep = new Campaign().Play(_character);
                return HandleStep(nextStep);
            }

            return HandleStep(step);
        }

        public static string PromptUntilValidInput(ITakeInput step) {
            string input = null;
            bool validInput = false;
            while(string.IsNullOrEmpty(input) || !validInput) {
                input = Prompt(step.Prompt);
                if(input.Trim() == "?") {
                    PrintHelpText();
                    continue;
                }
                if(input.Trim() == "hint?") {
                    var hasHint = step as IHaveAHint;
                    HandleHints(hasHint);
                    continue;
                }
                validInput = step.IsValid(input);
            }
            WriteLine("\n");
            return input;
        }

        public static void HandleHints(IHaveAHint hasHint) 
        {
            if(hasHint == null) return;
            WriteLine(hasHint?.Hint == null ? "There are no clues here." : hasHint.Hint,
                ConsoleColor.Green);
        }

        private static void PrintHelpText()
        {
            Console.WriteLine("Help text coming soon...", ConsoleColor.Green);
        }

        public static ITakeAFrame HandleStep(ITakeAFrame step) {
            WriteLine(step.Message, ConsoleColor.Yellow);

            var takesInput = step as ITakeInput;
            if (takesInput != null) return HandleStep(takesInput);

            return step.Next(_character, null);
        }

        public static ITakeAFrame HandleStep(ITakeInput step) {
            var response = PromptUntilValidInput(step);
            var nextStep = step.Next(_character, response);
            return nextStep;
        }

        public static Tuple<ITakeAFrame, TOutput> HandleStep<TOutput>(ITakeInput step, Func<string, TOutput> transform) {
            var response = PromptUntilValidInput(step);
            var nextStep = step.Next(_character, response);
            var output   = transform(response);
            return Tuple.Create(nextStep, output);
        }

        private static string Prompt(string prompt){
            WriteLine(prompt, ConsoleColor.Green);
            Console.Write(" > ");
            return Console.ReadLine();
        }
    }

    public enum CharacterAction 
    {
        Examine,
        Search,
        Grab,
        Go
    }
}
