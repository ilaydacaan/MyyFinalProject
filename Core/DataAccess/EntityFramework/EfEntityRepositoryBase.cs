using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
                                                 //TContext ise entity nesnelerinin hangi
                                                 //contextten çekileceğini belirten parametre olarak belirlendi.
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()

    {

        public void Add(TEntity entity)
        {   //belleği hızlıca temizleme IDispoasble implementation
            //using bittiği an temizleniyor

            using (TContext context = new TContext())
            {  
                //Entry ilgili nesneyi işaretler ve izler
                var addedEntity = context.Entry(entity);
                //state işaretli nesnenin durumunu kontorl eder
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {   //null ise birinci değilse ikinci çalışır
                return filter == null
                       ? context.Set<TEntity>().ToList()
                       : context.Set<TEntity>().Where(filter).ToList();
            }
        }

    }
}
