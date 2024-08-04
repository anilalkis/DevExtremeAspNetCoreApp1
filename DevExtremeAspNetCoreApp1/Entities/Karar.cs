namespace DevExtremeAspNetCoreApp1.Entities
{
    public class Karar
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public List<FilePath> Files { get; set; }
        public int BirimId { get; set; }
    }
}
