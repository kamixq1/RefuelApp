using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RefuelApp
{
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel1")
        {
        }

        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Refuels> Refuels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logins>()
                .Property(e => e.Passwords)
                .IsUnicode(false);

            modelBuilder.Entity<Refuels>()
                .Property(e => e.Odometer)
                .IsUnicode(false);
        }
    }
}
