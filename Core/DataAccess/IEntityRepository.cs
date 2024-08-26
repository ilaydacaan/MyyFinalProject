
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{

    public interface IEntityRepository<T> where T:class, IEntity, new()
        //T bir referans olmalı (class'dan ötürü)
        //ve
        //T ya IEntity olabilir ya da IEntity'den implemente olan bir şey oalbilir
    {   //T new'lenebilir olmalı bu sebeple IEntity new'lenemediği için <IEntitiy> yazılamaz
        //abstract olduğundan kabul edilmez Category Customer gibi IEntity implenet eden class'ları alabilir
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //filtre=null demek filtre vermemişse tüm datayı istiyor vermiş ise filtreleyip data verilmesini istiyor
        T Get(Expression<Func<T, bool>> filter); 
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
