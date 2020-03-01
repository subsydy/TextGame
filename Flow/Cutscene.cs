using System;

namespace TextGame.Flow
{
    public class Cutscene : ITakeAFrame
    {
        public string Message { get; private set; }
        public string Prompt => throw new System.NotImplementedException();

        public ITakeAFrame AndThen { get; private set; }

        private Cutscene() {}

        public static Cutscene Play(string message, ITakeAFrame andThen = null)
        {
            return new Cutscene {
                Message = message,
                AndThen = andThen
             };
        }

        public ITakeAFrame Next(CharacterInfo character, string input)
        {
            return AndThen;
        }
    }
}