using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Core
{
	public interface IDataSession : IDisposable
	{
		IDbSet<T> Set<T>() where T : class;

		void Entry<TEntity>(TEntity entity) where TEntity : class;

		System.Data.Entity.Infrastructure.DbSqlQuery<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters) where TEntity : class;

		void Commit();

		int SqlCommand(string sql, params object[] parameters);
	}
}
