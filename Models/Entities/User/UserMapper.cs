using AutoMapper;

namespace CSMS_API.Models
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore());
            CreateMap<UpdateUserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore());
        }
    }
    public static class ManualUserMapping
    {
        public static UserOnlyResponse ManualUserOnlyResponse(User user)
        {
            return new UserOnlyResponse
            {
                ID = user.ID,
                FullName = $"{user.FirstName} {user.LastName}",
                Username = user.Username,
                Password = user.Password,
                CreatedOn = user.CreatedOn,
                RecordStatus = user.RecordStatus
            };
        }
        public static List<UserOnlyResponse> ManualUserOnlyResponse(List<User> users)
        {
            return users
                .Select(ManualUserOnlyResponse)
                .ToList();
        }
        public static UserWithBusinessUnitAndPositonResponse ManualUserWithBusinessUnitAndPositonResponse(User user)
        {
            return new UserWithBusinessUnitAndPositonResponse
            {
                ID = user.ID,
                FullName = $"{user.FirstName} {user.LastName}",
                Username = user.Username,
                BusinessUnitID = user.BusinessUnitID,
                BusinessUnitName = user.BusinessUnit.Name,
                BusinessUnitLocation = user.BusinessUnit.Location,
                PositionID = user.PositionID,
                PositionName = user.Position.Name,
                DepartmentID = user.Position.DepartmentID,
                DepartmentName = user.Position.Department.Name
            };
        }
        public static List<UserWithBusinessUnitAndPositonResponse> ManualUserWithBusinessUnitAndPositonListResponse(List<User> users)
        {
            return users
                .Select(ManualUserWithBusinessUnitAndPositonResponse)
                .ToList();
        }
        public static UserWithBusinessUnitAndPositionObjectResponse ManualUserWithBusinessUnitAndPositionObjectResponse(User user)
        {
            return new UserWithBusinessUnitAndPositionObjectResponse
            {
                ID = user.ID,
                FullName = $"{user.FirstName} {user.LastName}",
                Username = user.Username,
                CreatedOn = user.CreatedOn,
                RecordStatus = user.RecordStatus,
                BusinessUnit = user.BusinessUnit != null
                ? ManualBusinessUnitMapping.ManualBusinessUnitResponse(user.BusinessUnit)
                : null,
                Position = user.Position != null
                ? ManualPositionMapping.ManualPositionOnlyResponse(user.Position)
                : null
            };
        }
        public static List<UserWithBusinessUnitAndPositionObjectResponse> ManualUserWithBusinessUnitAndPositionObjectListResponse(List<User> users)
        {
            return users
                .Select(ManualUserWithBusinessUnitAndPositionObjectResponse)
                .ToList();
        }
    }
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleOnlyResponse>();
        }
    }
    public class UserRoleMapper : Profile
    {
        public UserRoleMapper()
        {
            CreateMap<UserRole, UserWithRoleResponse>()
                .ForMember(d => d.User, o => o.MapFrom(s => s.User))
                .ForMember(d => d.Role, o => o.MapFrom(s => s.Role));
        }
    }
}
