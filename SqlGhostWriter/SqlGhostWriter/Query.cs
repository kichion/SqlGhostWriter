using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SqlGhostWriter
{
    public static class Query
    {
		private static readonly Dictionary<Type, Func<IDatabaseManagementSystem>> TypeFactory;

		static Query()
	    {
			TypeFactory = typeof(IDatabaseManagementSystem).Assembly.GetTypes()
				.Where(x => typeof(IDatabaseManagementSystem).IsAssignableFrom(x))
				.Where(x => !x.IsAbstract)
				.Where(x => x.IsClass)
				.Select(x =>
				{
					// コンストラクタ
					var constructor = x.GetConstructor(
						BindingFlags.Instance | BindingFlags.Public,
						null,
						CallingConventions.HasThis,
						new Type[0],
						new ParameterModifier[0]
						);

					// コンストラクタの引数
					var expressions = new Type[0]
						.Select(y => Expression.Parameter(y, null))
						.ToArray();

					// 青い波線が気になる
					return Expression.Lambda(Expression.New(constructor, expressions), expressions).Compile();
				})
				.Select(x => (Func<IDatabaseManagementSystem>)x)
				.ToDictionary(x => x().GetType());
		}

		private static IDatabaseManagementSystem Sbms { get; set; }

		public static void SetUp<T>() where T : IDatabaseManagementSystem
	    {
			Sbms = TypeFactory[typeof(T)]();
		} 

		public static ISelectRequest Select()
		{
			return Sbms.Select();
		}

		public static ISelectRequest Select(params string[] selectElements)
		{
			return Sbms.Select(selectElements);
		}

		public static IUpdateRequest Update()
		{
			return Sbms.Update();
		}

		public static IInsertRequest Insert()
		{
			return Sbms.Insert();
		}

		public static IDeleteRequest Delete()
		{
			return Sbms.Delete();
		}
	}
}
