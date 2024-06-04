using System.Text.Json;

namespace FizzBuzzApp.Services
{
    public class FizzBuzzService
    {
        public List<string> Process(object[] values)
        {
            var results = new List<string>();

            foreach (var value in values)
            {
                if (value is int || value is long || value is double || (value is JsonElement jsonElement && jsonElement.ValueKind == JsonValueKind.Number)) // Add other numeric types if needed
                {
                    int intValue;
                    if (value is JsonElement jsonElementValue)
                    {
                        if (jsonElementValue.TryGetInt32(out intValue))
                        {
                            results.AddRange(ProcessValue(intValue));
                        }
                        else if (jsonElementValue.TryGetInt64(out long longValue))
                        {
                            results.AddRange(ProcessValue((int)longValue));
                        }
                        else if (jsonElementValue.TryGetDouble(out double doubleValue))
                        {
                            results.AddRange(ProcessValue((int)doubleValue));
                        }
                        else
                        {
                            results.Add("Invalid item");
                        }
                    }
                    else
                    {
                        intValue = Convert.ToInt32(value);
                        results.AddRange(ProcessValue(intValue));
                    }
                }
                else
                {
                    results.Add("Invalid item");
                }
            }

            return results;
        }

        private static List<string> ProcessValue(int value)
        {
            var results = new List<string>();
            bool isDivisibleBy3 = value % 3 == 0;
            bool isDivisibleBy5 = value % 5 == 0;

            if (isDivisibleBy3 && isDivisibleBy5)
            {
                results.Add("FizzBuzz");
            }
            else if (isDivisibleBy3)
            {
                results.Add("Fizz");
            }
            else if (isDivisibleBy5)
            {
                results.Add("Buzz");
            }
            else
            {
                results.Add($"Divided {value} by 3");
                results.Add($"Divided {value} by 5");
            }
            return results;
        }
    }
}
