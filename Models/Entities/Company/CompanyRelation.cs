using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSMS_API.Models
{
    public class CompanyRelation : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

        }
    }
    public class RepresentativeRelation : IEntityTypeConfiguration<Representative>
    {
        public void Configure(EntityTypeBuilder<Representative> builder)
        {
            builder.HasOne(r => r.Company)
            .WithMany(c => c.Representative)
            .HasForeignKey(r => r.CompanyID);
        }
    }
}