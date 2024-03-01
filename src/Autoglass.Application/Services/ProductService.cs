// Autoglass.Application/Services/ProductService.cs
using Autoglass.Application.Dto;
using Autoglass.Domain.Entities;
using Autoglass.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task AddProductAsync(ProductDTO productDto)
        {
            if (productDto.ManufacturingDate >= productDto.ExpiryDate)
            {
                throw new ArgumentException("Manufacturing date cannot be greater than or equal to expiry date.");
            }

            var product = new Product
            {
                Description = productDto.Description,
                Status = "Active",
                ManufacturingDate = productDto.ManufacturingDate,
                ExpiryDate = productDto.ExpiryDate,
                SupplierCode = productDto.SupplierCode,
                SupplierDescription = productDto.SupplierDescription,
                SupplierCNPJ = productDto.SupplierCNPJ
            };

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(int id, ProductDTO productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new ArgumentException("Product not found.");
            }

            if (productDto.ManufacturingDate >= productDto.ExpiryDate)
            {
                throw new ArgumentException("Manufacturing date cannot be greater than or equal to expiry date.");
            }

            existingProduct.Description = productDto.Description;
            existingProduct.ManufacturingDate = productDto.ManufacturingDate;
            existingProduct.ExpiryDate = productDto.ExpiryDate;
            existingProduct.SupplierCode = productDto.SupplierCode;
            existingProduct.SupplierDescription = productDto.SupplierDescription;
            existingProduct.SupplierCNPJ = productDto.SupplierCNPJ;

            await _productRepository.UpdateAsync(existingProduct);
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            await _productRepository.SoftDeleteAsync(id);
        }
    }
}
