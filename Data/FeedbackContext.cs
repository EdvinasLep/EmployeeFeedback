using Microsoft.EntityFrameworkCore;
using EmployeeFeedback.Models;

namespace EmployeeFeedback.Data
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Department).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Text).HasMaxLength(1000);
                entity.Property(e => e.Rating).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                
                entity.HasIndex(e => e.Department);
                entity.HasIndex(e => e.CreatedAt);
            });
        }
    }
} 