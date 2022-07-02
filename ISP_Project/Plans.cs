using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP_Project
{
    class Plans
    {  
        private static List<User> li = new List<User>();
        private static AirLinkADO link = new AirLinkADO();

        public static void Plan(long mobile, string email)
        {
            int ch;
            int plan;                 

            Console.WriteLine("Choose Plan");
            Console.WriteLine("1-Prepaid\n2-PostPaid\n3-Broadband\n4-DTH");
            ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Choose Prepaid Options");
                    Console.WriteLine("1-View Plans\n2-Pay Bills\n3-Switch to Postpaid\n4-New Connection");
                    ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("1-View current Plan\n2-View All Plan");
                            ch:
                            ch = int.Parse(Console.ReadLine());                           
                            switch (ch)
                            {                                
                                //prepaid start from here
                                case 1:
                                    Console.WriteLine("Your Current Plan is...\n\n");
                                    if (mobile == 0 && email != null)
                                    {
                                        li = link.CurrentPlan(email);
                                    }
                                    else if (mobile != 0 && email == "")
                                    {
                                        li = link.CurrentPlan(mobile);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No Current Plan Exist");
                                    }
                                    li = link.CurrentPlan(mobile);
                                    Console.WriteLine("");
                                    foreach (var item in li)
                                    {
                                        if (item.DateTime >= DateTime.Now)//item.ExpiryDate is >date.now
                                        {
                                            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-20}{4}","Plan Type","Price","Validity","Expiry Date","Plan Details");
                                            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-20}{4}",item.PlanType,item.Cost,item.Validity,item.DateTime,item.Details);
                                        }
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Our Plan are....");
                                    li = link.Plans();                           
                                    var qroup = from s in li
                                                group s by s.PlanType;
                                    Console.WriteLine("{0,-15}{1,-15}{2,-30}{3}", "Plan Type", "Price", "Validity", "Details\n");
                                    foreach (var type in qroup)
                                    {
                                        Console.WriteLine(type.Key);

                                        var select = from c in type
                                                     orderby c.Cost
                                                     select c;                                                    

                                        foreach (var item in select)
                                        {
                                            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3}","",item.Cost,item.Validity,item.Details);
                                        }
                                    }
                                    Console.WriteLine("\nChoose Plan to recharge");
                                    plan:
                                    plan = int.Parse(Console.ReadLine());
                                    if (link.ValidatePlan(plan))
                                    {                                                                             
                                        var newPlan = from s in li
                                                      where s.Cost == plan
                                                      select s;
                                        foreach (var item in newPlan)
                                        {
                                            User obj = null;
                                            if (mobile == 0 && email != null)
                                            {
                                                 obj = link.GetName(email);                                                    
                                            }
                                            else if (mobile != 0 && email == "")
                                            {
                                                 obj = link.GetName(mobile);                                              
                                            }
                                            else
                                            {
                                                Console.WriteLine("Login Again");
                                                continue;
                                            }
                                            User value = new User(obj.Name, obj.Mobile, obj.Email, item.PlanType, item.Cost, item.Validity, item.Details);
                                            link.InsertCurrentPlan(value);
                                        }
                                        Console.WriteLine("\nYour Prepaid Recharge is Successful.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No Plan Available for: "+ plan +" Please Choose Right Plan:");
                                        goto plan;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid Choice Choose again...");
                                    goto ch;                                   
                            }
                            break;                            
                        case 2:
                           
                            break;                            
                        case 3:
                           
                            break;
                        case 4:
                 
                            break;
                        default:
                            Console.WriteLine("Invalid Choice Try again...");
                            break;
                    }
                    break;
                case 2:

                    //postpaid start here
                    Console.WriteLine("1-View current Plan\n2-View All Plan");
                    ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Your Current Plan is...");
                            break;
                        case 2:
                            Console.WriteLine("Our Plan are....");
                            li = link.Plans();


                            var qroup = from s in li
                                        group s by s.PlanType;
                            Console.WriteLine("{0,-15}{1,-15}{2,-30}{3}", "Plan Type", "Price", "Validity", "Details\n");
                            foreach (var type in qroup)
                            {
                                Console.WriteLine(type.Key);

                                var select = from c in type
                                             orderby c.Cost
                                             select c;

                                foreach (var item in select)
                                {
                                    Console.WriteLine("{0,-15}{1,-15}{2,-15}{3}", "", item.Cost, item.Validity, item.Details);
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Choice Try again...");
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("1-View current Plan\n2-View All Plan");
                    ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Your Current Plan is...");
                            break;
                        case 2:
                            Console.WriteLine("Our Plan are....");
                            li = link.Plans();

                            var qroup = from s in li
                                        group s by s.PlanType;
                            Console.WriteLine("{0,-15}{1,-15}{2,-30}{3}", "Plan Type", "Price", "Validity", "Details\n");
                            foreach (var type in qroup)
                            {
                                Console.WriteLine(type.Key);

                                var select = from c in type
                                             orderby c.Cost
                                             select c;

                                foreach (var item in select)
                                {
                                    Console.WriteLine("{0,-15}{1,-15}{2,-15}{3}", "", item.Cost, item.Validity, item.Details);
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Choice Try again...");
                            break;
                    }
                    break;
                case 4:
                    Console.WriteLine("1-View current Plan\n2-View All Plan");
                    ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Your Current Plan is...");
                            break;
                        case 2:
                            Console.WriteLine("Our Plan are....");
                            li = link.Plans();


                            var qroup = from s in li
                                        group s by s.PlanType;
                            Console.WriteLine("{0,-15}{1,-15}{2,-30}{3}", "Plan Type", "Price", "Validity", "Details\n");
                            foreach (var type in qroup)
                            {
                                Console.WriteLine(type.Key);

                                var select = from c in type
                                             orderby c.Cost
                                             select c;

                                foreach (var item in select)
                                {
                                    Console.WriteLine("{0,-15}{1,-15}{2,-15}{3}", "", item.Cost, item.Validity, item.Details);
                                }
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Choice Try again...");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Try Again");
                    break;
            }
        }
    }
}
