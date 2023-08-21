using CaseDAL.Abstract;
using CaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDAL.Concrete.MySQL
{

    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext context;
        public GenericRepository(DbContext ctx)
        {
            context = ctx;
        }
        public bool Create(TEntity entity)
        {
           
            entity.CreatedOn = DateTime.Now;
            
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return true;
        }

        public void Delete(TEntity entity)
        {
            
            entity.IsDeleted = true;
            entity.ModifiedOn = DateTime.UtcNow;
            context.Set<TEntity>().Update(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return context.Set<TEntity>().Where(i=>!i.IsDeleted ).ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual void Update(TEntity entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            context.Set<TEntity>().Update(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }

}
