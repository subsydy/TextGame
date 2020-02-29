using System;

namespace TextGame.Flow
{
    public class StepInfo {
        public string Prompt { get; protected set; }
        public bool Died { get; protected set; }
        public string Message { get; protected set; }
        public string Hint { get; protected set; }

        protected Func<string, StepInfo> DecisionTree { get; set; }
        public StepInfo NextStep(string input) {
            return DecisionTree?.Invoke(input) 
                ?? StepInfo.Die("Rock falls, you die.");
        }

        protected Func<string, bool> Validate { get; set;}
        public bool ValidateInput (string input) {
            return Validate?.Invoke(input) ?? true;
        }

        public static StepInfo Die(string message = null, string prompt = null) {
            return new StepInfo
            {
                Died = true, 
                Prompt = prompt,
                Message = message,
            };
        }

        public static StepInfo Continue(string prompt, string message = null, string hint = null, Func<string, bool> validate = null) {
            return new StepInfo
            {
                Died = false, 
                Prompt = prompt, 
                Message = message,
                Validate = validate,
                Hint = hint,
            };
        }
    }
}