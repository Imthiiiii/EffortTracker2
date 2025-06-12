using EffortTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace EffortTracker.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Associates> Associates { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Timesheets> Timesheets { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Timesheets relationships
            modelBuilder.Entity<Timesheets>()
                .HasOne<Associates>()
                .WithMany()
                .HasForeignKey(t => t.associate_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Timesheets>()
                .HasOne<Applications>()
                .WithMany()
                .HasForeignKey(t => t.application_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Timesheets>()
                .HasOne<Tasks>()
                .WithMany()
                .HasForeignKey(t => t.task_id)
                .OnDelete(DeleteBehavior.Restrict);

            // Users relationship with Associates
            modelBuilder.Entity<Users>()
                .HasOne<Associates>()
                .WithMany()
                .HasForeignKey(u => u.associate_id)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Tasks>()
             .Property(t => t.task_id)
             .ValueGeneratedNever();

            modelBuilder.Entity<Applications>()
               .Property(a => a.application_id)
               .ValueGeneratedNever();

        }
    }
}
