namespace ThinController.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DemoDbContext : DbContext
    {
        public DemoDbContext()
            : base("name=DemoDbContext")
        {
        }

        public virtual DbSet<FAQ> FAQs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FAQ>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<FAQ>()
                .Property(e => e.Answer)
                .IsUnicode(false);
        }
    }
}
