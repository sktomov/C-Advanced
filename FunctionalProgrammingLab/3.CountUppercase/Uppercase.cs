using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _3.CountUppercase
{
	class Uppercase
	{
		static void Main()
		{
			Func<string, bool> isUpper = s => s[0] == s.ToUpper()[0];
			var words = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
			words.Where(isUpper).ToList().ForEach(w => Console.WriteLine(w));
		}
	}
}
