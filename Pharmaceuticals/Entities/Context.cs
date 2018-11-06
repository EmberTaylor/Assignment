using System.Data.Entity;

namespace PharmaceuticalsApp.Entities
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Pharmaceutical> Pharmaceuticals { get; set; }
        public virtual DbSet<SpecialRequirement> SpecialRequirements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmaceutical>()
                .Property(e => e.MedicationType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SpecialRequirement>()
                .HasMany(e => e.Pharmaceuticals)
                .WithRequired(e => e.SpecialRequirement)
                .WillCascadeOnDelete(false);
        }
    }
}
