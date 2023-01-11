//Write a function that takes an array of numbers and it should display the Odd and Even numbers
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assignment_2_EvenOrOdd
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of array");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] numbers = new int[size];
          
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter the value at index "+ i);
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("odd numbers");
            foreach(int num in numbers)
            {
                if (num % 2 != 0)
                {
                    Console.WriteLine(num);
                }
            }
            Console.WriteLine("Even Numbers");
            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                {
                    Console.WriteLine(num);
                }
            }
            Console.WriteLine("even numbers");
           
        }
    }
}
