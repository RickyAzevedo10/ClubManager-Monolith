﻿using Microsoft.EntityFrameworkCore;
using ClubManager.Domain.Entities;
using ClubManager.Domain.Interfaces.Repositories;

namespace ClubManager.Infra.Persistence
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetEntity()
        {
            return _dbSet.AsQueryable();
        }

        public virtual async Task<T> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.DateOfCreation = DateTime.Now;
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            entity.DateOfModification = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task DeleteAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            _dbSet.RemoveRange(entities);
        }
    }
}
