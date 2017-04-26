namespace SqlGhostWriter.SQLServer
{
	public class Delete : QueryRequestBase, IDeleteRequest
	{
		public Where Where { get; set; }

		public override string ToString()
		{
			return $"DELETE FROM {Table}"
					+ (Where != null ? $" WHERE {Where.ToString()}" : string.Empty);
		}
	}
}
