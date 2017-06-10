using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UserLogs
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var users = new SortedDictionary<string, Dictionary<string, int>>();

        while (input != "end")
        {
            var arr = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var ip = arr[0].Substring(3);
            var userName = arr[2].Substring(5);
            if (!users.ContainsKey(userName))
            {
                users[userName] = new Dictionary<string, int>();
                users[userName][ip] = 1;
            }
            else
            {
                if (users[userName].ContainsKey(ip))
                {
                    users[userName][ip]++;
                }
                else
                {
                    users[userName][ip] = 1;
                }
            }

            input = Console.ReadLine();
        }
        foreach (var user in users)
        {
            Console.WriteLine($"{user.Key}:");
            Console.WriteLine("{0}.", string.Join(", ", user.Value.Select(a => $"{a.Key} => {a.Value}")));
        }
    }
}

