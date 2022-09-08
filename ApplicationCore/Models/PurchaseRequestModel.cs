﻿using System;
namespace ApplicationCore.Models
{
    public class PurchaseRequestModel
    {
        public Guid PurchaseNumber => Guid.NewGuid();
        public DateTime PurchaseDateTime => DateTime.UtcNow;
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal Price { get; set; }
    }
}

