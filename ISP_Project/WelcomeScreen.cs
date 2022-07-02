using System;

namespace ISP_Project
{
    class WelcomeScreen
    {
        public static void Welcome()
        {            
            Console.Title = "AirLink Service";
            Console.BackgroundColor = ConsoleColor.DarkGreen;           
            Console.Clear();
            Console.Beep(500,800);            
            Console.WriteLine("\t\t\t\t\t\t\t| AirLink |\n\n");    
        }        
    }
}
