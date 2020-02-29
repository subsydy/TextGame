using System;

namespace TextGame 
{
    class TitleScreen
    {
        private const string Title = @"
       _              _       ___ 
 /\ /\| |_ ___  _ __ (_) __ _/ _ \
/ / \ \ __/ _ \| '_ \| |/ _` \// /
\ \_/ / || (_) | |_) | | (_| | \/ 
 \___/ \__\___/| .__/|_|\__,_| () 
               |_|               
";

        private const string Introduction = 
@"You're entering a world of fantasy. The great wizard Ankhet is building a paradise. Followers and hangers-on flock from around the world. A potent mix of psychophants, spies, and true believers.

What about you? Are you here to build or destroy?
";

        public static void Play()
        {
            Console.WriteLine(Title);
            Console.WriteLine(Introduction);
            Console.WriteLine("<< PRESS ANY KEY >>\n\n");
            Console.ReadLine();
        }
    }
}