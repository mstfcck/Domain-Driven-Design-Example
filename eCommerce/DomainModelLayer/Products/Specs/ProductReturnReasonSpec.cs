using eCommerce.DomainModelLayer.Products.Enums;
using eCommerce.Helpers.Specification;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace eCommerce.DomainModelLayer.Products.Specs
{
    public class ProductReturnReasonSpec : SpecificationBase<Product>
    {
        private readonly ReturnReason returnReason;

        public ProductReturnReasonSpec(ReturnReason returnReason)
        {
            this.returnReason = returnReason;
        }

        public override Expression<Func<Product, bool>> SpecExpression
        {
            get
            {
                return product => product.Returns.ToList().Exists(returns => returns.Reason == this.returnReason);
            }
        }
    }
}