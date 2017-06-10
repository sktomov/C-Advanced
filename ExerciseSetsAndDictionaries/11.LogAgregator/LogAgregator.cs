using System;
using System.Collections.Generic;
using System.Linq;


class LogAgregator
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var logs = new SortedDictionary<string, SortedDictionary<string, int>>();

        for (int i = 0; i < n; i++)
        {
            var arr = Console.ReadLine().Split(' ');
            var user = arr[1];
            var ipAddress = arr[0];
            var count = int.Parse(arr[2]);

            if (!logs.ContainsKey(user))
            {
                logs.Add(user, new SortedDictionary<string, int>());
            }
            if (!logs[user].ContainsKey(ipAddress))
            {
                logs[user].Add(ipAddress, 0);
            }
            logs[user][ipAddress] += count;
        }
        foreach (var log in logs)
        {
            Console.WriteLine($"{log.Key}: {log.Value.Values.Sum()} [{string.Join(", ", log.Value.Keys)}]");
        }
    }
}

