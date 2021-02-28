using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repository;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWork;

namespace UdemyNLayerProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int id)
        {
            return await _unitOfWork.Category.GetWithProductsByIdAsync(id);
        }
    }
}