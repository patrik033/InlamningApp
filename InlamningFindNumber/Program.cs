using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace InlamningFindNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomColors = new Random();
            Regex regex = new Regex("^[0-9]*$");
            
            //Console.Write("Enter a text string: ");
            //string toBeSearched = Console.ReadLine();
            string toBeSearched = "29535123p48723487597645723645";
            BigInteger toHoldNumber = 0;
            int lengthOfString;
            string updateCharToString = "";


            for (int i = 0; i < toBeSearched.Length; i++)
            {
                char firstOcc = toBeSearched[i];
                //nästa karaktär med samma värde som i
                int indexOf = toBeSearched.IndexOf(firstOcc, i + 1);
                //längden på strängen
                lengthOfString = indexOf - i;
                lengthOfString++;
                bool isLetter = false;
                updateCharToString = "";
                //Kollar för varje varv om räknaren inte är en siffra mellan 0-9
                isLetter = IsMatch(regex, toBeSearched, i, indexOf, isLetter);




                //skriver ut till konsolen med färg om charen är ett nummer
                //om isletter är sann skrivs det inte ut
                if (!isLetter == true)
                {
                    if (i == 0)
                    {
                        FirsOutput(toBeSearched, ref toHoldNumber, lengthOfString, ref updateCharToString, i, indexOf, randomColors);
                    }

                    else if (i > 0 && indexOf > 0 && indexOf < toBeSearched.Length - 1)
                    {
                        MiddleOutputs(toBeSearched, ref toHoldNumber, lengthOfString, ref updateCharToString, i, indexOf, randomColors);
                    }

                    else if (indexOf == toBeSearched.Length - 1)
                    {
                        LastOutput(toBeSearched, ref toHoldNumber, ref updateCharToString, i, indexOf, randomColors);
                    }
                }
            }
            Console.WriteLine($"\n\nThe sum for all numbers in colors are: {toHoldNumber}");
            Console.ReadLine();
        }

        private static bool IsMatch(Regex regex, string toBeSearched, int i, int indexOf, bool isLetter)
        {
            for (int j = i; j <= indexOf; j++)
            {
                if (!regex.IsMatch(toBeSearched[j].ToString()))
                {
                    isLetter = true;
                }
            }
            return isLetter;
        }

        //skriver ut början på strängen i färg
        private static void FirsOutput(string toBeSearched, ref BigInteger toHoldNumber, int lengthOfString, ref string toNewString, int i, int indexOf, Random rand)
        {

           
                Console.ForegroundColor = (ConsoleColor)rand.Next(1, 7);
                Console.Write(toBeSearched.Substring(i, lengthOfString));
                Console.ResetColor();
                Console.Write(toBeSearched.Substring(indexOf + 1));
                Console.WriteLine();
                toNewString += AddString(toBeSearched, i, indexOf);
                toHoldNumber += ConvertToNumber(toNewString);


        }
        //skriver ut mitten på strängen i färg
        private static void MiddleOutputs(string toBeSearched, ref BigInteger toHoldNumber, int lengthOfString, ref string toNewString, int i, int indexOf, Random rand)
        {


            Console.Write(toBeSearched.Substring(0, i));
            Console.ForegroundColor = (ConsoleColor)rand.Next(1, 7);
            Console.Write(toBeSearched.Substring(i, lengthOfString));
            Console.ResetColor();
            Console.Write(toBeSearched.Substring(indexOf + 1));
            Console.WriteLine();
            toNewString += AddString(toBeSearched, i, indexOf);
            toHoldNumber += ConvertToNumber(toNewString);
        }
        //skriver ut slutet på strängen i färg
        private static void LastOutput(string toBeSearched, ref BigInteger toHoldNumber, ref string toNewString, int i, int indexOf, Random rand)
        {
            toNewString += AddString(toBeSearched, i, indexOf);
            toHoldNumber += ConvertToNumber(toNewString);
            Console.Write(toBeSearched.Substring(0, i));
            Console.ForegroundColor = (ConsoleColor)rand.Next(1, 7);
            Console.Write(toBeSearched.Substring(i));
            Console.ResetColor();
            Console.WriteLine();
        }
        //försöker konvertera delsträngen till en BigInteger
        private static BigInteger ConvertToNumber(string inputString)
        {
            bool tryParseToBig = BigInteger.TryParse(inputString, out BigInteger tempBig);
            return tempBig;
        }
        //Lägger till alla char i delsträngen till en sträng
        private static string AddString(string toBeSearched, int i, int indexOf)
        {
            string fromCharToString = "";
            for (int k = i; k <= indexOf; k++)
            {
                fromCharToString += toBeSearched[k].ToString();
            }
            return fromCharToString;
        }
    }
}
