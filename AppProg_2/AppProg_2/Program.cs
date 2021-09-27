using System;
using System.Collections.Generic;
using System.Text;

namespace AppProg_2
{
    class Program
    {
        public static string Calculate(char[] stringInCharArray, int step, char[] alphabet)
        {
            var result = new StringBuilder();
            for (var i = 0; i < stringInCharArray.Length; i++)
            {
                if (Array.IndexOf(alphabet, stringInCharArray[i]) != -1)
                {
                    var positionInAlphabet = Array.IndexOf(alphabet, stringInCharArray[i]);
                    var newPosition = 0;
                    if (step >= 0)
                    {
                        newPosition = (positionInAlphabet + step) % 26;
                    }
                    else
                    {
                        if (positionInAlphabet + step >= 0)
                        {
                            newPosition = positionInAlphabet + step;
                        }
                        else
                        {
                            newPosition = 26 + (positionInAlphabet + step);
                        }
                    }
                    result.Append(alphabet[newPosition]);
                }
                else
                {
                    result.Append(stringInCharArray[i]);
                }
            }
            return result.ToString();
        }
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var choise = 0;
            var step = 0;
            bool test = true;

            Console.WriteLine("Меню:\n1: Зашифровать строку.\n2: Расшифровать строку");
            while (test)
            {
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());
                    if (choise < 1 || choise > 2)
                    {
                        Console.WriteLine("Такой операции нет, повторите ввод!");
                    }
                    else
                    {
                        test = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Вы ввели не число, попробуйте сного ввести число для выбора операции.");
                }
            }
            test = true;

            Console.Write("Введите строку: ");
            var originalStringInCharArray = Console.ReadLine().ToCharArray();
            Console.Write("Укажите шаг сдвига: ");
            while (test)
            {
                try
                {
                    step = Convert.ToInt32(Console.ReadLine()) % 26;
                    test = false;
                }
                catch
                {
                    Console.WriteLine("Вы ввели не число, попробуйте сного ввести число для сдвига.");
                }
            }

            if (choise.Equals(1))
            {
                Console.Write("Зашифрованная строка: ");
            }
            else
            {
                Console.Write("Расшифрованная строка: ");
                step *= -1;
            }
            var result = Calculate(originalStringInCharArray, step, alphabet);
            Console.WriteLine(result);
        }
    }
}
