using PharmaceuticalsApp.Entities;
using PharmaceuticalsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SpecialRequirementsAppTests.Dummys
{
    internal class SpecialRequirementRepositoryDummy : ISpecialRequirementRepository
    {
        private ICollection<SpecialRequirement> context = new List<SpecialRequirement>()
            {
                new SpecialRequirement()
                {
                    SpecialRequirementID = 1,
                    ContainerSize = 100,
                    ContainerType ="Bottle",
                    StoreInFridge = false,
                    AvailableOverTheCounter = true
                }
            };

        public void Add(SpecialRequirement specialRequirement)
        {
            context.Add(specialRequirement);
        }

        public void Delete(SpecialRequirement specialRequirement)
        {
            var toRemove = context
                .Where(r => r.SpecialRequirementID == specialRequirement.SpecialRequirementID)
                .FirstOrDefault();
            context.Remove(toRemove);
        }

        public IEnumerable<SpecialRequirement> Get()
        {
            return context;
        }

        public SpecialRequirement Get(Expression<Func<SpecialRequirement, bool>> where)
        {
            return context.Where(where.Compile()).FirstOrDefault();
        }

        public IEnumerable<SpecialRequirement> Get<T>(Expression<Func<SpecialRequirement, bool>> where, Expression<Func<SpecialRequirement, T>> orderBy, int take)
        {
            return context.Where(where.Compile()).OrderBy(orderBy.Compile()).Take(take);
        }

        public IEnumerable<SpecialRequirement> GetMany(Expression<Func<SpecialRequirement, bool>> where)
        {
            return context.Where(where.Compile());
        }

        public void Update(SpecialRequirement specialRequirement)
        {
            Delete(specialRequirement);
            Add(specialRequirement);
        }
    }
}
