using System;

namespace TextGame.Flow
{
    public class Question : ITakeInput, ITakeAFrame 
    {
        public string Prompt { get; protected set; }
        public string Message { get; protected set; }
        public string Hint { get; protected set; }

        protected Func<string, Question> DecisionTree { get; set; }

        public ITakeAFrame Next(CharacterInfo characterInfo, string input) {
            if(DecisionTree != null) return DecisionTree.Invoke(input);
            return Cutscene.Play("Rock falls, you die.");
        }

        protected Func<string, bool> Validate { get; set;}
        public bool IsValid (string input) {
            return Validate?.Invoke(input) ?? true;
        }

        public static Question Die(string message = null, string prompt = null) {
            return new Question
            {
                Prompt = prompt,
                Message = message,
            };
        }

        public static Question Continue(string prompt, string message = null, string hint = null, Func<string, bool> validate = null) {
            return new Question
            { 
                Prompt = prompt, 
                Message = message,
                Validate = validate,
                Hint = hint,
            };
        }
    }
}