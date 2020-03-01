namespace TextGame.Flow
{
    public interface ITakeAFrame 
    {
        string Message { get; }
        ITakeAFrame Next(CharacterInfo character, string input);
    }

    public interface IHaveAHint : ITakeAFrame
    {
        string Hint { get; }
    }

    public interface ITakeInput : ITakeAFrame
    {
        string Prompt { get; }
        bool IsValid(string input);
    }
}