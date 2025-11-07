using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSMS_API.Models
{
    public class ReceivingProductRelation : IEntityTypeConfiguration<ReceivingProduct>
    {
        public void Configure(EntityTypeBuilder<ReceivingProduct> builder)
        {
            builder.HasOne(rp => rp.Receiving)
                .WithMany(r => r.ReceivingProduct)
                .HasForeignKey(rp => rp.ReceivingID);
            builder.HasOne(rp => rp.Product)
                .WithMany(p => p.ReceivingProduct)
                .HasForeignKey(rp => rp.ProductID);
        }
    }
    public class ReceivingProductLogRelation : IEntityTypeConfiguration<ReceivingProductLog>
    {
        public void Configure(EntityTypeBuilder<ReceivingProductLog> builder)
        {
            builder.HasOne(rpl => rpl.ReceivingProduct)
                .WithMany(rp => rp.ReceivingProductLog)
                .HasForeignKey(rpl => rpl.ReceivingProductID);
        }
    }
    public class ReceivingPlacementRelation : IEntityTypeConfiguration<ReceivingPlacement>
    {
        public void Configure(EntityTypeBuilder<ReceivingPlacement> builder)
        {
            builder.HasOne(rp => rp.ReceivingProduct)
                .WithMany(rp => rp.ReceivingPlacement)
                .HasForeignKey(rp => rp.ReceivingProductID);
            builder.HasOne(rp => rp.ReceivingDetail)
                .WithMany(rd => rd.ReceivingPlacement)
                .HasForeignKey(rp => rp.ReceivingDetailID);
            builder.HasOne(rp => rp.Pallet)
                .WithMany(p => p.ReceivingPlacement)
                .HasForeignKey(rp => rp.PalletID);
            builder.HasOne(rp => rp.PalletPosition)
                .WithMany(pp => pp.ReceivingPlacement)
                .HasForeignKey(rp => rp.PalletPositionID);
        }
    }
    public class ReceivingPlacementLogRelation : IEntityTypeConfiguration<ReceivingPlacementLog>
    {
        public void Configure(EntityTypeBuilder<ReceivingPlacementLog> builder)
        {
            builder.HasOne(rpl => rpl.ReceivingPlacement)
                .WithMany(rp => rp.ReceivingPlacementLog)
                .HasForeignKey(rpl => rpl.ReceivingPlacementID);
        }
    }
}