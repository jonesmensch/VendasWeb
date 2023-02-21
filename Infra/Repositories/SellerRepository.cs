using Domain;
using Domain.Interfaces.Infra.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using VendasWeb.Data;

namespace Infra.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly Context _context;

        public SellerRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.sellers.ToListAsync();
        }

        public async Task<Seller> GetByIdAsync(int id)
        {
            return await _context.sellers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OperationResult<Seller>> CreateAsync(Seller seller)
        {
            try
            {
                await _context.sellers.AddAsync(seller);
                await _context.SaveChangesAsync();

                return OperationResult<Seller>.CreateSuccess(seller);
            }
            catch
            {
                return OperationResult<Seller>.CreateFail("An error has occurred, please try again.");
            }
        }

        public async Task<OperationResult<Seller>> EditAsync(Seller seller)
        {
            var result = await _context.sellers.AnyAsync(x => x.Id == seller.Id);
            if (!result)
                return OperationResult<Seller>.CreateFail("Id not found.");

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();

                return OperationResult<Seller>.CreateSuccess(seller);
            }
            catch
            {
                return OperationResult<Seller>.CreateFail("There was an error while trying to update!");
            }
        }

        public async Task<OperationResult> DeleteAsync(int id)
        {
            Seller seller = await GetByIdAsync(id);

            if (seller == null)
                return OperationResult.CreateFail("Id not found");

            try
            {
                _context.Remove(seller);
                await _context.SaveChangesAsync();

                return OperationResult.CreateSuccess();
            }
            catch
            {
                return OperationResult.CreateFail("An error has occurred, please try again!");
            }
        }
    }
}
