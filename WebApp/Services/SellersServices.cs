
using System.Security.Cryptography.X509Certificates;
using WebApp.Models;

namespace WebApp.Services
{
    public class SellerServices
    {
        private readonly WebAppContext _context = new();

        public List<Seller> FindAll()
        {
            return [.. _context.Seller];
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}