using eCommerce.DomainModelLayer.Products;
using eCommerce.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Carts.Specs
{
    public class ProductInCartSpec : SpecificationBase<CartProduct>
    {
        private readonly Product product;

        public ProductInCartSpec(Product product)
        {
            this.product = product;
        }

        public override Expression<Func<CartProduct, bool>> SpecExpression
        {
            get
            {
                return cartProduct => cartProduct.ProductId == this.product.Id;
            }
        }
    }
}