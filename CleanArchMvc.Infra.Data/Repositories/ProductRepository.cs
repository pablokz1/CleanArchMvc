using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        AplicationDbContext _productContex;
        public ProductRepository(AplicationDbContext contex)
        {
            _productContex = contex;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContex.Add(product);
            await _productContex.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContex.Products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(int? id) 
        {
            //eager loading (carregamento adiantado)
            return await _productContex.Products.Include(c=> c.Category)
                .SingleOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContex.Products.ToArrayAsync();
        }

        public async Task<Product> RemovoAsync(Product product)
        {
            _productContex.Remove(product);
            await _productContex.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContex.Update(product);
            await _productContex.SaveChangesAsync();
            return product;
        }
    }
}
