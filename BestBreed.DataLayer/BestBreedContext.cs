using BestBreed.DataLayer.Entities;
using BestBreed.DataLayer.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace BestBreed.DataLayer
{
    public class BestBreedContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<SurveyResult> SurveyResults { get; set; }

        public BestBreedContext(DbContextOptions<BestBreedContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new CatConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new SurveyResultConfiguration());
        }
    }
}
