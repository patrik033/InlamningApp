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
     
            int lengthOfString = 0;
           
            for (int i = 0; i < toBeSearched.Length; i++)
            {
                char firstOcc = toBeSearched[i];
                int indexOf = toBeSearched.IndexOf(firstOcc, i + 1);
                lengthOfString = indexOf - i;
                lengthOfString++;


                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(toBeSearched.Substring(i, lengthOfString+i));
                    Console.ResetColor();
                    Console.Write(toBeSearched.Substring(indexOf+1));
                    Console.WriteLine();
                }

                else if (i > 0 && indexOf > 0 && indexOf < toBeSearched.Length - 1)
                {


                    Console.Write(toBeSearched.Substring(0, i));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(toBeSearched.Substring(i, lengthOfString));
                    Console.ResetColor();
                    Console.Write(toBeSearched.Substring(indexOf+1));
                    Console.WriteLine();
                }

                else if (indexOf == toBeSearched.Length - 1)
                {
                    Console.Write(toBeSearched.Substring(0, i));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(toBeSearched.Substring(i));
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
