using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeAppCLI
{
    public class NavigationTools
    {
        public static int SelectSingleIntOption(int startRange, int endRange)
        {
            int result = 0;
            string userInput = "";
            int attempts = 0;

            bool hasValidSelection = false;
            do
            {
                if (attempts > 0)
                {
                    Console.WriteLine($" is not a valid option. Please enter a number between {startRange} and {endRange}");
                }

                Console.Write("Select an option... ");
                userInput = Console.ReadKey().KeyChar.ToString();
                attempts++;

                if(int.TryParse(userInput, out result))
                {
                    if(result >= startRange && result <= endRange)
                    {
                        hasValidSelection = true;
                    }
                }
            }
            while (!hasValidSelection);

            return result;
        }
        public static int SelectSingleIntOption(string message, int startRange, int endRange)
        {
            int result = 0;
            string userInput = "";
            int attempts = 0;

            bool hasValidSelection = false;
            do
            {
                if (attempts > 0)
                {
                    Console.WriteLine($" is not a valid option. Please enter a number between {startRange} and {endRange}");
                }

                Console.Write(message);
                userInput = Console.ReadKey().KeyChar.ToString();
                attempts++;

                if (int.TryParse(userInput, out result))
                {
                    if (result >= startRange && result <= endRange)
                    {
                        hasValidSelection = true;
                    }
                }
            }
            while (!hasValidSelection);

            return result;
        }
    }
}
