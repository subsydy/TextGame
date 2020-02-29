using System;

namespace TextGame
{
    class Game
    {
        private static CharacterInfo _character;

        static void Main(string[] args)
        {
            TitleScreen.Play();

            string input = null;
            StepInfo step = null;
            while(true) 
            {
                if(_character == null) {
                    _character = CharacterInfo.GatherCharacterInfo();
                }

                step = NextStep(step, input);

                if(!string.IsNullOrEmpty(step.Message)) 
                {
                    Console.WriteLine($"{step.Message}");
                }

                if(step.Died) 
                {
                    _character = null;
                    continue;
                }

                 Prompt(step.Prompt);
                 continue;
            }
        }

        public static string PromptUntilValidInput(string prompt, Func<string, bool> validatInput, string hint = null) {
            string input = null;
            bool validInput = false;
            while(string.IsNullOrEmpty(input) || !validInput) {
                input = Prompt(prompt);
                if(input.Trim() == "?") {
                    Console.WriteLine(string.IsNullOrEmpty(hint) 
                        ? "There are no clues here." 
                        : hint);
                }
                validInput = validatInput(input);
            }
            Console.WriteLine("\n");
            return input;
        }

        private static string Prompt(string prompt){
            Console.Write($"{prompt}\n > ");
            return Console.ReadLine();
        }

        static StepInfo NextStep(StepInfo step, string input)
        {
            if(step == null) 
            {
                return StepInfo.Continue("You're new here.", "What would you like to do?");
            }

            return StepInfo.Die(message: "Rock falls, you die.");
        }
    }

    class StepInfo {
        public string Prompt { get; }
        public bool Died { get; }
        public string Message { get; }

        private StepInfo(bool die, string prompt, string message)
        {
            Died    = die;
            Prompt  = prompt;
            Message = message;
        }

        public static StepInfo Die(string message = null, string prompt = null) {
            return new StepInfo(true, prompt, message);
        }

        public static StepInfo Continue(string message, string prompt) {
            return new StepInfo(false, prompt, message);
        }
    }


}
