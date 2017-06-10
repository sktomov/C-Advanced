using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //ReverseString();
            //SimpleCalculator();
            //Binary();
            //Brackets();
            //HotPatato();
            MathPatato();

        }

        private static void MathPatato()
        {
            var input = Console.ReadLine();
            var queue = new Queue<string>(input.Split(' '));
            var number = int.Parse(Console.ReadLine());
            int cycle = 1;
            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                if (PrimeTool.IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                cycle++;
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        public static class PrimeTool
        {
            public static bool IsPrime(int candidate)
            {
                // Test whether the parameter is a prime number.
                if ((candidate & 1) == 0)
                {
                    if (candidate == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // Note:
                // ... This version was changed to test the square.
                // ... Original version tested against the square root.
                // ... Also we exclude 1 at the end.
                for (int i = 3; (i * i) <= candidate; i += 2)
                {
                    if ((candidate % i) == 0)
                    {
                        return false;
                    }
                }
                return candidate != 1;
            }
        }
        private static void HotPatato()
        {
            var input = Console.ReadLine();
            var queue = new Queue<string>(input.Split(' '));
            var number = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        private static void Brackets()
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                if (input[i] == ')')
                {
                    var startIndex = stack.Pop();
                    string result = input.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(result);
                }
            }
        }

        private static void Binary()
        {
            var input = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            if (input == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (input != 0)
                {
                    stack.Push(input % 2);
                    input /= 2;
                }
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }

        private static void SimpleCalculator()
        {
            var input = Console.ReadLine().Split(' ');
            var stack = new Stack<string>(input.Reverse());
            while (stack.Count > 1)
            {
                var firstNumber = int.Parse(stack.Pop());
                var op = stack.Pop();
                var secondNumber = int.Parse(stack.Pop());
                if (op == "+")
                {
                    stack.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    stack.Push((firstNumber - secondNumber).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }

        private static void ReverseString()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
