using System.Collections.Generic;
using System.Linq;

namespace SqlGhostWriter.SQLServer
{
	public class Order : IOrderPhrase
	{
		internal Order()
		{
			Words = new List<string>();
		}

		public List<string> Words { get; }

		internal Order Add(string word)
		{
			Words.Add(word);
			return this;
		}

		internal Order AddRange(string[] words)
		{
			Words.AddRange(words);
			return this;
		}

		public override string ToString()
		{
			return Words?.Any(x => x != null) ?? false
				? $"({string.Join($", ", Words)})"
				: string.Empty;
		}
	}
}
