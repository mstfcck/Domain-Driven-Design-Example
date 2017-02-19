using eCommerce.DomainModelLayer.Carts.Enums;
using System;

namespace eCommerce.ApplicationLayer.Carts.Dtos
{
    public class CheckOutResultDto
    {
        public Nullable<Guid> PurchaseId { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalTax { get; set; }
        public Nullable<CheckOutIssue> CheckOutIssue { get; set; }
    }
}