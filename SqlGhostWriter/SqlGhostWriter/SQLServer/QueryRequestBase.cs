using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlGhostWriter.SQLServer
{
	public abstract class QueryRequestBase
	{
		public string Table { get; internal set; }
	}
}
