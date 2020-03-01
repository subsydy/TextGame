using TextGame.Entities;
using TextGame.Flow;

namespace TextGame.Campaigns 
{
    public class Campaign : ICampaign
    {
        public ITakeAFrame Play(CharacterInfo character)
        {
            var introMessage = $@"Your head aches. Your head feels wet and sticky.
You're sitting on a hard stone floor in a small room. A door with bars at face height dominates one wall. One other person is lies in a heap in the corner.
Your name is {character.Name}... you don't remember how you got here.
";
            var prompt = "What now?";
            var firstStep = Question.Continue(message: introMessage, prompt: prompt, hint: "This looks grim.");

            character.AddDebuff("head wound");
            character.SetLocation(Area.Named("a small cell").WithItem("body"));

            return firstStep;
        }

        public Question EvaluateAction(CharacterInfo character, CharacterAction action, object subject) 
        {
            // Check if subject has handling for the action.
            var subjectType = subject.GetType(); 
            if(subjectType == typeof(Area)) 
            {
                throw new System.NotImplementedException();
            }
            if(subjectType == typeof(Item)) 
            {
                throw new System.NotImplementedException();
            }
            if(subjectType == typeof(Portal)) 
            {
                throw new System.NotImplementedException();
            }

            throw new System.NotImplementedException();
        }
    }
}