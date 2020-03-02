using System;
using TextGame.Entities;
using TextGame.Entities.Common;
using TextGame.Flow;
using TextGame.Flow.Common;

namespace TextGame.ExampleCampaign 
{
    public class ExampleCampaign : ICampaign
    {
        public ITakeAFrame Play(Character character)
        {
            var introMessage = $@"Your head aches. Your head feels wet and sticky.
You're sitting on a hard stone floor in a small room. A door with bars at face height dominates one wall. One other person is lies in a heap in the corner.
Your name is {character.Name}... you don't remember how you got here.";

            var firstStep = Cutscene.Play(message: introMessage, andThen: FirstQuestion());

            var startingLocation = Area.Named("a small cell")
                .ContainingEntities(
                    Item.Named("body").AddHandler(Command.Examine, CheckTheBody),
                    Portal.To(Area.Named("guard room"))
                ); 

            character.AddDebuff("head wound");
            character.SetLocation(startingLocation);

            return firstStep;
        }

        private ITakeAFrame CheckTheBody(ITakeAFrame frame, Character character)
        {
            var message = "The man is curled in a ball facing the corner. His shirt is torn and bloody. Shackles are affixed to his ankles. He chest rises and falls laboriously.";
            Game.WriteLine(message);
            return frame;
        }

        public ITakeAFrame FirstQuestion() 
        {
            return Question.Continue(prompt: "What now?", hint: "It doesn't look good around here.");//, decisionTree: StartHere);
        }

        // private ITakeAFrame StartHere(Character character, string input)
        // {
            
        // }
    }
}