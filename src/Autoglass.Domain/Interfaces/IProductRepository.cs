// Autoglass.Domain/Interfaces/IProductRepository.cs
using Autoglass.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task SoftDeleteAsync(int id);
    }
}
