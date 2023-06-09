using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SQLLite.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;

        public DbSet<T> Set { get; private set; }

        public Repository(CostsDbContext db)
        {
            _db = db;
            var set = _db.Set<T>();
            set.Load();

            Set = set;
        }

        public async Task Create(T item)
        {
            Set.Add(item);
            _db.SaveChangesAsync();
        }

        public async Task Delete(T item)
        {
            Set.Remove(item);
            _db.SaveChangesAsync();
        }

        public T Get(int id)
        {
            return Set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Set;
        }

        public async Task Update(T item)
        {
            Set.Update(item);
            _db.SaveChangesAsync();
        }
    }
}
