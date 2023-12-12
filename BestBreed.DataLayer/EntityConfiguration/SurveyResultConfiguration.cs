using BestBreed.DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestBreed.DataLayer.EntityConfiguration
{
    public class SurveyResultConfiguration : BaseEntitiyConfiguration<SurveyResult>
    {
        public override void Configure(EntityTypeBuilder<SurveyResult> builder)
        {
            base.Configure(builder);

            builder.HasOne(sr => sr.User)
                .WithMany(u => u.SurveyResults)
                .HasForeignKey(sr => sr.UserId);

            builder.HasOne(sr => sr.Cat)
                .WithMany(cat => cat.SurveyResults)
                .HasForeignKey(sr => sr.CatId);
        }
    }
}