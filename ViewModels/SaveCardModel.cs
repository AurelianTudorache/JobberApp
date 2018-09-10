namespace JobberApp.ViewModels
{
    public class SaveCardModel
    {
        public int Id { get; set; }
        public string NameOnCard { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public byte ExpMonth { get; set; }
        public short ExpYear { get; set; }
        public string CVC { get; set; }
    }
}