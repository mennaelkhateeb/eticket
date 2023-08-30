using Microsoft.EntityFrameworkCore;
using Tickets.Models;

namespace Ticket.Models
{

    public class myDbContext : DbContext
        {

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server = .; Database =TicketsDB; Trusted_Connection = True;");

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Actor_Movie>().HasKey(am => new
                {
                    am.ActorId,
                    am.MovieId
                });

                modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);
                modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);
                //modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();
            base.OnModelCreating(modelBuilder);
            }

            public DbSet<Actor> Actors { get; set; }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Actor_Movie> Actor_Movies { get; set; }
            public DbSet<Cinema> Cinemas { get; set; }
            public DbSet<Producer> Producers { get; set; }

        //Account
            public DbSet<User> Users { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderItem> OrderItems { get; set; }
          

    }
    
}
