namespace BiddingManagementSystem2.Domain.Entities
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SubmittedAt { get; set; }

        public int TenderId { get; set; }
        public Tender? Tender { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }

}
