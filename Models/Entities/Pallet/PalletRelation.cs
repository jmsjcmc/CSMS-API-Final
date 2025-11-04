using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSMS_API.Models
{
    public class PalletRelation : IEntityTypeConfiguration<Pallet>
    {
        public void Configure(EntityTypeBuilder<Pallet> builder)
        {

        }
    }
    public class PalletLogRelation : IEntityTypeConfiguration<PalletLog>
    {
        public void Configure(EntityTypeBuilder<PalletLog> builder)
        {
            builder.HasOne(pl => pl.Pallet)
                .WithMany(p => p.PalletLog)
                .HasForeignKey(pl => pl.PalletID);
        }
    }
    public class PalletPositionRelation : IEntityTypeConfiguration<PalletPosition>
    {
        public void Configure(EntityTypeBuilder<PalletPosition> builder)
        {
            builder.HasOne(pp => pp.ColdStorage)
                .WithMany(cs => cs.PalletPosition)
                .HasForeignKey(pp => pp.ColdStorageID);
        }
    }
    public class PalletPositionLogRelation : IEntityTypeConfiguration<PalletPositionLog>
    {
        public void Configure(EntityTypeBuilder<PalletPositionLog> builder)
        {
            builder.HasOne(ppl => ppl.PalletPosition)
                .WithMany(pp => pp.PalletPositionLog)
                .HasForeignKey(ppl => ppl.PalletPositionID);
        }
    }
    public class ColdStorageRelation : IEntityTypeConfiguration<ColdStorage>
    {
        public void Configure(EntityTypeBuilder<ColdStorage> builder)
        {

        }
    }
    public class ColdStorageLogRelation : IEntityTypeConfiguration<ColdStorageLog>
    {
        public void Configure(EntityTypeBuilder<ColdStorageLog> builder)
        {
            builder.HasOne(csl => csl.ColdStorage)
                .WithMany(cs => cs.ColdStorageLog)
                .HasForeignKey(csl => csl.ColdStorageID);
        }
    }
}