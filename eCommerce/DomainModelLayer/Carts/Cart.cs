using eCommerce.DomainModelLayer.Carts.DomainEvents;
using eCommerce.DomainModelLayer.Carts.Specs;
using eCommerce.DomainModelLayer.Customers;
using eCommerce.DomainModelLayer.Products;
using eCommerce.Helpers.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace eCommerce.DomainModelLayer.Carts
{
    public class Cart : IAggregateRoot
    {
        public virtual Guid Id { get; protected set; }

        private List<CartProduct> cartProducts = new List<CartProduct>();

        public virtual ReadOnlyCollection<CartProduct> Products
        {
            get { return cartProducts.AsReadOnly(); }
        }

        public virtual Guid CustomerId { get; protected set; }

        public virtual decimal TotalCost
        {
            get
            {
                return this.Products.Sum(cartProduct => cartProduct.Quantity * cartProduct.Cost);
            }
        }

        public virtual decimal TotalTax
        {
            get
            {
                return this.Products.Sum(cartProducts => cartProducts.Tax);
            }
        }

        public static Cart Create(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            Cart cart = new Cart();
            cart.Id = Guid.NewGuid();
            cart.CustomerId = customer.Id;

            DomainEventsHelper.Raise<CartCreatedDomainEvent>(new CartCreatedDomainEvent() { Cart = cart });

            return cart;
        }

        public virtual void Add(CartProduct cartProduct)
        {
            if (cartProduct == null)
                throw new ArgumentNullException();

            DomainEventsHelper.Raise<ProductAddedCartDomainEvent>(new ProductAddedCartDomainEvent() { CartProduct = cartProduct });

            this.cartProducts.Add(cartProduct);
        }

        public virtual void Remove(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");

            CartProduct cartProduct =
                this.cartProducts.Find(new ProductInCartSpec(product).IsSatisfiedBy);

            DomainEventsHelper.Raise<ProductRemovedCartDomainEvent>(new ProductRemovedCartDomainEvent() { CartProduct = cartProduct });

            this.cartProducts.Remove(cartProduct);
        }

        public virtual void Clear()
        {
            this.cartProducts.Clear();
        }
    }
}