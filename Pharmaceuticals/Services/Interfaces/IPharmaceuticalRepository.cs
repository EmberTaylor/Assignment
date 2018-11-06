using PharmaceuticalsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PharmaceuticalsApp.Services
{
    public interface IPharmaceuticalRepository
    {
        void Add(Pharmaceutical pharmaceutical);
        void Delete(Pharmaceutical pharmaceutical);
        IEnumerable<Pharmaceutical> Get();
        Pharmaceutical Get(Expression<Func<Pharmaceutical, bool>> where);
        IEnumerable<Pharmaceutical> Get<T>(Expression<Func<Pharmaceutical, bool>> where, Expression<Func<Pharmaceutical, T>> orderBy, int take);
        IEnumerable<Pharmaceutical> GetMany(Expression<Func<Pharmaceutical, bool>> where);
        void Update(Pharmaceutical pharmaceutical);
    }
}