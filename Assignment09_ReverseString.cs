using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assignment09_ReverseString
    {
        public static void reverseByWords(string str)
        {

            string[] words = str.Split(' ');
            for (int i = 0; i < words.Length / 2; i++)
            {
                string ls = words[words.Length - 1 - i];
                String fs = words[i];
                words[words.Length - 1 - i] = fs;
                words[i] = ls;
            }

            foreach (var item in words)
            {
                Console.Write(item + " ");
            }
        }
        public static void Main()
        {

            Console.Write("Enter String to reverse ");
            string str = Console.ReadLine();
            reverseByWords(str);

        }
    }
}
