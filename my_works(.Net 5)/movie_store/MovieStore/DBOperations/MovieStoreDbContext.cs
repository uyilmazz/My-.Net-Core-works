using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.DBOperations
{

    public class MovieStoreDbContext : DbContext,IMovieStoreDBContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options) { }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Actor_Film> Actor_Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Film>()
            .HasOne<Actor>(a => a.Actor)
            .WithMany(af => af.Actor_Film)
            .HasForeignKey(af => af.Id);

            modelBuilder.Entity<Actor_Film>()
            .HasOne<Film>(f => f.Film)
            .WithMany(af => af.Actor_Film)
            .HasForeignKey(fa => fa.Id);
        }

        public override int SaveChanges(){
            return base.SaveChanges();
        }
    }
}