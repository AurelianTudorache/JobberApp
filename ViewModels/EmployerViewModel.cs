using System.Collections.Generic;

namespace JobberApp.ViewModels
{
    public class EmployerViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyNumber { get; set; }
        public string VatNumber { get; set; }  
        public string BrandThumbnail { get; set; }
        public string HqCity { get; set; }
        public string HqStreet { get; set; }
        public string HqBuilding { get; set; }
        public string HqPostalCode { get; set; }
        public virtual ICollection<LocationViewModel> Locations { get; set; }
        // public virtual ICollection<MessageViewModel> Messages { get; set; }
    }
}