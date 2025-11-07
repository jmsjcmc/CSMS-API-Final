using AutoMapper;

namespace CSMS_API.Controllers
{
    public interface DispatchingInterface
    {

    }
    public class DispatchingService : DispatchingInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly DispatchingQuery _dispatchingQuery;
        public DispatchingService(DB context, IMapper mapper, DispatchingQuery dispatchingQuery)
        {
            _context = context;
            _mapper = mapper;
            _dispatchingQuery = dispatchingQuery;
        }
    }
}