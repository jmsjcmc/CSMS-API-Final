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
    public class DispatchingDetailRelation : IEntityTypeConfiguration<DispatchingDetail>
    {
        public void Configure(EntityTypeBuilder<DispatchingDetail> builder)
        {
            builder.HasOne(dd => dd.ReceivingPlacement)
            .WithMany(rp => rp.DispatchingDetail)
            .HasForeignKey(dd => dd.ReceivingPlacementID);
        }
    }
    public class DispatchingDetailLogRelation : IEntityTypeConfiguration<DispatchingDetailLog>
    {
        public void Configure(EntityTypeBuilder<DispatchingDetailLog> builder)
        {
            builder.HasOne(ddl => ddl.DispatchingDetail)
            .WithMany(dd => dd.DispatchingDetailLog)
            .HasForeignKey(ddl => ddl.DispatchingDetailID);
        }
    }
}