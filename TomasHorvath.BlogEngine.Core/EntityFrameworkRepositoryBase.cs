using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TomasHorvath.BlogEngine.Core
{
	public abstract class EntityFrameworkRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
	{
		protected IDataSession _dataSession
		{
			get; private set;
		}

		public EntityFrameworkRepositoryBase(IDataSession session)
		{
			if (session == null)
			{
				throw new ArgumentNullException("context");
			}
			_dataSession = session;

		}

		public virtual void Delete(IEnumerable<TKey> ids)
		{
			foreach (TKey key in ids)
			{
				Delete(GetById(key));
			}
		}

		public virtual void Delete(IEnumerable<TEntity> entities)
		{
			foreach (TEntity item in entities)
			{
				Delete(item);
			}
		}

		public virtual void Delete(TEntity entity)
		{
			_dataSession.Set<TEntity>().Remove(entity);
		}

		public void Delete(TKey id)
		{
			Delete(GetById(id));
		}

		public TEntity GetById(TKey id, params Expression<Func<TEntity, object>>[] includes)
		{
			IQueryable<TEntity> set = _dataSession.Set<TEntity>();
			foreach (var include in includes)
			{
				set = set.Include(include);
			}
			return set.SingleOrDefault(e => e.Id.Equals(id));
		}

		public virtual IList<TEntity> GetByIds(IEnumerable<TKey> ids, params Expression<Func<TEntity, object>>[] includes)
		{
			List<TEntity> entities = new List<TEntity>();
			foreach (TKey key in ids)
			{
				entities.Add(GetById(key, includes));
			}

			return entities;
		}

		public virtual TEntity InitializeNew()
		{
			throw new NotImplementedException();
		}

		public virtual void Insert(IEnumerable<TEntity> entities)
		{
			foreach (TEntity item in entities)
			{
				Insert(item);
			}
		}

		public virtual void Insert(TEntity entity)
		{
			_dataSession.Set<TEntity>().Add(entity);

		}

		public virtual void Update(IEnumerable<TEntity> entities)
		{
			foreach (TEntity item in entities)
			{
				Update(item);
			}
		}

		public virtual void Update(TEntity entity)
		{
			_dataSession.Entry<TEntity>(entity);
		}

		public virtual IList<TEntity> GetByKey(TKey key)
		{
			List<TEntity> result = new List<TEntity>();
			return result;
		}

		public virtual IQueryable<TEntity> TableNoTracking
		{
			get
			{
				return _dataSession.Set<TEntity>().AsNoTracking();
			}
		}

		public virtual IQueryable<TEntity> Table
		{
			get
			{
				return _dataSession.Set<TEntity>();
			}
		}
	}
}
