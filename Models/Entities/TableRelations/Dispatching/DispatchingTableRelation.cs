using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSMS_API.Models
{
    public class DispatchingPlacementRelation : IEntityTypeConfiguration<DispatchingPlacement>
    {
        public void Configure(EntityTypeBuilder<DispatchingPlacement> builder)
        {
            builder.HasOne(dp => dp.Dispatching)
                .WithMany(dd => dd.DispatchingPlacement)
                .HasForeignKey(dp => dp.DispatchingID);
            builder.HasOne(dp => dp.Pallet)
                .WithMany(p => p.DispatchingPlacement)
                .HasForeignKey(dp => dp.PalletID);
            builder.HasOne(dp => dp.PalletPosition)
                .WithMany(pp => pp.DispatchingPlacement)
                .HasForeignKey(dp => dp.PalletPositionID);
            builder.HasOne(dp => dp.ReceivingPlacement)
                .WithMany(rp => rp.DispatchingPlacement)
                .HasForeignKey(dp => dp.ReceivingPlacementID);

            builder.HasOne(dp => dp.Approver)
                .WithMany()
                .HasForeignKey(dp => dp.ApproverID);
            builder.HasOne(dp => dp.Creator)
                .WithMany()
                .HasForeignKey(dp => dp.CreatorID);
        }
    }
    public class DispatchingPlacementLogRelation : IEntityTypeConfiguration<DispatchingPlacementLog>
    {
        public void Configure(EntityTypeBuilder<DispatchingPlacementLog> builder)
        {
            builder.HasOne(dpl => dpl.DispatchingPlacement)
                .WithMany(dp => dp.DispatchingPlacementLog)
                .HasForeignKey(dpl => dpl.DispatchingPlacementID);
            builder.HasOne(dpl => dpl.Updater)
                .WithMany()
                .HasForeignKey(dpl => dpl.UpdaterID);
        }
    }
}