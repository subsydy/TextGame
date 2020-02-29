using TextGame.Entities;
using TextGame.Flow;

namespace TextGame.Campaigns 
{
    public class Campaign : ICampaign
    {
        public StepInfo Play(CharacterInfo character)
        {
            var introMessage = $@"Your head aches. Your head feels wet and sticky.
            
You're sitting on a hard stone floor in a small room. A door with bars at face height dominates one wall. One other person is lies in a heap in the corner.

Your name is {character.Name}... you don't remember how you got here.
";
            var prompt = "What now?";

            character.AddDebuff("head wound");
            character.Location = Area.Named("a small cell").WithItem("body");

            return StepInfo.Continue(message: introMessage, prompt: prompt, hint: "This looks grim.");
        }

        public StepInfo EvaluateAction(CharacterInfo character, CharacterAction action, object subject) 
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