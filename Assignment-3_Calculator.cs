//Write a Math Calc Program that allows Users to enter the values and operation and the Program should display the result
//based on the operator the user has typed. It should be in a loop until the user specifies to close it.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assignment_3_Calculator
    {
        static void Main(string[] args)
        {
            string decision = "";

            do
            {
                int result = 0;
                Console.WriteLine("enter the first value");
                int value1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the second value");
                int value2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the opeartor");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "+":
                        result = value1 + value2;
                        break;
                    case "-":
                        result = value1 - value2;
                        break;
                    case "*":
                        result = value1 * value2;
                        break;
                    case "/":
                        result = value1 + value2;
                        break;
                    default:
                        Console.WriteLine("No match found");
                        break;
                }
                Console.WriteLine("the result is: " + result);

                Console.WriteLine("do you want to exit yes/no");
                decision = Console.ReadLine();


            } while (decision != "yes");


        }
    }
}
