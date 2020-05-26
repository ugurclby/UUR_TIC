using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;
using Uur.Core.Entities;

namespace Uur.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
        //Where generic constraint demek. gelen T objesi class olmalı,IEntity'den türemiş olmalı,new'lenebilir bir obje olmalı.
    {
        T Get(Expression<Func<T,bool>> filter=null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
