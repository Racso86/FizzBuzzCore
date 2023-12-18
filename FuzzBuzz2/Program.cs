using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace FuzzBuzz2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //	- Output values from -20 to 127
                Console.WriteLine("Enter the range (format: (start)_(end) )");
                string input = "(-20)_(127)";
                var range = TwistedFizzBuzz.TwistedFizzBuzz.ReadInput(input);
                string result = TwistedFizzBuzz.TwistedFizzBuzz.ResolveStandardFizzBuzzProblem(range[0], range[1]);
                Console.WriteLine(result);

                //- For multiples of 5 print "Fizz"
                //- For multiples of 9 print "Buzz"
                //- For multiples of 27 print "Bar"

                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Dictionary<long, string> keyValuePairs = new Dictionary<long, string> { { 5, "Fizz" }, { 9, "Buzz" }, { 27, "Bar" } };

                TwistedFizzBuzz.TwistedFizzBuzz.ReasignTokens(keyValuePairs);

                result = TwistedFizzBuzz.TwistedFizzBuzz.ResolveCustomFizzBuzzProblem(-1, 271);
                Console.WriteLine(result);

                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("-----Calling the API 5 times------");

                TwistedFizzBuzz.TwistedFizzBuzz.EmptyTokens();

                for (int i = 0; i < 5; i++)
                    TwistedFizzBuzz.TwistedFizzBuzz.AddRandomTokenFromAPI();

                var s = TwistedFizzBuzz.TwistedFizzBuzz.GetTokens();

                result = TwistedFizzBuzz.TwistedFizzBuzz.ResolveCustomFizzBuzzProblem(-1, 271);
                Console.WriteLine(result);



                Console.ReadLine();
                //TwistedFizzBuzz.TwistedFizzBuzz.AddRandomToken();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
        }
    }
}
