using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLogBook.Abstracrions;

namespace NewLogBook.Repositories
{
    public class DbRepository<T> : IDbRepository<T> where T : class, IDbEntity
    {
        DbContext _context;

        public DbRepository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<T> AllItems => _context.Set<T>();

        public DbContext Context => _context;

        public async Task<bool> AddItemAsync(T item)
        {
            await _context.Set<T>().AddAsync(item);
            return await SaveChangesAsync() > 0;
        }

        public async Task<int> AddItemsAsync(IEnumerable<T> items)
        {
            await _context.Set<T>().AddRangeAsync(items);
            return await SaveChangesAsync();
        }

        public async Task<bool> ChangeItemAsync(T item)
        {
            T changed = await GetItemAsync(item.Id);

            if (changed == null)
            {
                return false;
            }
            changed = item;
            return await SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteItemAsync(int? id)
        {
            T item = await GetItemAsync(id);
            if (item == null)
            {
                return false;
            }
            _context.Set<T>().Remove(item);
            return await SaveChangesAsync() > 0;
        }

        public async Task<T> GetItemAsync(int? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
#pragma warning disable 0168
            catch (Exception e)
#pragma warning disable 0168
            {
                return -1;
            }
        }

        public async Task<List<T>> ToListAsync()
        {
            return await AllItems.ToAsyncEnumerable<T>().ToList();
        }

        public async Task<bool> UpdateItem(T item)
        {
            _context.Set<T>().Update(item);
            return await SaveChangesAsync() > 0;
        }
    }
}