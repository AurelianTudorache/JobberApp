using JobberApp.Repositories;

namespace JobberApp.Data.Models.Employee
{
    public class BankAccount : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
    }
}