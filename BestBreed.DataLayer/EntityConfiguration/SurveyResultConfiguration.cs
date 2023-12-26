using BestBreed.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

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

            builder.Property(sr => sr.QuestionAnswers)
           .HasConversion(
               answers => JsonConvert.SerializeObject(answers),
               json => JsonConvert.DeserializeObject<Dictionary<int, int>>(json)
                );
        }
    }
}