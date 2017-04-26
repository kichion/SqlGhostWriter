namespace SqlGhostWriter.SQLServer
{
	public class Select : QueryRequestBase, ISelectRequest, IWhereRequest, IOrderRequest
	{
		internal Select(string selectElement)
            : this(new[] {selectElement}) { }

		internal Select(string[] selectElements)
		{
			Elements = selectElements;
		}

		public string[] Elements { get; internal set; }
		public IWherePhrase Where { get; internal set; }
		public IOrderPhrase Order { get; internal set; }

		public override string ToString()
		{
			return $"SELECT {string.Join(", ", Elements)} "
				 + $"FROM {Table} WITH(NOLOCK)"
				 + (Where != null ? $" WHERE {Where.ToString()}" : string.Empty)
				 + (Order != null ? $" ORDER BY {Order.ToString()}" : string.Empty);
		}
	}
}
