using AutoMapper;

namespace CSMS_API.Models
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(d => d.Password, o => o.Ignore());
        }
    }
}
