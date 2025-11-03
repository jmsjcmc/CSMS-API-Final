using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSMS_API.Models
{
    public class ReceivingRelation : IEntityTypeConfiguration<Receiving>
    {
        public void Configure(EntityTypeBuilder<Receiving> builder)
        {

        }
    }
    public class ReceivingLogRelation : IEntityTypeConfiguration<ReceivingLog>
    {
        public void Configure(EntityTypeBuilder<ReceivingLog> builder)
        {
            builder.HasOne(rl => rl.Receiving)
                .WithMany(r => r.ReceivingLog)
                .HasForeignKey(rl => rl.ReceivingID);
        }
    }
    public class ReceivingDetailRelation : IEntityTypeConfiguration<ReceivingDetail>
    {
        public void Configure(EntityTypeBuilder<ReceivingDetail> builder)
        {
            builder.HasOne(rd => rd.Receiving)
                .WithMany(r => r.ReceivingDetail)
                .HasForeignKey(rd => rd.ReceivingID);
            builder.HasOne(rd => rd.Product)
                .WithMany(p => p.ReceivingDetail)
                .HasForeignKey(rd => rd.ProductID);
        }
    }
    public class ReceivingDetailLogRelation : IEntityTypeConfiguration<ReceivingDetailLog>
    {
        public void Configure(EntityTypeBuilder<ReceivingDetailLog> builder)
        {
            builder.HasOne(rdl => rdl.ReceivingDetail)
                .WithMany(rd => rd.ReceivingDetailLog)
                .HasForeignKey(rdl => rdl.ReceivingDetailID);
        }
    }
}