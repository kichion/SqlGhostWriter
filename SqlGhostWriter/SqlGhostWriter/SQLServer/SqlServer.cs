using System;

namespace SqlGhostWriter.SQLServer
{
	public class SqlServer : IDatabaseManagementSystem
	{
		public ISelectRequest Select()
		{
			return new Select("*");
		}

		public ISelectRequest Select(params string[] selectElements)
		{
			return new Select(selectElements);
		}

		public IUpdateRequest Update()
		{
			return new Update();
		}

		public IInsertRequest Insert()
		{
			return new Insert();
		}

		public IDeleteRequest Delete()
		{
			return new Delete();
		}
	}
}
