
using System.Data;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Services.Exceptions;

namespace WebApp.Services
{
    public class SellerServices
    {
        private readonly WebAppContext _context = new();

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            //this Include methods works like populate on mongoose, you just make a request to include the item to the obj
            try
            {
                return await _context.Seller.Include(ob => ob.Department)
                .FirstOrDefaultAsync(o => o.Id == id);
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                if (obj == null) return;
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {

                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny) throw new NotFoundException("couldn't find such seller");

            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException E)
            {
                System.Console.WriteLine(E);
                throw new DbConcurrenceExceptions(E.Message);
            }
        }

    }
}