using System;

namespace ISP_Project
{
    class Program
    {
        static void Main(string[] args)
        {         
            WelcomeScreen.Welcome();
             int ch;
            
            Console.WriteLine("Please Choose your option\n1-Sign Up\n2-Login");
            cw:
            ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    SignupandLogin.SignUp();
                    Console.WriteLine("Do You want to Login (Yes/No)");
                    string op = Console.ReadLine();
                    if (op == "Yes" || op == "YES" || op == "yes")
                    {
                        SignupandLogin.Login();
                    }
                    else
                    {
                        Console.WriteLine("Thank You for Sign Up with 'AirLink'");                        
                    }
                    break;
                case 2:
                    SignupandLogin.Login();                    
                    break;
                default:
                    Console.WriteLine("Try Again");
                    goto cw;                  
            }
            Console.WriteLine("\n\nThank You for Choosing Our Service");
            Console.ReadLine();         
        }
    }
}
