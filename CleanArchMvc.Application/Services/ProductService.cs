using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntiry = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntiry);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntiry = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntiry);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntiry = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntiry);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productEntiry = _mapper.Map<Product>(productDto);
            await _productRepository.CreateAsync(productEntiry);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productEntiry = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(productEntiry);
        }

        public async Task Remove(int? id)
        {
            var productEntiry = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemovoAsync(productEntiry);
        }
    }
}
