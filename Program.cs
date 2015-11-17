using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Of_String
{
    public static class Program
    {
       static double stringCount = 0;
       static double medianLength = 0.0;


        public static void Main(string[] args)
        {
          

            Stack<string> listOfStrings = new Stack<string>();
            //output stack
            Stack<string> stringOutput = new Stack<string>();

            //adding strings to the stack listOfstrings
            listOfStrings.Push("I love New York");
            listOfStrings.Push("Be the change you wish to see in the world");
            listOfStrings.Push("BURNing question");
            listOfStrings.Push("I love you");
            listOfStrings.Push("Here we go again-");
            listOfStrings.Push("Proud Kent stater!");

            //ouputing the stack to the debugger and also keep a count
            Console.WriteLine("Current stack: ");
            foreach (string c in listOfStrings)
            {
                Console.WriteLine(c + " ");
                stringCount += 1;
            }

            Console.WriteLine();
            Console.ReadLine();

            //check the length of each string and compare it
            foreach (string c in listOfStrings)
            {
               
                Console.WriteLine(c.Length + "");

                //if the length is a multiple of 4 then it is reversed
                if (c.Length % 4 == 0)
                {
                    Console.WriteLine(Reverse(c));
                    stringOutput.Push(Reverse(c));
                    stringCount += 1;

                }
                //truncate the string if it is a multiple of 5
                if (c.Length % 5 == 0)
                {
      
                   string  slice = c.Truncate(5);
                    Console.WriteLine(slice);
                    stringOutput.Push(slice);
                    stringCount += 1;
                }

                //print string without hyphen
                Console.WriteLine(GetResultsWithOutHyphen(c));

                //call the funcions upperFive and converToUpper to check 
                //if at least the first three characters in the first five
                //are upper and then convert the entire string to upper.

                if (upperFive(c))
                {
                    Console.WriteLine(convertToUpper(c));
                    stringOutput.Push(convertToUpper(c));
                    stringCount += 1;

                }

            }
            //Ouput the final stack
            Console.WriteLine();
            Console.WriteLine("Final stack: ");
            foreach (string c in stringOutput)
            {
                Console.WriteLine(c + " ");
            }
            Console.WriteLine();

            //output total characters in the original stack listOfStrings
            Console.WriteLine("The total characters for the input: ");
            int totalFinalChars = numberOfCharacters(listOfStrings);
            Console.WriteLine(totalFinalChars);

            //output for total characters after changes
            Console.WriteLine("The total characters ouptput: ");
            int totalBeginChars = numberOfCharacters(stringOutput);
            Console.WriteLine(totalBeginChars);

            //median output
            medianLength = (totalFinalChars + totalBeginChars) / stringCount;
            Console.WriteLine("The median is:");
            Console.WriteLine(medianLength);

            Console.ReadLine();
        }



        //reverse function converts the string to character array and then 
        //reverse every character individually
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //truncate function
        //take the value and then truncate it to five
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
      
        //takes in a string and checks for condition c)
        //if 3 uppercase chars found in first 5 chars,
        public static bool upperFive(string str)
        {
            if(str.Length < 5)
            {
                return false;
            }
            char[] letters = str.ToCharArray();
            int upperCount = 0;
            for (int i = 0; i < 5; ++i)
            {
                if (char.IsUpper(letters[i]))
                {
                    upperCount += 1;
                }
            }

            if (upperCount >= 3)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        //convert the string to all upper case
        public static String convertToUpper(String str)
        {
            return str.ToUpper();
        }

        //removing hyphen
        public static string GetResultsWithOutHyphen(string input)
        {
            // Removing hyphen at the end
            return input.Trim('-');

        }


        //number of Characters
        public static int numberOfCharacters(Stack<string> userStrings)
        {
            int count = 0;
            while (userStrings.Count != 0)
            {
                string word = userStrings.Pop();
                count += word.Length;
            }
            return count;
        }

    }
   
}
 