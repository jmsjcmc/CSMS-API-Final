using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSMS_API.Models
{
    public class ProductRelation : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Product)
                .HasForeignKey(p => p.CategoryID);
            builder.HasOne(p => p.Company)
                .WithMany(c => c.Product)
                .HasForeignKey(p => p.CompanyID);
        }
    }
    public class ProductLogRelation : IEntityTypeConfiguration<ProductLog>
    {
        public void Configure(EntityTypeBuilder<ProductLog> builder)
        {
            builder.HasOne(pl => pl.Product)
                .WithMany(p => p.ProductLog)
                .HasForeignKey(pl => pl.ProductID);
        }
    }
    public class CategoryRelation : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

        }
    }
    public class CategoryLogRelation : IEntityTypeConfiguration<CategoryLog>
    {
        public void Configure(EntityTypeBuilder<CategoryLog> builder)
        {
            builder.HasOne(cl => cl.Category)
                .WithMany(c => c.CategoryLog)
                .HasForeignKey(cl => cl.CategoryID);
        }
    }
}