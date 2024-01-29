
using Microsoft.EntityFrameworkCore;
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

        public Seller FindById(int id)
        {
            //this Include methods works like populate on mongoose, you just make a request to include the item to the obj
            return _context.Seller.Include(ob => ob.Department).FirstOrDefault(o => o.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            if (obj == null) return;
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

    }
}