using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EH.Assessment.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly EHDBContext _ehDBContext;

        public Repository(EHDBContext ehDBContext)
        {
            _ehDBContext = ehDBContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _ehDBContext.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            _ehDBContext.Add(entity);
            _ehDBContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _ehDBContext.Update(entity);
            _ehDBContext.SaveChanges();
            return entity;
        }
    }
}
