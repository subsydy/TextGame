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
@"You're entering a world of fantasy. The great wizard Ankhet is building a paradise. Followers and hangers-on flock from around the world. Psychophants, spies, and true believers flood the growing city.";

        public static void Play()
        {
            Console.WriteLine(Title);
            Console.WriteLine(Introduction);
            Console.WriteLine("<< PRESS ANY KEY >>");
            Console.ReadLine();
        }
    }
}