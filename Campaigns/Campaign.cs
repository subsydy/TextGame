using TextGame.Entities;
using TextGame.Entities.Common;
using TextGame.Flow;
using TextGame.Flow.Common;

namespace TextGame.Campaigns 
{
    public class Campaign : ICampaign
    {
        public ITakeAFrame Play(Character character)
        {
            var introMessage = $@"Your head aches. Your head feels wet and sticky.
You're sitting on a hard stone floor in a small room. A door with bars at face height dominates one wall. One other person is lies in a heap in the corner.
Your name is {character.Name}... you don't remember how you got here.";

            var firstStep = Cutscene.Play(message: introMessage, andThen: FirstQuestion());

            var startingLocation = Area.Named("a small cell")
                .ContainingEntities(
                    Item.Named("body"),
                    Portal.To(Area.Named("guard room"))
                ); 

            character.AddDebuff("head wound");
            character.SetLocation(startingLocation);

            return firstStep;
        }

        public ITakeAFrame FirstQuestion() 
        {
            return Question.Continue(prompt: "What now?", hint: "It doesn't look good around here.");
        }

        public Question EvaluateAction(Character character, CharacterAction action, object subject) 
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