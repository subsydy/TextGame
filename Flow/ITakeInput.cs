using System;

namespace TextGame.Flow
{
    public interface ITakeInput : ITakeAFrame
    {
        string Prompt { get; }
        bool IsValid(string input);
    }

    public static class ITakeInputExtensions
    {
        public static ITakeAFrame HandleStep(this ITakeInput step, CharacterInfo character) {
            var response = step.PromptUntilValidInput();
            var nextStep = step.Next(character, response);
            return nextStep;
        }

        public static Tuple<ITakeAFrame, TOutput> HandleStep<TOutput>(this ITakeInput step, Func<string, TOutput> transformInput, CharacterInfo character = null) {
            var response = step.PromptUntilValidInput();
            var nextStep = step.Next(character, response);
            var output   = transformInput(response);
            return Tuple.Create(nextStep, output);
        }
    }
}