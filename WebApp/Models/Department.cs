namespace WebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = [];

        public Department() { }

        public Department(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);

        }

        public double TotalSales(DateTime init, DateTime fin)
        {

            return Sellers.Sum(sl => sl.TotalSales(init, fin));

        }
    }
}