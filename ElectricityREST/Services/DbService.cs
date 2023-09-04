using ElectricityLibrary.model;
using ElectricityREST.InterFaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ElectricityREST.Services
{
    public class DbService<T> : IDbService<T> where T : class
    {
        public  async Task AddObjectAsync(T obj)
        {
            using(var context = new ELDBContext())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
            
        }

        public async Task DeleteObjectAsync(T obj)
        {
            using(var context = new ELDBContext())
            {
                context.Set<T>().Remove(obj);
                context.SaveChanges();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using(var context = new ELDBContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<T> GetObjectByIdAsync(int id)
        {
            using (var context = new ELDBContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }
       
    }
}
