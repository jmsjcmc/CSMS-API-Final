namespace CSMS_API.Controllers.User
{
    public class UserQuery
    {
        private readonly DB _context;
        public UserQuery(DB context)
        {
            _context = context;
        }
    }
}
