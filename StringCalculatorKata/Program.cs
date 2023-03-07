using System;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int sumVals(string[] toAdd)
        {
            int sum = 0;
            foreach (string num in toAdd)
            {
                if (String.IsNullOrEmpty(num))
                    sum += 0;
                else if (int.Parse(num) < 0)
                    throw new Exception("No! Bad");
                else if (int.Parse(num) <= 1000)
                    sum += int.Parse(num);
            }

            return sum;
        }

        public int add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                return 0;
            else
            {
                if (numbers[0] != '[')
                {
                    char delimiter = (numbers[0] > '0' && numbers[0] < '9' && numbers[0] != '[') ? ',' : numbers[0];
                    string[] toAdd = numbers.Split('\n', delimiter);
                    int sum = sumVals(toAdd);

                    return sum;
                }
                else
                {
                    string[] separators = { "\n" };
                    string multiCharDelimiter = "";
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (numbers[i] == '[')
                            continue;

                        if (numbers[i] == ']')
                        {
                            Array.Resize(ref separators, separators.Length + 2);
                            separators[separators.GetUpperBound(0) - 1] = multiCharDelimiter;
                            separators[separators.GetUpperBound(0)] = "[" + multiCharDelimiter + "]";
                            multiCharDelimiter = "";

                            continue;
                        }

                        multiCharDelimiter += numbers[i];
                    }

                    string[] toAdd = numbers.Split(separators, StringSplitOptions.None);
                    int sum = sumVals(toAdd);

                    return sum;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            var result = calculator.add("[###][$][!]1$2!3###43");
            Console.WriteLine(result);
        }
    }
}
