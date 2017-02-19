﻿using System;
using System.Collections.Generic;

namespace eCommerce.ApplicationLayer.Carts
{
    public class CartDto
    {
        public Guid CustomerId { get; set; }
        public List<CartProductDto> Products { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}