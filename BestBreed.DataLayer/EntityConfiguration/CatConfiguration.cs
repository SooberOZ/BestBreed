using BestBreed.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestBreed.DataLayer.EntityConfiguration
{
    public class CatConfiguration : BaseEntitiyConfiguration<Cat>
    {
        public override void Configure(EntityTypeBuilder<Cat> builder)
        {
            base.Configure(builder);

            builder.HasMany(cat => cat.Likes)
                .WithOne(l => l.Cat)
                .HasForeignKey(l => l.CatId);

            builder.HasMany(cat => cat.Comments)
                .WithOne(c => c.Cat)
                .HasForeignKey(c => c.CatId);

            builder.HasMany(cat => cat.SurveyResults)
                .WithOne(sr => sr.Cat)
                .HasForeignKey(sr => sr.CatId);
        }
    }
}
