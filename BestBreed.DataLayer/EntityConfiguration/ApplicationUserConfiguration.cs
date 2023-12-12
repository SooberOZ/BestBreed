using BestBreed.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestBreed.DataLayer.EntityConfiguration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(u => u.FirstName)
                .HasMaxLength(15);

            builder.Property(u => u.LastName)
                .HasMaxLength(25);

            builder.HasMany(u => u.SurveyResults)
                .WithOne(sr => sr.User)
                .HasForeignKey(sr => sr.UserId);

            builder.HasMany(u => u.Likes)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId);

            builder.HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
