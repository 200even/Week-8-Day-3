namespace Media_Manager
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class MovieModel : DbContext
    {
        public MovieModel()
            : base("name=MovieModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AspNetRoles>()
            //    .HasMany(e => e.AspNetUsers)
            //    .WithMany(e => e.AspNetRoles)
            //    .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            //modelBuilder.Entity<AspNetUsers>()
            //    .HasMany(e => e.AspNetUserClaims)
            //    .WithRequired(e => e.AspNetUsers)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<AspNetUsers>()
            //    .HasMany(e => e.AspNetUserLogins)
            //    .WithRequired(e => e.AspNetUsers)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<AspNetUsers>()
            //    .HasMany(e => e.Pins)
            //    .WithOptional(e => e.AspNetUsers)
            //    .HasForeignKey(e => e.WhoPinned_Id);
        }
    }
}
