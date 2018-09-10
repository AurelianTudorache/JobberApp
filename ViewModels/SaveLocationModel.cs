namespace JobberApp.ViewModels
{
    public class SaveLocationModel
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

    }
}