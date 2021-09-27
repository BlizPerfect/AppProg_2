using System;
using System.Collections.Generic;
namespace AppProg_2
{
    class Program
    {

        static void Main(string[] args)
        {
            LinkedList<char> alphabetTestNew = new LinkedList<char>();

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            Console.WriteLine("Введите предложение для щифрования.");
            var originalStringInCharArray = Console.ReadLine().ToCharArray();

            Console.Write("Укажите шаг сдвига: ");
            var step = Convert.ToInt32(Console.ReadLine()) % 26;
            for (var i = 0; i < originalStringInCharArray.Length; i++)
            {
                var positionInAlphabet = Array.IndexOf(alphabet, originalStringInCharArray[i]);
                if (step >= 0)
                {
                    Console.WriteLine(alphabet[(positionInAlphabet + step) % 26]);
                }
                else
                {
                    if (positionInAlphabet + step >= 0)
                    {
                        Console.WriteLine(alphabet[positionInAlphabet + step]);
                    }
                    else
                    {
                        Console.WriteLine(alphabet[26 + (positionInAlphabet + step)]);
                    }
                }
            }
        }
    }
}
