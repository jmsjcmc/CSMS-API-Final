using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSMS_API.Models
{
    public class DispatchingPlacementRelation : IEntityTypeConfiguration<DispatchingPlacement>
    {
        public void Configure(EntityTypeBuilder<DispatchingPlacement> builder)
        {
            builder.HasOne(dp => dp.DispatchingDetail)
                .WithMany(dd => dd.DispatchingPlacement)
                .HasForeignKey(dp => dp.DispatchingDetailID);
            builder.HasOne(dp => dp.Pallet)
                .WithMany(p => p.DispatchingPlacement)
                .HasForeignKey(dp => dp.PalletID);
            builder.HasOne(dp => dp.PalletPosition)
                .WithMany(pp => pp.DispatchingPlacement)
                .HasForeignKey(dp => dp.PalletPositionID);
            builder.HasOne(dp => dp.ReceivingPlacement)
                .WithMany(rp => rp.DispatchingPlacement)
                .HasForeignKey(dp => dp.ReceivingPlacementID);
        }
    }
}