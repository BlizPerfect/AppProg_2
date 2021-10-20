using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AppProg_2
{
    class Program
    {
        /// <summary>
        /// Шифровка/дешифровка массива символов(строки).
        /// </summary>
        /// <returns>string</returns>
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

        /// <summary>
        /// Ввод сдвига для расшифровка/шифровки сообщения.
        /// </summary>
        /// <returns>int</returns>
        public static int InputStep()
        {
            var result = 0;
            bool test = true;
            Console.Write("Укажите шаг сдвига: ");
            while (test)
            {
                try
                {
                    result = Convert.ToInt32(Console.ReadLine()) % 26;
                    test = false;
                }
                catch
                {
                    Console.WriteLine("Вы ввели не число, попробуйте сного ввести число для сдвига.");
                }
            }
            return result;
        }

        /// <summary>
        /// Выбор индекса опции в меню.
        /// </summary>
        /// <returns>int</returns>
        public static int MakeChoice()
        {
            Console.WriteLine("Меню:\n1: Зашифровать строку.\n2: Расшифровать строку");
            var result = 0;
            bool test = true;
            while (test)
            {
                try
                {
                    result = Convert.ToInt32(Console.ReadLine());
                    if (result < 1 || result > 2)
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
            return result;
        }
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var choise = MakeChoice();

            Console.Write("Введите строку: ");
            var originalStringInCharArray = Console.ReadLine().ToLower().ToCharArray();

            var step = InputStep();
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
