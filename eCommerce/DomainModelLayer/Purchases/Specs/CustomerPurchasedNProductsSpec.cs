using eCommerce.Helpers.Specification;
using System;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Purchases.Specs
{
    public class PurchasedNProductsSpec : SpecificationBase<Purchase>
    {
        private readonly int nProducts;

        public PurchasedNProductsSpec(int nProducts)
        {
            this.nProducts = nProducts;
        }

        public override Expression<Func<Purchase, bool>> SpecExpression
        {
            get
            {
                return purchase => purchase.Products.Count >= this.nProducts;
            }
        }
    }
}