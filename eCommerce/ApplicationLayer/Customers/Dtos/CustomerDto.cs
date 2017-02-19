﻿using System;

namespace eCommerce.ApplicationLayer.Customers.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid CountryId { get; set; }
    }
}