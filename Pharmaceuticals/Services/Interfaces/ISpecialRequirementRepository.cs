using PharmaceuticalsApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PharmaceuticalsApp.Services
{
    public interface ISpecialRequirementRepository
    {
        void Add(SpecialRequirement specialRequirement);
        void Delete(SpecialRequirement specialRequirement);
        IEnumerable<SpecialRequirement> Get();
        SpecialRequirement Get(Expression<Func<SpecialRequirement, bool>> where);
        IEnumerable<SpecialRequirement> Get<T>(Expression<Func<SpecialRequirement, bool>> where, Expression<Func<SpecialRequirement, T>> orderBy, int take);
        IEnumerable<SpecialRequirement> GetMany(Expression<Func<SpecialRequirement, bool>> where);
        void Update(SpecialRequirement specialRequirement);
    }
}