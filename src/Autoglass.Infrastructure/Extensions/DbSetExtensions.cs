using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Autoglass.Domain.Entities;

namespace Autoglass.Infrastructure.Extensions
{
    public static class DbSetExtensions
    {
        public static async Task<Product> FindProductAsync(this DbSet<Product> products, int id)
        {
            return await products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
