using System.Security.Cryptography;

namespace BiddingManagementSystem2.Domain.Entities
{
    public class Tender
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ClosingDate { get; set; }

        public ICollection<Bid>? Bids { get; set; }
    }

}
