using System.Collections.Generic;
using System.Linq;

namespace SqlGhostWriter.SQLServer
{
	public class Where : IWherePhrase
	{
		private readonly SqlQueryConjunctionType _type;

		internal Where(SqlQueryConjunctionType type)
		{
			_type = type;
			Words = new List<string>();
		}

		public List<string> Words { get; }

		internal Where Add(string word)
		{
			Words.Add(word);
			return this;
		}

		internal Where AddRange(string[] words)
		{
			Words.AddRange(words);
			return this;
		}

		public override string ToString()
		{
			return Words?.Any(x => x != null) ?? false
				? $"({string.Join($" {_type} ", Words)})"
				: string.Empty;
		}
	}
}
