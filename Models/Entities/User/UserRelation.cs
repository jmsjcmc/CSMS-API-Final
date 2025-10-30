using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSMS_API.Models
{
    public class UserRelation : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(u => u.BusinessUnit)
                .WithMany(bu => bu.User)
                .HasForeignKey(u => u.BusinessUnitID);

            builder.HasOne(u => u.Position)
                .WithMany(p => p.User)
                .HasForeignKey(u => u.PositionID);
        }
    }
    public class RoleRelation : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
        }
    }
    public class BusinessUnitRelation : IEntityTypeConfiguration<BusinessUnit>
    {
        public void Configure(EntityTypeBuilder<BusinessUnit> builder)
        {

        }
    }
    public class DepartmentRelation : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

        }
    }
    public class PositionRelation : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasOne(p => p.Department)
                .WithMany(d => d.Position)
                .HasForeignKey(p => p.DepartmentID);
        }
    }
    public class UserRoleRelation : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRole)
                .HasForeignKey(ur => ur.UserID);
            builder.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRole)
                .HasForeignKey(ur => ur.RoleID);
        }
    }
    public class UserLogRelation : IEntityTypeConfiguration<UserLog>
    {
        public void Configure(EntityTypeBuilder<UserLog> builder)
        {
            builder.HasOne(ul => ul.User)
                .WithMany(u => u.UserLog)
                .HasForeignKey(ul => ul.UserID);
        }
    }
    public class RoleLogRelation : IEntityTypeConfiguration<RoleLog>
    {
        public void Configure(EntityTypeBuilder<RoleLog> builder)
        {
            builder.HasOne(rl => rl.Role)
                .WithMany(r => r.RoleLog)
                .HasForeignKey(rl => rl.RoleID);
        }
    }
    public class BusinessUnitLogRelation : IEntityTypeConfiguration<BusinessUnitLog>
    {
        public void Configure(EntityTypeBuilder<BusinessUnitLog> builder)
        {
            builder.HasOne(bul => bul.BusinessUnit)
                .WithMany(bu => bu.BusinessUnitLog)
                .HasForeignKey(bul => bul.BusinessUnitID);
        }
    }
    public class DepartmentLogRelation : IEntityTypeConfiguration<DepartmentLog>
    {
        public void Configure(EntityTypeBuilder<DepartmentLog> builder)
        {
            builder.HasOne(dl => dl.Department)
                .WithMany(d => d.DepartmentLog)
                .HasForeignKey(dl => dl.DepartmentID);
        }
    }
    public class PositionLogRelation : IEntityTypeConfiguration<PositionLog>
    {
        public void Configure(EntityTypeBuilder<PositionLog> builder)
        {
            builder.HasOne(pl => pl.Position)
                .WithMany(p => p.PositionLog)
                .HasForeignKey(pl => pl.PositionID);
        }
    }
}
