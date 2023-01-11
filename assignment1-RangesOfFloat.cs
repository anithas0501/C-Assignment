//Write a program that displays the range of all the floating and integral types of.NET CTS
using System;
namespace SampleConApp
{
    class assignment1_RabgesOfFloat
    {

        static void Main(string[] args)
        {
            Console.WriteLine($"the range of float is {float.MinValue} and {float.MaxValue}");
            Console.WriteLine($"the range of double is{double.MinValue} and {double.MaxValue}");
           

            Console.WriteLine($"the range of byte is{byte.MinValue} and {byte.MaxValue}");
            Console.WriteLine($"the range of short is{short.MinValue} and {short.MaxValue}");
            Console.WriteLine($"the range of int is{int.MinValue} and {int.MaxValue}");
            Console.WriteLine($"the range of long is{long.MinValue} and {long.MaxValue}");

            }
    

        }
    }
