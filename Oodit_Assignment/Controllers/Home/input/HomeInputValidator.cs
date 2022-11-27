namespace Oodit_Assignment.Controllers.Home.input
{
    public static class HomeInputValidator
    {
        /*
         * Check if a string is empty or not
         * @params inputString - the string inputed by the user
         * @returns - true is string is not null nor empty, false otherwise
         */
        public static bool IsNotEmpty(string inputString) => inputString != null && inputString.Length > 0;

        /*
         * Check if all elements in the array can be converted to a number
         * @params inputArray - the string array with the values
         * @returns - true if all elements can be parsed to int, false otherwise
         */
        public static bool ValidateValues(string[] inputArray)
        {
            foreach(var element in inputArray){
                if (!int.TryParse(element, out _))
                {
                    return false;
                }
            }
            return true;
       }
    }
}
