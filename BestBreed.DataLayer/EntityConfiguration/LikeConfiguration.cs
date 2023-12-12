using BestBreed.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestBreed.DataLayer.EntityConfiguration
{
    public class LikeConfiguration : BaseEntitiyConfiguration<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            base.Configure(builder);

            builder.HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId);

            builder.HasOne(l => l.Cat)
                .WithMany(cat => cat.Likes)
                .HasForeignKey(l => l.CatId);
        }
    }
}
