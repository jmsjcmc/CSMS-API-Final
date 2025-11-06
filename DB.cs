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
        public DbSet<UserRoleLog> UserRoleLog { get; set; }
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
        public DbSet<Receiving> Receiving { get; set; }
        public DbSet<ReceivingLog> ReceivingLog { get; set; }
        public DbSet<ReceivingDetail> ReceivingDetail { get; set; }
        public DbSet<ReceivingDetailLog> ReceivingDetailLog { get; set; }
        public DbSet<Pallet> Pallet { get; set; }
        public DbSet<PalletLog> PalletLog { get; set; }
        public DbSet<PalletPosition> PalletPosition { get; set; }
        public DbSet<PalletPositionLog> PalletPositionLog { get; set; }
        public DbSet<ColdStorage> ColdStorage { get; set; }
        public DbSet<ColdStorageLog> ColdStorageLog { get; set; }
        public DbSet<ReceivingProduct> ReceivingProduct { get; set; }
        public DbSet<ReceivingProductLog> ReceivingProductLog { get; set; }
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
            modelBuilder.Entity<DepartmentLog>().Ignore(dl => dl.Updater);

            modelBuilder.Entity<Position>().Ignore(p => p.Creator);
            modelBuilder.Entity<PositionLog>().Ignore(pl => pl.Updater);

            modelBuilder.Entity<Company>().Ignore(c => c.Creator);
            modelBuilder.Entity<CompanyLog>().Ignore(cl => cl.Updater);

            modelBuilder.Entity<Representative>().Ignore(r => r.Creator);
            modelBuilder.Entity<RepresentativeLog>().Ignore(rl => rl.Updater);

            modelBuilder.Entity<Product>().Ignore(p => p.Creator);
            modelBuilder.Entity<ProductLog>().Ignore(pl => pl.Updater);

            modelBuilder.Entity<Category>().Ignore(c => c.Creator);
            modelBuilder.Entity<CategoryLog>().Ignore(cl => cl.Updater);

            //modelBuilder.Entity<Receiving>().Ignore(r => r.Creator);
            //modelBuilder.Entity<ReceivingLog>().Ignore(rl => rl.Updater);

            //modelBuilder.Entity<ReceivingDetail>().Ignore(rd => rd.Creator);
            //modelBuilder.Entity<ReceivingDetailLog>().Ignore(rdl => rdl.Updater);

            modelBuilder.Entity<Pallet>().Ignore(p => p.Creator);
            modelBuilder.Entity<PalletLog>().Ignore(pl => pl.Updater);

            modelBuilder.Entity<PalletPosition>().Ignore(pp => pp.Creator);
            modelBuilder.Entity<PalletPositionLog>().Ignore(pl => pl.Updater);

            modelBuilder.Entity<ColdStorage>().Ignore(cs => cs.Creator);
            modelBuilder.Entity<ColdStorageLog>().Ignore(cs => cs.Updater);

            modelBuilder.Entity<UserRole>().Ignore(ur => ur.Assigner);
            modelBuilder.Entity<UserRoleLog>().Ignore(url => url.Updater);
            modelBuilder.Seed();
        }
    }
}
