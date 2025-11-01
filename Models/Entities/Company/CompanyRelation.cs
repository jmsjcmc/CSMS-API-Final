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
    public class CompanyLogRelation : IEntityTypeConfiguration<CompanyLog>
    {
        public void Configure(EntityTypeBuilder<CompanyLog> builder)
        {
            builder.HasOne(cl => cl.Company)
            .WithMany(c => c.CompanyLog)
            .HasForeignKey(cl => cl.CompanyID);
        }
    }
    public class RepresentativeLogRelation : IEntityTypeConfiguration<RepresentativeLog>
    {
        public void Configure(EntityTypeBuilder<RepresentativeLog> builder)
        {
            builder.HasOne(rl => rl.Representative)
            .WithMany(r => r.RepresentativeLog)
            .HasForeignKey(rl => rl.RepresentativeID);
        }
    }
}