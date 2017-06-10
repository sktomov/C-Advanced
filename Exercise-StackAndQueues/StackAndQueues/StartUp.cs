using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackAndQueues
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Problem 1.	Reverse Numbers with a Stack
            //ReverseNumbersWithStack();

            //Problem 2.	Basic Stack Operations
            //BasicStackOperations();

            //Problem 3.Maximum Element
            //MaximumElement();

            //Problem 4.	Basic Queue Operations
            //QueueOperations();

            //Problem 5.	Calculate Sequence with Queue
            //CalculateSequenceWithQueue();

            //Problem 6.	Truck Tour
            //TruckTour();

            //Problem 7.	Balanced Parentheses
            //Balanced();

            //Problem 8.Recursive Fibonacci
            //RecursiveFib();

            //Problem 9. Stack Fibonacci
            //StackFibonacci();

            //Problem 10.	 Simple Text Editor
            //SimpleTextEditor();

            //Problem 11. Poisonous Plants
            var n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var days = new int[n];
            var stack = new Stack<int>();
            stack.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (stack.Count > 0 && plants[stack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[stack.Pop()]);
                }

                if (stack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                stack.Push(i);
            }

            Console.WriteLine(days.Max());
        }

        private static void SimpleTextEditor()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            for (int i = 0; i < n; i++)
            {
                var arr = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (arr[0] == "1")
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(arr[1]);
                        continue;
                    }
                    var text = stack.Peek();
                    text += arr[1];
                    stack.Push(text);
                }
                else if (arr[0] == "2")
                {
                    var text = stack.Peek();
                    text = text.Substring(0, text.Length - int.Parse(arr[1]));
                    stack.Push(text);
                }
                else if (arr[0] == "3")
                {
                    var text = stack.Peek();
                    Console.WriteLine(text[int.Parse(arr[1]) - 1]);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        private static void StackFibonacci()
        {
            long n = long.Parse(Console.ReadLine());
            var fibonacci = new Stack<long>();
            long a = 0;
            long b = 1;
            for (int i = 0; i < n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
                fibonacci.Push(a);
            }
            Console.WriteLine(fibonacci.Pop());
        }

        private static void RecursiveFib()
        {
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(n));
        }

        public static long Fibonacci(int n)
        {
            long a = 0;
            long b = 1;
            for (int i = 0; i < n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
        private static void Balanced()
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>();
            var isValid = true;

            foreach (var c in input)
            {
                if (c.Equals('(') || c.Equals('{') || c.Equals('['))
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    var last = stack.Pop();
                    if (last.Equals('(') && !c.Equals(')'))
                    {
                        isValid = false;
                        break;
                    }
                    else if (last.Equals('[') && !c.Equals(']'))
                    {
                        isValid = false;
                        break;
                    }
                    else if (last.Equals('{') && !c.Equals('}'))
                    {
                        isValid = false;
                        break;
                    }

                }
            }


            if (isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static void TruckTour()
        {
            var n = int.Parse(Console.ReadLine());
            var pumps = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }
            for (int i = 0; i < n; i++)
            {
                if (FindPump(pumps, n))
                {
                    Console.WriteLine(i);
                    break;
                }
                var startingPump = pumps.Dequeue();
                pumps.Enqueue(startingPump);
            }
        }

        static bool FindPump(Queue<int[]> pumps, int n)
        {
            int tank = 0;
            bool found = true;
            for (int i = 0; i < n; i++)
            {
                var currentPump = pumps.Dequeue();
                tank += currentPump[0] - currentPump[1];
                if(tank < 0)
                {
                    found = false;
                }
                pumps.Enqueue(currentPump);
            }
            if (found)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void CalculateSequenceWithQueue()
        {
            long n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();

            int count = 1;
            queue.Enqueue(n);
            var result = new StringBuilder();
            while (count <= 50)
            {
                var first = queue.Peek();

                queue.Enqueue(first + 1);
                queue.Enqueue(2 * first + 1);
                queue.Enqueue(first + 2);
                result.Append(queue.Dequeue() + " ");
                count++;
            }
            Console.WriteLine(result);
        }

        private static void QueueOperations()
        {
            var cmd = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = cmd[0];
            var dequeueElements = cmd[1];
            var checkElement = cmd[2];

            var queue = new Queue<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            for (int i = 0; i < dequeueElements; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(checkElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0) Console.WriteLine(0);
                else
                    Console.WriteLine(queue.Min());
            }
        }

        private static void MaximumElement()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var max = new Stack<int>();
            for (int i = 0; i < n; i++)
            {

                var cmd = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (cmd[0] == 1)
                {
                    stack.Push(cmd[1]);
                    if (cmd[1] > 0 && max.Count > 0 && cmd[1] > max.Peek())
                    {
                        max.Push(cmd[1]);

                    }
                    if (max.Count == 0)
                    {
                        max.Push(cmd[1]);
                    }
                }
                else if (cmd[0] == 2)
                {
                    int pop = stack.Peek();
                    if (pop == max.Peek())
                    {
                        max.Pop();
                    }
                    stack.Pop();
                }
                else if (cmd[0] == 3)
                {
                    if (max.Count == 0)
                    {
                        Console.WriteLine(0);
                    }
                    else
                    {
                        Console.WriteLine(max.Peek());
                    }
                }
            }
        }

        private static void BasicStackOperations()
        {
            var cmd = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numbers = int.Parse(cmd[0]);
            var elementsToPop = int.Parse(cmd[1]);
            var elementToCheck = int.Parse(cmd[2]);

            var elements = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var stack = new Stack<int>(elements);
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(elementToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }

            }
        }

        private static void ReverseNumbersWithStack()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(int.Parse(input[i]));
            }
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{stack.Pop()} ");
            }
        }


    }
}
