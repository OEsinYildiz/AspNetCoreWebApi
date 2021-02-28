using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repository;

namespace UdemyNLayerProject.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        Task CommitAsync();
        void Commit();
    }
}