using SalesWebApplication.Data;
using SalesWebApplication.Models;

namespace SalesWebApplication.Services

{
    public class SellerService
    {
        private readonly SalesWebApplicationContext _context;

        public SellerService(SalesWebApplicationContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
