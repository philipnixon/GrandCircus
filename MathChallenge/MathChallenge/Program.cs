using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1, number2, i;
            int count1, count2;
            int[] array1, array2;
            char doAgain;
            bool letsGo = true;

            //start in a loop so that we don't have to close the console if the user messes up
            while (letsGo == true)
            {
                Console.WriteLine("Hello! Please enter two numbers of equal length in digits.");

                if (int.TryParse(Console.ReadLine(), out number1))
                {
                    //count digits in number1 after user input is assigned to number1
                    count1 = DigitCount(number1, 0);
                    Console.WriteLine("First number = " + number1 + ". Please enter the second number:");

                    if (int.TryParse(Console.ReadLine(), out number2))
                    {
                        //count digits in number2 after user input is assigned to number2
                        count2 = DigitCount(number2, 0);
                        Console.WriteLine("Second number = " + number2 + ".");          

                        if (count1 == count2)
                        {
                            //convert number 1 and number 2 to array
                            array1 = NumbersToArray(number1);
                            array2 = NumbersToArray(number2);

                            //calls addarrays which will check for unique values
                            AddArrays(array1, array2);

                            letsGo = false;
                            Console.Read();
                        }
                        else
                        {
                            Console.WriteLine("Numbers are not equal in length. Would you like to start over? <Y or N>");
                            doAgain = Convert.ToChar(Console.ReadLine());

                            if (doAgain == 'Y' || doAgain == 'y')
                            {
                                letsGo = true;
                            }
                            else
                            {
                                letsGo = false;
                            }
                        }
                    }
                    else
                    {
                        letsGo = false;
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input. Would you like to start over? <Y or N>");
                    doAgain = Convert.ToChar(Console.ReadLine());

                    if (doAgain == 'Y' || doAgain == 'y')
                    {
                        letsGo = true;
                    }
                    else
                    {
                        letsGo = false;
                    }

                }

            }
        }
        public static int DigitCount(int n, int noDigits)
        //count the number of digits in each integer (pass number1 and number2), calling itself
        {
            if (n == 0)
            {
                return noDigits;
            }
            else
            {
                return DigitCount(n / 10, ++noDigits);
            }
        }

        public static int[] NumbersToArray(int i)
        //will turn int i into array -- pass number1 and number2 (separately) from main
        {
            if (i == 0) return new int[1] { 0 };

            var digits = new List<int>();

            for (; i != 0; i /= 10)
                digits.Add(i % 10);

            var arr = digits.ToArray();
            Array.Reverse(arr);
            return arr;
        }

        public static void AddArrays(int[] a, int[] b)
        //create a new array with the sum of each integer in a & b, output in the corresponding position
        //then will use a bool to determine if the array has all the same values (true) or not (false)
        {
            bool allEqual;

            int[]c = a.Zip(b, (x, y) => x + y).ToArray();

            //if the number of distinct values in array c are not equal to the total number of values,
            //that means each position did not sum to the same value. based on that, if statement will
            //tell the console what to write from the result.
            allEqual = c.Distinct().Count() != c.Count();

            if (allEqual == true)
            {
                Console.WriteLine("True!");
            }
            else
            {
                Console.WriteLine("False!");
            }
        }
    }
}
