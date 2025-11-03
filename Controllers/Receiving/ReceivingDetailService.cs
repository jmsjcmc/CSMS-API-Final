using AutoMapper;

namespace CSMS_API.Controllers
{
    public interface ReceivingDetailInterface
    {

    }
    public class ReceivingDetailService : ReceivingDetailInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly ReceivingDetailQuery _receivingDetailQuery;
        public ReceivingDetailService(DB context, IMapper mapper, ReceivingDetailQuery receivingDetailQuery)
        {
            _context = context;
            _mapper = mapper;
            _receivingDetailQuery = receivingDetailQuery;
        }

    }
}