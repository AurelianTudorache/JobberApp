using System.ComponentModel.DataAnnotations.Schema;
using JobberApp.Repositories;

namespace JobberApp.Data.Models
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ImageThumbnail { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}