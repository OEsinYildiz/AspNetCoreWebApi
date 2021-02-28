using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repository;

namespace UdemyNLayerProject.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<Product> GetWithCategoryById(int id)
        {
            return await _appDbContext.Products.Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}