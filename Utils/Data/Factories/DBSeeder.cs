using Bogus;
using CSMS_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSMS_API.Utils
{
    public static class DbSeeder
    {
        public static async Task Seed(DB _context)
        {
            if (await _context.User.AnyAsync())
                return; // Already seeded

            // 1. Departments
            var departmentFaker = new Faker<Department>()
                .RuleFor(d => d.Name, f => f.Commerce.Department())
                .RuleFor(d => d.CreatedOn, f => f.Date.Past(1))
                .RuleFor(d => d.RecordStatus, f => RecordStatus.Active);

            var departments = departmentFaker.Generate(5);
            await _context.Department.AddRangeAsync(departments);
            await _context.SaveChangesAsync();

            // 2. Positions
            var positionFaker = new Faker<Position>()
                .RuleFor(p => p.Name, f => f.Name.JobTitle())
                .RuleFor(p => p.DepartmentID, f => f.PickRandom(departments).ID)
                .RuleFor(p => p.CreatedOn, f => f.Date.Past(1))
                .RuleFor(p => p.RecordStatus, f => RecordStatus.Active);

            var positions = positionFaker.Generate(15);
            await _context.Position.AddRangeAsync(positions);
            await _context.SaveChangesAsync();

            // 3. Business Units
            var businessUnitFaker = new Faker<BusinessUnit>()
                .RuleFor(b => b.Name, f => $"{f.Company.CompanyName()} Unit")
                .RuleFor(b => b.Location, f => f.Address.City())
                .RuleFor(b => b.CreatedOn, f => f.Date.Past(1))
                .RuleFor(b => b.RecordStatus, f => RecordStatus.Active);

            var businessUnits = businessUnitFaker.Generate(4);
            await _context.BusinessUnit.AddRangeAsync(businessUnits);
            await _context.SaveChangesAsync();

            // 4. Users
            var userFaker = new Faker<User>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Username, (f, u) => $"{u.FirstName.ToLower()}.{u.LastName.ToLower()}")
            .RuleFor(u => u.Password, f => "123456") // ← hash later
            .RuleFor(u => u.BusinessUnitID, f => f.PickRandom(businessUnits).ID)
            .RuleFor(u => u.PositionID, f => f.PickRandom(positions).ID)
            .RuleFor(u => u.CreatedOn, f => f.Date.Past(1))
            .RuleFor(u => u.RecordStatus, f => RecordStatus.Active);

            var users = userFaker.Generate(50);
            await _context.User.AddRangeAsync(users);
            await _context.SaveChangesAsync();

            // 5. Roles
            var roleFaker = new Faker<Role>()
                .RuleFor(r => r.Name, f => f.Name.JobArea())
                .RuleFor(r => r.CreatedOn, f => f.Date.Past(1))
                .RuleFor(r => r.RecordStatus, f => RecordStatus.Active);

            var roles = roleFaker.Generate(5);
            await _context.Role.AddRangeAsync(roles);
            await _context.SaveChangesAsync();

            // 6. Assign Roles to Users
            var userRoleFaker = new Faker<UserRole>()
                .RuleFor(ur => ur.UserID, f => f.PickRandom(users).ID)
                .RuleFor(ur => ur.RoleID, f => f.PickRandom(roles).ID)
                .RuleFor(ur => ur.AssignedOn, f => f.Date.Past())
                .RuleFor(ur => ur.RecordStatus, RecordStatus.Active);

            var userRoles = userRoleFaker.Generate(60);
            await _context.UserRole.AddRangeAsync(userRoles);
            await _context.SaveChangesAsync();

            // 7. User Logs (Example)
            var userLogFaker = new Faker<UserLog>()
                .RuleFor(ul => ul.UserID, f => f.PickRandom(users).ID)
                .RuleFor(ul => ul.UpdaterID, f => f.PickRandom(users).ID)
                .RuleFor(ul => ul.UpdatedOn, f => f.Date.Recent());

            await _context.UserLog.AddRangeAsync(userLogFaker.Generate(200));
            await _context.SaveChangesAsync();
        }
    }
}
