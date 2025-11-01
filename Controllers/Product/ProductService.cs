using AutoMapper;

namespace CSMS_API.Controllers
{
    public interface ProductInterface
    {
        
    }
    public class ProductService : ProductInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly ProductQuery _productQuery;
        public ProductService(DB context, IMapper mapper, ProductQuery productQuery)
        {
            _context = context;
            _mapper = mapper;
            _productQuery = productQuery;
        }
        
    }
}