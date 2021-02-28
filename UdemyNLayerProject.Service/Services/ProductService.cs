using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repository;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWork;

namespace UdemyNLayerProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int id)
        {
            return await _unitOfWork.Product.GetWithCategoryById(id);
        }
    }
}