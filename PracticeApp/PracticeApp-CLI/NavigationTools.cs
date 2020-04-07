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

        public static string GetString(string message)
        {
            string userInput = String.Empty;
            int attempts = 0;

            do
            {
                if (attempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                attempts++;
            }
            while (String.IsNullOrEmpty(userInput));

            return userInput;
        }
        public static bool GetBoolYorN(string message)
        {
            string userInput = String.Empty;
            bool boolValue = false;
            bool hasValidSelection = false;
            int attempts = 0;

            do
            {
                if (attempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadKey().KeyChar.ToString();
                attempts++;
                if (userInput.ToLower() == "y")
                {
                    boolValue = true;
                    hasValidSelection = true;
                }
                else if (userInput.ToLower() == "n")
                {
                    boolValue = false;
                    hasValidSelection = true;
                }
            }
            while (!hasValidSelection);

            return boolValue;
        }
    }
}
