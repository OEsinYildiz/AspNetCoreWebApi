using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repository;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data.Repository;

namespace UdemyNLayerProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;


        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IProductRepository Product => _productRepository ??= new ProductRepository(_context);
        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}