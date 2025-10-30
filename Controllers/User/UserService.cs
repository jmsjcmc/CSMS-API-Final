using AutoMapper;

namespace CSMS_API.Controllers.User
{
    public interface UserInterface
    {

    }
    public class UserService : UserInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        public UserService(DB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
