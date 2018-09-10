using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JobberApp.Repositories;

namespace JobberApp.Data.Models
{
    public class Employer : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyNumber { get; set; }
        public string VatNumber { get; set; }  
        public string BrandThumbnail { get; set; }
        public string HqCity { get; set; }
        public string HqStreet { get; set; }
        public string HqBuilding { get; set; }
        public string HqPostalCode { get; set; }

        [ForeignKey("UserId")] 
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Location> Locations { get; set; }       
        public virtual ICollection<JobAd> JobAds { get; set; }
    }
}