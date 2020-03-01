using System;

namespace TextGame.Flow
{
    public interface IHaveAHint : ITakeAFrame
    {
        string Hint { get; }
    }

    public static class IHaveAHintExtensions 
    {
        public static void HandleHints(this IHaveAHint hasHint) 
        {
            Game.WriteLine(hasHint?.Hint == null ? "There are no clues here." : hasHint.Hint,
                ConsoleColor.Green);
        }
    }
}