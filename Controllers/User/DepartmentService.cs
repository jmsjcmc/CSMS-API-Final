using AutoMapper;

namespace CSMS_API.Controllers
{
    public interface DepartmentInterface
    {
    }
    public class DepartmentService : DepartmentInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        public DepartmentService(DB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}