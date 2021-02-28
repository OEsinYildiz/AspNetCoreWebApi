using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Services
{
    public interface IProductService : IService<Product>
    {
        //Ic metotlarin tanimlandigi yer. DB islemleri yapilmaz
        Task<Product> GetWithCategoryByIdAsync(int id);
    }
}