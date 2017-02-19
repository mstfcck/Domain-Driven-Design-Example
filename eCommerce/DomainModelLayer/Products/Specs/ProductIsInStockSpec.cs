using eCommerce.DomainModelLayer.Carts;
using eCommerce.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Products.Specs
{
    public class ProductIsInStockSpec : SpecificationBase<Product>
    {
        private readonly CartProduct productCart;

        public ProductIsInStockSpec(CartProduct productCart)
        {
            this.productCart = productCart;
        }

        public override Expression<Func<Product, bool>> SpecExpression
        {
            get
            {
                return product => product.Id == this.productCart.ProductId && product.Active
                    && product.Quantity >= this.productCart.Quantity;
            }
        }
    }
}