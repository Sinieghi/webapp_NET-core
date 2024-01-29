namespace WebApp.Models
{
    public class Seller
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public DateTime BirthDay { get; set; }

        public double BaseSalary { get; set; }

        public Department? Department { get; set; }

        public int DepartmentId { get; set; }

        public ICollection<SalesRecords> Sales { get; set; } = [];

        public Seller() { }
        public Seller(int id, string name, string email, DateTime date, double salary, Department department)
        {
            this.Email = email;
            this.Id = id;
            this.Name = name;
            this.BirthDay = date;
            this.BaseSalary = salary;
            this.Department = department;
        }

        public void AddSales(SalesRecords sale)
        {
            Sales.Add(sale);
        }

        public void RemoveSale(SalesRecords sale)
        {
            Sales.Remove(sale);
        }

        public double TotalSales(DateTime init, DateTime fin)
        {
            return (from s in Sales
                    where s.Date >= init && s.Date <= fin
                    select s).Sum(s => s.Amount);
        }

    }
}