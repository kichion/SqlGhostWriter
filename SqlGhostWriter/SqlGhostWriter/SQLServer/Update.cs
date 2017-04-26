using System;
using System.Linq;

namespace SqlGhostWriter.SQLServer
{
	public class Update : QueryRequestBase, IUpdateRequest
	{
		public string[] Set { get; internal set; }
		public Where Where { get; set; }

		public override string ToString()
		{
			var convert = new Func<object, string>(value => value.ToString().ToUpper() == "NULL" ? value.ToString() : $"N'{value}'");
			return $"UPDATE {Table} "
				 + $"SET {(Set?.Any() ?? false ? string.Join(", ", Set.Select(convert)) : "")}"
				 + (Where != null ? $" WHERE {Where.ToString()}" : string.Empty);
		}
	}
}
