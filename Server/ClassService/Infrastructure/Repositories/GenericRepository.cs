﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected /*readonly*/ ClassroomDbContext _context;
        protected /*readonly*/ DbSet<T> _dbSet;
        protected string _keyValueCache;
        protected readonly IMemoryCache _memoryCache;
        protected MemoryCacheEntryOptions _options;
        protected GenericRepository(ClassroomDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _memoryCache = memoryCache;
            _options = new MemoryCacheEntryOptions();
            _options.AbsoluteExpiration = DateTime.Now.AddMinutes(30);
            _options.SlidingExpiration = TimeSpan.FromMinutes(10);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<T>? Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var result = _dbSet.Where(predicate);
            if (result == null) { return null; }
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetById(string id)
        {
            var result = _dbSet.Find(id);
            if (result == null) { return null; }
            return result;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}