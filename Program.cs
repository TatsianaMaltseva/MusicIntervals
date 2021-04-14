using System;

namespace MusicIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = new string[] {"A","G##" };
            Console.WriteLine(IntervalIdentification(array));

        }

        static string IntervalConstruction(string[] inputArray)
        {
            if(inputArray.Length != 2 && inputArray.Length != 3)
            {
                Console.WriteLine("Illegal number of elements in input array");
            }
            string direction = inputArray.Length == 3 ? inputArray[2] : "asc";
            Interval interval = new Interval(inputArray[0]);
            return interval.IntervalConstruction(inputArray[1], direction);
        } // эксепшены прописать

        static string IntervalIdentification(string[] inputArray)
        {
            if (inputArray.Length != 2 && inputArray.Length != 3)
            {
                Console.WriteLine("Illegal number of elements in input array");
            }
            string direction = inputArray.Length == 3 ? inputArray[2] : "asc";
            Interval interval = new Interval("m2");
            return interval.IntervalIdentification(inputArray[0], inputArray[1], direction);
        }
    }
}