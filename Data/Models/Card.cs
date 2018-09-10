using System;
using JobberApp.Repositories;

namespace JobberApp.Data.Models
{
    public class Card : IEntity
    {
        public int Id { get; set; }
        public string NameOnCard { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        public string CVC { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}