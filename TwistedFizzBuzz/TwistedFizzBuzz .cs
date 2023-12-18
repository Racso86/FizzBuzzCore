using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TwistedFizzBuzz.Classes;

namespace TwistedFizzBuzz
{
    public class TwistedFizzBuzz
    {
        private static Dictionary<long,string> _Tokens { get; set; } = new Dictionary<long, string> { { 3, "Fizz" }, { 5, "Buzz" } };

        public TwistedFizzBuzz() {
            
        }

        public static void EmptyTokens()
        {
            _Tokens = new Dictionary<long, string>();
        }

        public static void ReasignTokens(Dictionary<long, string> tokens)
        {
            _Tokens = tokens;
        }
        public static Dictionary<long, string> GetTokens()
        {
            return _Tokens;
        }
        public static long[] ReadInput(string input)
        {
            var range = input.Split(new char[] { '_',')','(' }).ToList();
            range.RemoveAll( element => element.Equals(""));

            if (range.Count != 2 || !long.TryParse(range[0], out long start) || !long.TryParse(range[1], out long end))
            {
                Console.WriteLine("Invalid input format. Please provide the range in the format 'start-end'.");
                return null;
            }
            return new long[] { start, end };
        }

        /// <summary>
        /// - Accept user input for a range of numbers and returns their FizzBuzz output. For example, 1_50, 1_2,000,000,000, or (-2)_(-37)
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="endRange"></param>
        /// <returns></returns>
        public static string ResolveStandardFizzBuzzProblem(long startRange = 1, long endRange = 100)
        {
            if ( startRange < endRange)
            {
                string output = "";
                for (long i = startRange; i <= endRange; i++)
                {
                    output += FizzBuzzValue(i);
                }
                return output;
            }
            else
            {
                return "Not a valid range, endRange must be greater than startRange.";
            }
        }

        /// <summary>
        /// - Accept user input for a range of numbers and returns their FizzBuzz output. For example, 1_50, 1_2,000,000,000, or (-2)_(-37)
        /// </summary>
        /// <param name="startRange"></param>
        /// <param name="endRange"></param>
        /// <returns></returns>
        public static string ResolveCustomFizzBuzzProblem(long startRange = 1, long endRange = 100)
        {
            OrderTokens();
            if (startRange < endRange)
            {
                string output = "";
                for (long i = startRange; i <= endRange; i++)
                {
                    output += FizzBuzzValueFromTokens(i)+ "\n";
                }
                return output;
            }
            else
            {
                return "Not a valid range, endRange must be greater than startRange.";
            }
        }

        public static void OrderTokens()
        {
            var result = _Tokens.OrderBy(kvp => kvp.Key);
            EmptyTokens();
            foreach (var token in result)
                _Tokens.Add(token.Key, token.Value);
        }

        /// <summary>
        /// 	- Accept user input of a non-sequential set of numbers and returns their FizzBuzz output. For example: -5, 6, 300, 12, 15
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FizzBuzzValue(long input)
        {
            if (input % 3 == 0 && input % 5 == 0)
            {
                return "FizzBuzz\n";
            }
            else if (input % 3 == 0)
            {
                return "Fizz\n";
            }
            else if (input % 5 == 0)
            {
                return "Buzz\n";
            }
            else
            {
                return input + "\n";
            }
        }

        public static string FizzBuzzValueFromTokens(long input)
        {
            string output = "";
            foreach (var kvp in _Tokens)
            {
                if (input % kvp.Key == 0)
                {
                    output += kvp.Value;
                }
                
            }
            if (string.IsNullOrEmpty(output))
            {
                return input.ToString();
            }
            else
            {
                return output;
            }
        }

        /// <summary>
        /// - Accept user input for alternative tokens instead of "Fizz" and "Buzz" and alternative divisors instead of 3 and 5. For example, 7, 17, and 3 would use "Poem", "Writer", and "College". 119 would output "PoemWriter", 51 would output "WriterCollege", 21 would output "PoemCollege, and 357 would output "PoemWriterCollege"
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="word"></param>
        public static void AddCustomToken(long multiplier, string word)
        {
            _Tokens.Add(multiplier, word);
            return;
        }


        /// <summary>
        /// 	- Accept user input for API generated tokens provided by [https://rich-red-cocoon-veil.cyclic.app/](https://rich-red-cocoon-veil.cyclic.app/)
        /// </summary>
        public static void AddRandomTokenFromAPI()
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = httpClient.GetAsync("https://rich-red-cocoon-veil.cyclic.app/random").GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                    int multiple = apiResponse.Multiple;
                    string word = apiResponse.Word;

                    if (_Tokens.ContainsKey(multiple))
                    {
                        _Tokens[multiple] = word;
                    }
                    else
                    {
                        _Tokens.Add(multiple, word);
                    }
                }
                else
                {
                    Console.WriteLine($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                httpClient.Dispose();
            }
        }


    }
}
