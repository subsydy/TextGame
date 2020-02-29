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

                StepInfo step = null;
                while(_character != null)
                {
                    step = Frame.Do(() => EvaluateStep(step));
                    if (step.Died) {
                        _character = null;
                    }
                }
            }
        }

        private static void WriteLine(string text, ConsoleColor color = ConsoleColor.Gray) 
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        static StepInfo EvaluateStep(StepInfo step) {
            if(step == null) {
                var nextStep = new Campaign().Play(_character);
                return HandleStep(nextStep);
            }

            if(!string.IsNullOrEmpty(step.Message)) 
            {
                Console.WriteLine($"{step.Message}");
            }

            if(step.Died) 
            {
                _character = null;
                return null;
            }

            return HandleStep(step);
        }

        public static string PromptUntilValidInput(StepInfo step) {
            
            WriteLine($"{step.Message}\n", ConsoleColor.Yellow);

            string input = null;
            bool validInput = false;
            while(string.IsNullOrEmpty(input) || !validInput) {
                input = Prompt(step.Prompt);
                if(input.Trim() == "?") {
                    PrintHelpText();
                    continue;
                }
                if(input.Trim() == "hint") {
                    WriteLine(string.IsNullOrEmpty(step.Hint) ? "There are no clues here." : step.Hint,
                        ConsoleColor.Green);
                    continue;
                }
                validInput = step.ValidateInput(input);
            }
            WriteLine("\n");
            return input;
        }

        private static void PrintHelpText()
        {
            Console.WriteLine("Help text coming soon...", ConsoleColor.Green);
        }

        public static StepInfo HandleStep(StepInfo step) {
            var response = PromptUntilValidInput(step);
            var nextStep = step.NextStep(response);
            return nextStep;
        }

        public static Tuple<StepInfo, TOutput> HandleStep<TOutput>(StepInfo step, Func<string, TOutput> transform) {
            var response = PromptUntilValidInput(step);
            var nextStep = step.NextStep(response);
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
