using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlGhostWriter.SQLServer
{
	public class Insert : QueryRequestBase, IInsertRequest
	{
		public Dictionary<string, object> Data { get; internal set; }

		public override string ToString()
		{
			var convert = new Func<object, string>(value => value.ToString().ToUpper() == "NULL" ? value.ToString() : $"N'{value}'");
			return $"INSERT INTO {Table} ({string.Join(",", Data.Select(x => "[" + x.Key + "]"))}) VALUES ({string.Join(",", Data.Select(x => convert(x.Value)))})";
		}
	}
}
