/* Write a program that creates an array and displays the contents of the array. 
The array should be created dynamically. It means that the size, type should be set by the user of the Program. 
Take inputs for the values also. Finally it should display the values of the array.*/
using System;


namespace SampleConApp
{
    class Assignment_04_arrays
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the size of the array");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the CTS equivelent name for the type of array that you want to create");
            string typeName = Console.ReadLine();
            Type type = Type.GetType(typeName, true, true); //first true for throe an error if not matching second true for ignoring case
            Array myArray = Array.CreateInstance(type, size);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"enter the value of the type {type.Name}");
                string enteredValue = Console.ReadLine();
                object convertedValue = Convert.ChangeType(enteredValue, type);
                myArray.SetValue(convertedValue, i);

            }
            Console.WriteLine("all values are set");
            foreach (object item in myArray)
            {
                Console.WriteLine(item);
            }


            
        }
    }
}
