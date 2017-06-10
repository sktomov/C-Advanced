using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.UniqueUsernames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var username = Console.ReadLine();
                set.Add(username);
            }
            foreach (var user in set)
            {
                Console.WriteLine(user);
            }
        }
    }
}
