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
}