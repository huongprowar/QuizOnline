using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN231_Project_QuizOnline_API.Models;
using System.Linq.Expressions;

namespace Repositories.Base
{
	public class BaseRepository<T> where T : class 
	{		
		private readonly QuizOnlineContext _context;
		private readonly DbSet<T> _dbSet;
		
		public BaseRepository(QuizOnlineContext context) 
		{ 
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public async Task<T> FindAsync(int id)
		{
			var entity = await _dbSet.FindAsync(id);
			return entity;
		}		
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}
		private T TrimData(T entity)
		{
			var stringProperties = entity.GetType().GetProperties()
				.Where(p => p.PropertyType == typeof(string) && p.CanWrite);

			foreach (var stringProperty in stringProperties)
			{
				string currentValue = (string)stringProperty.GetValue(entity, null)!;
				if (currentValue != null)
				{
					stringProperty.SetValue(entity, currentValue.Trim(), null);
				}

			}

			return entity;
		}
		public async Task<bool> ExitsByIdAsync(int id)
		{
			var entity = await _dbSet.FindAsync(id);
			if (entity != null)
			{
				_context.Entry(entity).State = EntityState.Detached;
			}

			return entity != null;
		}

		public void Add(T entity)
		{
			entity = TrimData(entity);
			_dbSet.Add(entity);
		}

		public void AddRange(IEnumerable<T> entities)
		{
			var listEntity = entities.ToList();
			for (var i = 0; i < listEntity.Count(); i++)
			{
				var entity = listEntity[i];
				listEntity[i] = TrimData(entity);
			}

			_dbSet.AddRange(listEntity);
		}

		public void Update(T entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			entity = TrimData(entity);
			_dbSet.Update(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_dbSet.RemoveRange(entities);
		}
	}
}
