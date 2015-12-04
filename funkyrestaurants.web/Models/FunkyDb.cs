namespace funkyrestaurants.web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FunkyDb : DbContext
    {
        public FunkyDb()
            : base("name=FunkyDb")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Funkyrestaurant> Funkyrestaurants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funkyrestaurant>()
                .Property(e => e.Adress)
                .IsFixedLength();
        }
    }
}
