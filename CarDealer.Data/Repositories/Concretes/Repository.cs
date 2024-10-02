using CarDealer.Core.Entities;
using CarDealer.Data.Context;
using CarDealer.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext appDbContext;

        public Repository(AppDbContext appDbContext) {
            this.appDbContext = appDbContext;
        }

        private DbSet<T> Table { get => appDbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await appDbContext.SaveChangesAsync();

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }

        public async Task DeleteAsync(int id)
        {
            var value = await GetByIdAsync(id);
            appDbContext.Remove(value);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var property in includeProperties)
                    query = query.Include(property);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var property in includeProperties)
                    query = query.Include(property);
            return await query.SingleOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            appDbContext.Update(entity);
            await appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
