using System;
using System.Collections.Generic;

namespace _5.PhoneBook
{
    public class PhoneBook
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var phoneBook = new Dictionary<string, string>();

            while (input != "search")
            {
                var inputArr = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (phoneBook.ContainsKey(inputArr[0]))
                {
                    phoneBook[inputArr[0]] = string.Empty;
                }
                phoneBook[inputArr[0]] = inputArr[1];
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "stop")
            {
                if (!phoneBook.ContainsKey(input))
                {
                    Console.WriteLine($"Contact {input} does not exist.");

                }
                else
                {
                    Console.WriteLine($"{input} -> {phoneBook[input]}");
                }
                input = Console.ReadLine();
            }

        }
    }
}
