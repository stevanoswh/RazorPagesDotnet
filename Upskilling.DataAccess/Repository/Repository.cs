﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upskilling.DataAccess.Data;
using Upskilling.DataAccess.Repository.IRepository;

namespace Upskilling.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();
		}
		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;

			return query.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}
	}
}
