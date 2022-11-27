using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Oodit_Assignment.Controllers.Home.input
{
    public static class HomeInputHandler
    {
        private const string CHAR_SQUARE_BRACKET_OPEN = "[";
        private const string CHAR_SQUARE_BRACKET_CLOSE = "]";
        private const string CHAR_SPACE = " ";
        private const string CHAR_COMMA = ",";
        private const string RESPONSE_ERROR = "Error processing the input";
        private const string RESPONSE_EMPTY = "[]";

        /**
         * Process the input
         * @params inputString - string inputed by the user
         * @returns - string with the array of values repeated more than 3 times or string with empty array or empty error message
         */
        public static string HandleInputArray(string inputString)
        {
            List<int> finalList = new List<int>();
            if (HomeInputValidator.IsNotEmpty(inputString))
            {
                inputString = RemoveExtraCharacters(inputString);
                var inputArray = inputString.Split(CHAR_COMMA);

                if (!HomeInputValidator.ValidateValues(inputArray))
                {
                    return RESPONSE_ERROR;
                }

                var numberCount = CountNumber(inputArray);
                finalList.AddRange(GenerateThreeOrPlusCountArray(numberCount));
            }
            var finalValues = string.Join(",", finalList);
            return (finalList.Count != 0) ? CHAR_SQUARE_BRACKET_OPEN + finalValues + CHAR_SQUARE_BRACKET_CLOSE : RESPONSE_EMPTY;
        }

        /**
         * Generate and sort, in descending order, the final list with the numbers with more or equal than 3 ocurrences
         * @params numberCount - the dictionary with the number and their occurrences
         * @returns list of numbers with more or equal than 3 occurances
         */
        private static List<int> GenerateThreeOrPlusCountArray(Dictionary<int, int> numberCount)
        {
            var finalList = new List<int>();
            foreach (KeyValuePair<int, int> entry in numberCount)
            {
                // include if more than 3 ocurrences
                if(entry.Value >= 3)
                {
                    finalList.Add(entry.Key);
                }
            }

            //Sort descending order
            finalList.Sort((x, y) => y.CompareTo(x));

            //Convert to array
            return finalList;
        }

        /**
         * Generates the dictionary with all number on the list and their occurrences
         * @params inputArray - array with all strings numbers
         * @returns the dictionary with all number on the list and their occurrences
         */
        private static Dictionary<int, int> CountNumber(string[] inputArray)
        {
            var numberCount = new Dictionary<int, int>();
            foreach (var element in inputArray)
            {
                int number = int.Parse(element);
                if (numberCount.ContainsKey(number))
                {
                    numberCount[number] = numberCount[number] + 1;
                }
                else
                {
                    numberCount.Add(number, 1);
                }
            }
            return numberCount;
        }

        /**
         * Remove Extra Characters from the input (square brackets and spaces)
         * @params inputString - string inputed by the user
         * @returns - string without extra characters
         */
        private static string RemoveExtraCharacters(string inputString)
        {
            inputString = inputString.Replace(CHAR_SPACE, string.Empty);
            inputString = inputString.Replace(CHAR_SQUARE_BRACKET_OPEN, string.Empty);
            inputString = inputString.Replace(CHAR_SQUARE_BRACKET_CLOSE, string.Empty);
            return inputString;
        }
    }
}
