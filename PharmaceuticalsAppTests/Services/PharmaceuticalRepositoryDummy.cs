using PharmaceuticalsApp.Entities;
using PharmaceuticalsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PharmaceuticalsAppTests
{
    internal class PharmaceuticalRepositoryDummy : IPharmaceuticalRepository
    {
        private ICollection<Pharmaceutical> context = new List<Pharmaceutical>()
            {
                new Pharmaceutical()
                {
                    PharmaceuticalID  = 1,
                    SpecialRequirementID = 1,
                    PharmaceuticalName = "Gaviscon",
                    Description = "Ant-Acid medication",
                    MedicationType = "O",
                    RecommendedDailyDose = 15,
                    SpecialRequirement = new SpecialRequirement()
                    {
                        SpecialRequirementID = 1,
                        ContainerSize = 100,
                        ContainerType ="Bottle",
                        StoreInFridge = false,
                        AvailableOverTheCounter = true
                    }
                }
            };

        public void Add(Pharmaceutical pharmaceutical)
        {
            context.Add(pharmaceutical);
        }

        public void Delete(Pharmaceutical pharmaceutical)
        {
            var toRemove = context
                .Where(r => r.PharmaceuticalID == pharmaceutical.PharmaceuticalID)
                .FirstOrDefault();
            context.Remove(toRemove);
        }

        public IEnumerable<Pharmaceutical> Get()
        {
            return context;
        }

        public Pharmaceutical Get(Expression<Func<Pharmaceutical, bool>> where)
        {
            return context.Where(where.Compile()).FirstOrDefault();
        }

        public IEnumerable<Pharmaceutical> Get<T>(Expression<Func<Pharmaceutical, bool>> where, Expression<Func<Pharmaceutical, T>> orderBy, int take)
        {
            return context.Where(where.Compile()).OrderBy(orderBy.Compile()).Take(take);
        }

        public IEnumerable<Pharmaceutical> GetMany(Expression<Func<Pharmaceutical, bool>> where)
        {
            return context.Where(where.Compile());
        }

        public void Update(Pharmaceutical pharmaceutical)
        {
            Delete(pharmaceutical);
            Add(pharmaceutical);
        }
    }
}
