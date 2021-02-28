using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repository;

namespace UdemyNLayerProject.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<Category> GetWithProductsByIdAsync(int id)
        {
            return await _appDbContext.Categories.Include(c => c.Product).SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}