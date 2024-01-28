using WebApp.Models.Enums;

namespace WebApp.Models
{
    public class SalesRecords
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public SalesStatus Status { get; set; }

        public Seller? Seller { get; set; }

        public SalesRecords() { }

        public SalesRecords(int id, DateTime date, double amount, SalesStatus status, Seller seller)
        {

            this.Seller = seller;
            this.Id = id;
            this.Status = status;
            this.Date = date;
            this.Amount = amount;

        }

    }
}