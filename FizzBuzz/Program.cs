using System;

namespace FizzBuzz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the range (format: (start)_(end) )");
                string input = Console.ReadLine();

                var range = TwistedFizzBuzz.TwistedFizzBuzz.ReadInput(input);

                string result = TwistedFizzBuzz.TwistedFizzBuzz.ResolveStandardFizzBuzzProblem(range[0], range[1]);
                Console.WriteLine(result);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
            
        }
    }
}
