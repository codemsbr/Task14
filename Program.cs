using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Task14.Exceptions;

namespace Task14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                myList<int> myArray = new myList<int>();
                myArray.Add(1);
                myArray.Add(2);
                myArray.Add(3);
                myArray.Add(4);
                myArray.Add(5);
                myArray.Reverse();
                Console.WriteLine(myArray.Capacity);
            }
            catch (InvalidValueException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}