namespace dept
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class deptContext : DbContext
    {
        public deptContext()
            : base("name=deptContext")
        {
        }

        public virtual DbSet<department> departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<department>().MapToStoredProcedures();
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<department>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());
        }
    }
}
