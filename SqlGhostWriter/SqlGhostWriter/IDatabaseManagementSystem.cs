namespace SqlGhostWriter
{
	public interface IDatabaseManagementSystem
	{
		ISelectRequest Select();
		ISelectRequest Select(params string[] selectElements);
		IUpdateRequest Update();
		IInsertRequest Insert();
		IDeleteRequest Delete();
	}

	public interface IDeleteRequest
	{
		string ToString();
	}

	public interface IInsertRequest
	{
		string ToString();
	}

	public interface IUpdateRequest
	{
		string ToString();
	}

	public interface ISelectRequest
	{
		string ToString();
	}

	public interface IWhereRequest
	{
		IWherePhrase Where { get; }
		string ToString();
	}

	public interface IOrderRequest
	{
		IOrderPhrase Order { get; }
		string ToString();
	}

	public interface IWherePhrase
	{
	}

	public interface IOrderPhrase
	{
	}

	/// <summary>
	/// クエリにおける語を形成するための接続詞
	/// </summary>
	public enum SqlQueryConjunctionType
	{
		And,
		Or
	}
}
