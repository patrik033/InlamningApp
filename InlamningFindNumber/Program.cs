using System;
using System.Numerics;

namespace InlamningFindNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string toBeSearched = "29535123p48723487597645723645";
            BigInteger toHoldNumber = 0;
            int lengthOfString;
            string toNewString = ""; 
            for (int i = 0; i < toBeSearched.Length; i++)
            {
                char firstOcc = toBeSearched[i];
                int indexOf = toBeSearched.IndexOf(firstOcc, i + 1);
                lengthOfString = indexOf - i;
                lengthOfString++;
                bool isLetters = false;
                toNewString = "";

                for (int j = i; j <= indexOf; j++)
                {
                    if (Char.IsLetter(toBeSearched[j]))
                    {
                        isLetters = true;
                    }
                }

                if(isLetters != true) 
                {
                    if (i == 0)
                    {
                        FirsOutput(toBeSearched, ref toHoldNumber, lengthOfString, ref toNewString, i, indexOf);
                    }

                    else if (i > 0 && indexOf > 0 && indexOf < toBeSearched.Length - 1)
                    {
                        MiddleOutput(toBeSearched, ref toHoldNumber, lengthOfString, ref toNewString, i, indexOf);
                    }

                    else if (indexOf == toBeSearched.Length - 1)
                    {
                        LastOutput(toBeSearched, ref toHoldNumber, ref toNewString, i, indexOf);
                    }
                }
            }
            Console.WriteLine($"\n\n The total sum is: {toHoldNumber}");
          
            Console.ReadLine();
        }

        private static void FirsOutput(string toBeSearched, ref BigInteger toHoldNumber, int lengthOfString, ref string toNewString, int i, int indexOf)
        {
            toNewString += AddString(toBeSearched, i, indexOf);
            toHoldNumber += ConvertToNumber(toNewString);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(toBeSearched.Substring(i, lengthOfString + i));
            Console.ResetColor();
            Console.Write(toBeSearched.Substring(indexOf + 1));
            Console.WriteLine();
        }

        private static void MiddleOutput(string toBeSearched, ref BigInteger toHoldNumber, int lengthOfString, ref string toNewString, int i, int indexOf)
        {
            toNewString += AddString(toBeSearched, i, indexOf);
            toHoldNumber += ConvertToNumber(toNewString);
            Console.Write(toBeSearched.Substring(0, i));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(toBeSearched.Substring(i, lengthOfString));
            Console.ResetColor();
            Console.Write(toBeSearched.Substring(indexOf + 1));
            Console.WriteLine();
        }

        private static void LastOutput(string toBeSearched, ref BigInteger toHoldNumber, ref string toNewString, int i, int indexOf)
        {
            toNewString += AddString(toBeSearched, i, indexOf);
            toHoldNumber += ConvertToNumber(toNewString);
            Console.Write(toBeSearched.Substring(0, i));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(toBeSearched.Substring(i));
            Console.ResetColor();
            Console.WriteLine();
        }

        private static BigInteger ConvertToNumber(string inputString)
        {
            bool tryParseToBig = BigInteger.TryParse(inputString, out BigInteger tempBig);
            return tempBig;
        }
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
