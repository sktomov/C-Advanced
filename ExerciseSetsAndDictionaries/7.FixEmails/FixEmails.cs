using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class FixEmails
{
    static void Main()
    {
        var input = Console.ReadLine();
        var users = new Dictionary<string, string>();
        string user = string.Empty;
        while (input != "stop")
        {

            if (!input.Contains("@"))
            {
                user = input;
                if (!users.ContainsKey(input))
                {
                    users[input] = string.Empty;
                }
            }
            else
            {
                var domain = input.Substring(input.Length - 2).ToLower();
                if (domain != "uk" && domain != "us")
                {
                    users[user] = input;
                }
                else
                {
                    users.Remove(user);
                }
            }
            input = Console.ReadLine();
        }
        foreach (var kvp in users)
        {
            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        }
    }
}

