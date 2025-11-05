using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Utils
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessUnit>()
                .HasData(
                new BusinessUnit
                {
                    ID = 1,
                    Name = "ABFI",
                    Location = "Binugao, Toril, Davao City"
                });
            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    ID = 1,
                    FirstName = "James",
                    LastName = "Tabilog",
                    Username = "211072",
                    Password = "$2a$11$V/JTbg48n4h3Zs4V3n5PMezUMbqJYGEhl7vN6gOQ39gxWTEEx0Q9C",
                    BusinessUnitID = 1,
                    RecordStatus = RecordStatus.Active
                });
        }
    }
}
