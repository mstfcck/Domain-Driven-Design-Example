using System;

namespace eCommerce.ApplicationLayer.Products
{
    public interface IProductService
    {
        ProductDto Get(Guid productId);

        ProductDto Add(ProductDto product);
    }
}