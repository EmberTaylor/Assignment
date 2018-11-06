using PharmaceuticalsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PharmaceuticalsApp.Services
{
    public class PharmaceuticalRepository : BaseRepository, IPharmaceuticalRepository
    {
        public PharmaceuticalRepository(Context context)
            : base(context)
        {
        }

        public void Delete(Pharmaceutical pharmaceutical)
        {
            _context.Pharmaceuticals.Remove(pharmaceutical);
        }

        public Pharmaceutical Get(Expression<Func<Pharmaceutical, bool>> where)
        {
            return _context.Pharmaceuticals.FirstOrDefault(where);
        }

        public IEnumerable<Pharmaceutical> Get()
        {
            return _context.Pharmaceuticals.ToList();    
        }

        public IEnumerable<Pharmaceutical> GetMany(Expression<Func<Pharmaceutical, bool>> where)
        {
            return _context.Pharmaceuticals.Where(where);
        }

        public IEnumerable<Pharmaceutical> Get<T>(Expression<Func<Pharmaceutical, bool>> where, Expression<Func<Pharmaceutical, T>> orderBy, int take)
        {
            return _context.Pharmaceuticals.Where(where).OrderBy(orderBy).Take(take);
        }

        public void Update(Pharmaceutical pharmaceutical)
        {
            // no code in this implementation
        }

        public void Add(Pharmaceutical pharmaceutical)
        {
            _context.Pharmaceuticals.Add(pharmaceutical);
        }
    }
}