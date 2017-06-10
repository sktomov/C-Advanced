using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ParseTags
{
	class Program
	{
		static void Main()
		{
			var text = Console.ReadLine();
			var openTag = "<upcase>";
			var closedTag = "</upcase>";
			var indexOpenTag = text.IndexOf(openTag);
			while (indexOpenTag != -1)
			{
				var indexClosedTag = text.IndexOf(closedTag);
				if (indexClosedTag == -1)
				{
					break;
				}
				var toBeReplaced = text.Substring(indexOpenTag, indexClosedTag + closedTag.Length - indexOpenTag);
				var replaced = toBeReplaced.Replace(openTag, string.Empty).Replace(closedTag, string.Empty).ToUpper();
				text = text.Replace(toBeReplaced, replaced);

				indexOpenTag = text.IndexOf(openTag);
			}
			Console.WriteLine(text);
		}
	}
}
