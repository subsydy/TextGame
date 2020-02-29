using System;
using TextGame.Flow;

namespace TextGame
{
    class Game
    {
        private static CharacterInfo _character;

        static void Main(string[] args)
        {
            Frame.Do(TitleScreen.Play);

            StepInfo step = null;
            while(true) 
            {
                if(_character == null) {
                    _character = Frame.Do(CharacterInfo.GatherCharacterInfo);
                }

                step = Frame.Do(() => EvaluateStep(step));
            }
        }

        static StepInfo EvaluateStep(StepInfo step) {
            if(step == null) {
                var nextStep = StepInfo.Continue(prompt: "You're new here.", message: "What would you like to do?");
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
            Console.WriteLine($"{step.Message}\n");

            string input = null;
            bool validInput = false;
            while(string.IsNullOrEmpty(input) || !validInput) {
                input = Prompt(step.Prompt);
                if(input.Trim() == "?") {
                    Console.WriteLine(string.IsNullOrEmpty(step.Hint) 
                        ? "There are no clues here." 
                        : step.Hint);
                }
                if(input.Trim() == "repeat") {
                    Console.WriteLine(string.IsNullOrEmpty(step.Hint) 
                        ? "There are no clues here." 
                        : step.Hint);
                }
                validInput = step.ValidateInput(input);
            }
            Console.WriteLine("\n");
            return input;
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
            Console.Write($"{prompt}\n > ");
            return Console.ReadLine();
        }
    }
}
