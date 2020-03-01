using System;

namespace TextGame.Flow 
{
    public class Frame{

        public static void Do(Action action) { 
            BeginFrame();
            action();
            EndFrame();
        }

         public static T Do<T>(Func<T> action) { 
            BeginFrame();
            var result = action();
            EndFrame();
            return result;
        }

        static void BeginFrame() 
        {
            Console.WriteLine("-------------------------------------------------");
        }

        static void EndFrame() 
        {
            Console.WriteLine("-------------------------------------------------\n\n");
        }
    }
}