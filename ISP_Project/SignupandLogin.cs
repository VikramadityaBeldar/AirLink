using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_Project
{
    class SignupandLogin
    { 
        //Method Used for Signup Purposes
        public static void SignUp()
        {
            long mobile;
            DateTime date;//DOB
            string name,fatherName,address;
            string email,password,confirm, governID;            
            
            AirLinkADO link = new AirLinkADO();

            Console.WriteLine("Enter Following Details to Sign Up\n");
            Console.WriteLine("Name");
            name = Console.ReadLine();
            Console.WriteLine("Father Name");
            fatherName = Console.ReadLine();
            mobile:
            Console.WriteLine("Mobile Number");
            mobile = Int64.Parse(Console.ReadLine());
            if (link.ValidateMobile(mobile))
            {
                Console.WriteLine("Mobile no exist please Login or Change Mobile Number....\n");
                back:
                Console.WriteLine("1-Login\n2-Change Mobile Number\n3-Exit");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        goto mobile;
                    case 3:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                            goto back; 
                }
            }
            else
            {
                Console.WriteLine("Date of Birth");
                date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                email:
                Console.WriteLine("Email ID");
                email = Console.ReadLine();
                if (link.ValidateEmail(email))
                {
                    Console.WriteLine("Email exist please Login or Change Email....\n");
                back:
                    Console.WriteLine("1-Login\n2-Change Email\n3-Exit");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Login();
                            break;
                        case 2:
                            goto email;
                        case 3:
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            goto back;
                    }
                }
                else
                {
                    Console.WriteLine("Government ID");
                    governID = Console.ReadLine();
                    if (link.CheckUser(governID))
                    {
                    pass:
                        Console.WriteLine("Password");
                        password = Console.ReadLine();
                        Console.WriteLine("Cofirm Password");
                        confirm = Console.ReadLine();
                        if (password != confirm)
                        {
                            Console.WriteLine("Password not matched");
                            goto pass;
                        }
                        else
                        {
                            Console.WriteLine("Address");
                            address = Console.ReadLine();
                            User obj = new User(name, fatherName, mobile, email, password, confirm, date, address);
                            if (link.SignUP(obj))
                            {
                                Console.WriteLine("Account Created Successfully");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Government Id");
                    }
                }               
            }           
        }

        //Method used for Login Purposes
        public static void Login()
        {
            int ch;
            string email="", password;
            long mobile=0;
            
            AirLinkADO link = new AirLinkADO();            

            Console.WriteLine("Choose Method For Login");
            Console.WriteLine("1-Mobile Number\n2-Email ID");
        log:
            ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Mobile Number: ");
                mobile:
                    mobile = long.Parse(Console.ReadLine());
                    if (link.ValidateMobile(mobile))
                    {
                        Console.WriteLine("Password: ");
                    Password:
                        password = Console.ReadLine();
                        if (link.ValidatePass(mobile, password))
                        {
                            Console.WriteLine("You have successfully logged in.");
                            Plans.Plan(mobile,email);
                        }
                        else
                        {
                            Console.WriteLine("Pass didn't matched");
                            goto Password;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Number didn't matched");
                        goto mobile;
                    }                   
                    break;
                case 2:
                    Console.WriteLine("Email: ");
                email:
                    email = Console.ReadLine();
                    if (link.ValidateEmail(email))
                    {
                        Console.WriteLine("Password: ");
                    pass:
                        password = Console.ReadLine();
                        if (link.ValidatePassword(password, email))
                        {
                            Console.WriteLine("You have successfully logged in.");
                            Plans.Plan(mobile,email);
                        }
                        else
                        {
                            Console.WriteLine("Password not match");
                            goto pass;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Email doesn't Match with Database");
                        goto email;
                    }                    
                    break;
                default:
                    Console.WriteLine("Wrong Entry");
                    goto log;                    
            }            
        }        
    }
}
