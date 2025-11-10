using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSMS_API.Models
{
    public class DispatchingRelation : IEntityTypeConfiguration<Dispatching>
    {
        public void Configure(EntityTypeBuilder<Dispatching> builder)
        {

        }
    }
    public class DispatchingLogRelation : IEntityTypeConfiguration<DispatchingLog>
    {
        public void Configure(EntityTypeBuilder<DispatchingLog> builder)
        {
            builder.HasOne(dl => dl.Dispatching)
            .WithMany(d => d.DispatchingLog)
            .HasForeignKey(dl => dl.DispatchingID);
        }
    }
}