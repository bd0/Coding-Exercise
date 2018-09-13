using CodingExercise.Services;
using System;

namespace CodingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Usage();
                return;
            }

            var numbers = args[0];

            var calculatorService = new CalculatorService();

            var sum = calculatorService.Add(numbers);

            Console.WriteLine($"Sum: {sum}");

            Console.ReadKey();
        }


        private static void Usage()
        {
            Console.WriteLine("CodingExercise Calculator!");
            Console.WriteLine("Returns the sum of the provided integers.");
            Console.WriteLine(@"Usage: CodingExercise.exe ""1,2,3,4""");
        }
    }
}
