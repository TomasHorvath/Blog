using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasHorvath.BlogEngine.Core;

namespace TomasHorvath.BlogEngine.DAL
{
	public class EntityDataSession : IDataSession
	{

		private DbContext _dbContext;

		public EntityDataSession(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void Dispose()
		{
			_dbContext.Dispose();
		}

		public IDbSet<T> Set<T>() where T : class
		{
			return _dbContext.Set<T>();
		}

		/// <summary>
		/// Save all changes
		/// </summary>
		public void Commit()
		{
			try
			{
				_dbContext.SaveChanges();
			}
			catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
			{
				Exception raise = dbEx;
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						string message = string.Format("{0}:{1}",
								validationErrors.Entry.Entity.ToString(),
								validationError.ErrorMessage);
						// raise a new exception nesting
						// the current instance as InnerException
						raise = new InvalidOperationException(message, raise);
					}
				}
				throw raise;
			}
		}


		public void Entry<TEntity>(TEntity entity) where TEntity : class
		{
			_dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
		}

		public int SqlCommand(string sql, params object[] parameters)
		{
			return _dbContext.Database.ExecuteSqlCommand(sql, parameters);
		}

		public System.Data.Entity.Infrastructure.DbSqlQuery<TEntity> SqlQuery<TEntity>(string sql, params object[] parameters) where TEntity : class
		{
			return _dbContext.Set<TEntity>().SqlQuery(sql, parameters);
		}
	}
}
