using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    abstract class Account1
    {
        public int AccNo { get; set; }
        public string Name { get; set; }
        public int Balance { get; private set; } = 5000;
        public void Credit(int amount)
        {
            Balance += amount;
        }
        public void Debit(int amount)
        {
            if (amount > Balance)
            {
                throw new Exception("Insufficient funds");
            }
            else
                Balance -= amount;
        }

        public abstract void CalculateInterest();
    }

    class SDAccount : Account
    {
        public override void CalculateInterest()
        {
            var principle = Balance;
            var time = 0.25;
            var rate = 0.5;
            var interest = principle * time * rate;
            Credit((int)interest);
        }
    }

    class RDAccount : Account
    {
        public override void CalculateInterest()
        {
            var principle = Balance;
            var time = 0.25;
            var rate = 0.5;
            var interest = principle * time * rate;
            Credit((int)interest);
        }
    }

    class FDAccount : Account
    {
        public override void CalculateInterest()
        {
            var principle = Balance;
            var time = 0.25;
            var rate = 0.5;
            var interest = principle * time * rate;
            Credit((int)interest);
        }
    }

    class AccountFactary
    {
        public static Account2 CreateAccount(string arg)
        {
            if (arg.ToUpper() == "SD")
                return new SDAccount2();
            else if (arg.ToUpper() == "FD")
                return new FDAccount2();
            else if (arg.ToUpper() == "RB")
                return new RDAccount2();
            else
                throw new Exception("This type of Business is not availabe with Us!!!");

        }
    }

    class UI
    {
        enum Options { SD = 1, FD, RD }
        public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~BANK ACCOUNT SOFTWARE~~~~~~~~~~~~~~~~~~~\nTO CREATE SD ACCOUNT------------------------>PRESS SD\nTO CREATE FD ACCOUNT---------------->PRESS FD\nTO CREATE RD ACCOUNT----------------->PRESS RD\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";

        public static string Display()
        {
            return Utilities.Prompt(menu);
            //return Utilities.Prompt("ENTER THE TYPEOF ACCOUNT YOU WANT TO CREATE");

        }
        
        static bool Menu(Options option)
        {
            switch (option)
            {
                case Options.SD:
                     break;
                case Options.FD:
                    
            break;
                case Options.RD:

                    break;
            default:
                    return false;
        }
            return true;
        }

   
          
    }
            
  
     
    class Assignmant_13
    {
        static void Main(string[] args)
        {
           string arg= UI.Display();

            //string arg = Utilities.Prompt("ENTER THE TYPEOF ACCOUNT YOU WANT TO CREATE");
           Account2 component = AccountFactary.CreateAccount(arg);
            component.AccNo = 123;
            component.Name = "Anitha";
            
            component.Credit(200);
            component.CalculateInterest();
            Console.WriteLine("the Balance Amount is: "+component.Balance);
        }
    }
}
