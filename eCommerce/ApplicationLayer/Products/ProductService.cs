﻿using eCommerce.DomainModelLayer.Products;
using eCommerce.Helpers.Repository;
using System;

namespace eCommerce.ApplicationLayer.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<ProductCode> productCodeRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IRepository<Product> productRepository,
            IRepository<ProductCode> productCodeRepository,
            IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.productCodeRepository = productCodeRepository;
            this.unitOfWork = unitOfWork;
        }

        public ProductDto Get(Guid productId)
        {
            Product product = this.productRepository.FindById(productId);
            return AutoMapper.Mapper.Map<Product, ProductDto>(product);
        }

        public ProductDto Add(ProductDto productDto)
        {
            ProductCode productCode =
                this.productCodeRepository.FindById(productDto.ProductCodeId);

            if (productCode == null)
                throw new Exception("Product Code Is Not Valid");

            Product product =
                Product.Create(productDto.Name, productDto.Quantity, productDto.Cost, productCode);

            this.productRepository.Add(product);

            return AutoMapper.Mapper.Map<Product, ProductDto>(product);
        }
    }
}