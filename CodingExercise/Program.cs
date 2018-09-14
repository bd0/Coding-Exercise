using CodingExercise.Enums;
using CodingExercise.Services;
using System;

namespace CodingExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                Usage();
                return;
            }

            var numbers = args[0];

            // Per STEP-10: Allow specifying an operation.
            var operation = CalculatorOperation.Addition;

            if (args.Length == 2 && Enum.TryParse<CalculatorOperation>(args[1], out var enumResult))
            {
                operation = enumResult;
            }

            var calculatorService = new CalculatorService();

            var calcResult = calculatorService.Calculate(numbers, operation);

            Console.WriteLine($"Result: {calcResult}");
        }


        private static void Usage()
        {
            Console.WriteLine("CodingExercise Calculator!");
            Console.WriteLine("Returns the sum of the provided integers.");
            Console.WriteLine(@"Usage: dotnet CodingExercise.dll ""1,2,3,4"" [""Addition""|""Subtraction""|""Multiplication""|""Division""]");
        }
    }
}
