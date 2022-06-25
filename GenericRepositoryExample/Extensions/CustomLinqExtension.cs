using GenericRepositoryExample.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRepositoryExample.Extensions
{
    public static class CustomLinqExtension
	{
		public static IEnumerable<TSource> ContainsIgnoreCase<TSource>(this IEnumerable<TSource> query, string columnName, string propertyValue)
		{
			if (!string.IsNullOrEmpty(propertyValue))
			{
				return query.Where(m => { return m.GetColumnValue(columnName).IndexOf(propertyValue, StringComparison.OrdinalIgnoreCase) != -1; });
			}

			return query;
		}

		public static IEnumerable<TSource> StartsWith<TSource>(this IEnumerable<TSource> query, string columnName, string propertyValue)
		{
			if (!string.IsNullOrEmpty(propertyValue))
			{
				return query.Where(m => { return m.GetColumnValue(columnName).StartsWith(propertyValue); });
			}

			return query;
		}
	}
}
