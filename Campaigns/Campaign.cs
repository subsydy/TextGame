using TextGame.Flow;

namespace TextGame.Campaigns 
{
    public class Campaign : ICampaign
    {
        public StepInfo GetFirstStep()
        {
            var introMessage = "The boat creaks and rattles as the captain steers into port. You've just arrived in Dom Sin Nobilis. As you stare up at the towering pyramid you realize how far you are from the familiar alleys of Soresfere.";
            return StepInfo.Continue(message: introMessage, prompt: "The ship settles and the <<gangplank>> extends.", hint: "You should probably disembark.");
        }
    }
}