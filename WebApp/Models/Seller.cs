using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Seller
    {
        public int Id { get; set; }


        [
        Required(ErrorMessage = "{0} required"),
        StringLength(60, MinimumLength = 3, ErrorMessage = "{0} minimum size {2} and maximum {1}")
        ]
        public string? Name { get; set; }

        //this data type converts the display, in this case this method insert "mailto:" atribute on anchor tag.
        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string? Email { get; set; }

        //the method  @Html.DisplayNameFor(m => m.Name) on cshtml display BirthDay without space, so we gonna change that by using
        //annotation display, i thing is something like in JS where you use {[varName]:value}
        [Display(Name = "Birth Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} required")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "{0} required")]
        //DisplayFormat configure the format, like 2 decimal places
        [Display(Name = "Base Salary"), DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
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