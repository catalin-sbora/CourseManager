using CourseManager.ApplicationLogic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseManager.DataAccess
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly CourseManagerDbContext dbContext;
        public BaseRepository(CourseManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public T Add(T itemToAdd)
        {
            var entity = dbContext.Add<T>(itemToAdd);
            return entity.Entity;
        }

        public bool Delete(T itemToDelete)
        {
            dbContext.Remove<T>(itemToDelete);
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>()
                            .AsEnumerable();
        }

        public T Update(T itemToUpdate)
        {
            var entity = dbContext.Update<T>(itemToUpdate);
            return entity.Entity;
        }
    }
}
