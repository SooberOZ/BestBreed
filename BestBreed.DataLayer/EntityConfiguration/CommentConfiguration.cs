using BestBreed.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestBreed.DataLayer.EntityConfiguration
{
    public class CommentConfiguration : BaseEntitiyConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            builder.HasOne(c => c.Cat)
                .WithMany(cat => cat.Comments)
                .HasForeignKey(c => c.CatId);
        }
    }
}
