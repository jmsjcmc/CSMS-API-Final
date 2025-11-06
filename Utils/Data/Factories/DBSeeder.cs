//using Bogus;
//using CSMS_API.Models;
//using Microsoft.EntityFrameworkCore;

//namespace CSMS_API.Utils
//{
//    public static class DatabaseSeeder
//    {
//        public static async Task SeedAsync(DB context)
//        {
//            // Don't duplicate seed data
//            if (await context.User.AnyAsync()) return;

//            var random = new Random();

//            // ---------- Create Departments ----------
//            var departmentFaker = new Faker<Department>()
//                .RuleFor(d => d.Name, f => f.Commerce.Department())
//                .RuleFor(d => d.CreatedOn, f => f.Date.Past())
//                .RuleFor(d => d.RecordStatus, RecordStatus.Active);

//            var departments = departmentFaker.Generate(5);
//            await context.Department.AddRangeAsync(departments);
//            await context.SaveChangesAsync();

//            // ---------- Create Positions ----------
//            var positionFaker = new Faker<Position>()
//                .RuleFor(p => p.Name, f => f.Name.JobTitle())
//                .RuleFor(p => p.DepartmentID, f => f.PickRandom(departments).ID)
//                .RuleFor(p => p.CreatedOn, f => f.Date.Past())
//                .RuleFor(p => p.RecordStatus, RecordStatus.Active);

//            var positions = positionFaker.Generate(10);
//            await context.Position.AddRangeAsync(positions);
//            await context.SaveChangesAsync();

//            // ---------- Create Business Units ----------
//            var businessUnitFaker = new Faker<BusinessUnit>()
//                .RuleFor(b => b.Name, f => f.Company.CompanyName())
//                .RuleFor(b => b.Location, f => f.Address.City())
//                .RuleFor(b => b.CreatedOn, f => f.Date.Past())
//                .RuleFor(b => b.RecordStatus, RecordStatus.Active);

//            var businessUnits = businessUnitFaker.Generate(3);
//            await context.BusinessUnit.AddRangeAsync(businessUnits);
//            await context.SaveChangesAsync();

//            // ---------- Create Users ----------
//            var userFaker = new Faker<User>()
//                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
//                .RuleFor(u => u.LastName, f => f.Name.LastName())
//                .RuleFor(u => u.Username, (f, u) => $"{u.FirstName.ToLower()}.{u.LastName.ToLower()}")
//                .RuleFor(u => u.Password, f => "123") // later hash this
//                .RuleFor(u => u.BusinessUnitID, f => f.PickRandom(businessUnits).ID)
//                .RuleFor(u => u.PositionID, f => f.PickRandom(positions).ID)
//                .RuleFor(u => u.CreatedOn, f => f.Date.Past())
//                .RuleFor(u => u.RecordStatus, RecordStatus.Active);

//            var users = userFaker.Generate(20);
//            await context.User.AddRangeAsync(users);
//            await context.SaveChangesAsync();

//            // ---------- Create Roles ----------
//            var roles = new[]
//            {
//                new Role { Name = "Admin", CreatedOn = DateTime.UtcNow, RecordStatus = RecordStatus.Active },
//                new Role { Name = "Manager", CreatedOn = DateTime.UtcNow, RecordStatus = RecordStatus.Active },
//                new Role { Name = "Employee", CreatedOn = DateTime.UtcNow, RecordStatus = RecordStatus.Active }
//            };
//            await context.Role.AddRangeAsync(roles);
//            await context.SaveChangesAsync();

//            // ---------- Assign Roles to Users ----------
//            var userRoleFaker = new Faker<UserRole>()
//                .RuleFor(ur => ur.UserID, f => f.PickRandom(users).ID)
//                .RuleFor(ur => ur.RoleID, f => f.PickRandom(roles).ID)
//                .RuleFor(ur => ur.AssignedOn, f => f.Date.Past())
//                .RuleFor(ur => ur.RecordStatus, RecordStatus.Active);

//            var userRoles = userRoleFaker.Generate(50);
//            await context.UserRole.AddRangeAsync(userRoles);
//            await context.SaveChangesAsync();
//        }
//    }
//}