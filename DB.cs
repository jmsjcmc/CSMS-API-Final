using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }
        public DbSet<BusinessUnit> BusinessUnit { get; set; }
        public DbSet<BusinessUnitLog> BusinessUnitLog { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserLog> UserLog { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleLog> RoleLog { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<DepartmentLog> DepartmentLog { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<PositionLog> PositionLog { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyLog> CompanyLog { get; set; }
        public DbSet<Representative> Representative { get; set; }
        public DbSet<RepresentativeLog> RepresentativeLog { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductLog> ProductLog { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryLog> CategoryLog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Ignore(u => u.Creator);
            modelBuilder.Entity<UserLog>().Ignore(ul => ul.Updater);

            modelBuilder.Entity<Role>().Ignore(r => r.Creator);
            modelBuilder.Entity<RoleLog>().Ignore(rl => rl.Updater);

            modelBuilder.Entity<BusinessUnit>().Ignore(bu => bu.Creator);
            modelBuilder.Entity<BusinessUnitLog>().Ignore(bul => bul.Updater);

            modelBuilder.Entity<Department>().Ignore(d => d.Creator);

            modelBuilder.Entity<Position>().Ignore(p => p.Creator);

            modelBuilder.Entity<Company>().Ignore(c => c.Creator);

            modelBuilder.Entity<Representative>().Ignore(r => r.Creator);

            modelBuilder.Entity<Product>().Ignore(p => p.Creator);

            modelBuilder.Entity<Category>().Ignore(c => c.Creator);



            modelBuilder.Entity<DepartmentLog>().Ignore(dl => dl.Updater);
            modelBuilder.Entity<PositionLog>().Ignore(pl => pl.Updater);
            modelBuilder.Entity<CompanyLog>().Ignore(cl => cl.Updater);
            modelBuilder.Entity<RepresentativeLog>().Ignore(rl => rl.Updater);
            modelBuilder.Entity<ProductLog>().Ignore(pl => pl.Updater);
            modelBuilder.Entity<CategoryLog>().Ignore(cl => cl.Updater);
            modelBuilder.Seed();
        }
    }
}
