using PharmaceuticalsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PharmaceuticalsApp.Services
{
    public class SpecialRequirementRepository : BaseRepository, ISpecialRequirementRepository
    {
        public SpecialRequirementRepository(Context context)
            : base(context)
        {
        }

        public void Delete(SpecialRequirement specialRequirement)
        {
            _context.SpecialRequirements.Remove(specialRequirement);
        }

        public SpecialRequirement Get(Expression<Func<SpecialRequirement, bool>> where)
        {
            return _context.SpecialRequirements.FirstOrDefault(where);
        }

        public IEnumerable<SpecialRequirement> Get()
        {
            return _context.SpecialRequirements;
        }

        public IEnumerable<SpecialRequirement> GetMany(Expression<Func<SpecialRequirement, bool>> where)
        {
            return _context.SpecialRequirements.Where(where);
        }

        public IEnumerable<SpecialRequirement> Get<T>(Expression<Func<SpecialRequirement, bool>> where, Expression<Func<SpecialRequirement, T>> orderBy, int take)
        {
            return _context.SpecialRequirements.Where(where).OrderBy(orderBy).Take(take);
        }

        public void Update(SpecialRequirement specialRequirement)
        {
            // no code in this implementation
        }

        public void Add(SpecialRequirement specialRequirement)
        {
            _context.SpecialRequirements.Add(specialRequirement);
        }
    }
}