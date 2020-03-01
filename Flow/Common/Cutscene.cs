using System;

namespace TextGame.Flow.Common
{
    public class Cutscene : ITakeAFrame
    {
        public string Message { get; private set; }

        public ITakeAFrame AndThen { get; private set; }

        private Cutscene() {}

        public static Cutscene Play(string message, ITakeAFrame andThen = null)
        {
            return new Cutscene {
                Message = message,
                AndThen = andThen
             };
        }

        public ITakeAFrame Next(Character character, string input)
        {
            return AndThen;
        }

        internal static object Play(string message, object andThen)
        {
            throw new NotImplementedException();
        }
    }
}