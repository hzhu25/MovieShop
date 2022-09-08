using System;
namespace ApplicationCore.Entities
{
    public class Purchase
    {
        public int Id;

        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid PurchaseNumber { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}

