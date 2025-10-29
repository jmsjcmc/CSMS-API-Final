using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base (options) { }
        public DbSet<User> User { get; set; }
        public DbSet<UserLog> UserLog { get; set; }
        public DbSet<Role> Role { get; set; }   
        public DbSet<RoleLog> RoleLog { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<BusinessUnit> BusinessUnit { get; set; }   
        public DbSet<BusinessUnitLog> BusinessUnitLog { get; set; }
    }
}
