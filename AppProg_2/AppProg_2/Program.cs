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
            char[] alphabetTest = "abc".ToCharArray();
            Console.WriteLine("Введите предложение для щифрования.");
            var originalStringInCharArray = Console.ReadLine().ToCharArray();

            Console.Write("Укажите шаг сдвига: ");
            var step = Convert.ToInt32(Console.ReadLine()) % 26;
            //25 норм, 26 слом
            for (var i = 0; i < originalStringInCharArray.Length; i++)
            {
                var positionInAlphabet = Array.IndexOf(alphabet, originalStringInCharArray[i]);
                if (step > 0)
                {
                    Console.WriteLine(alphabet[(positionInAlphabet + step) % 26]);
                }



            }
        }
    }
}
