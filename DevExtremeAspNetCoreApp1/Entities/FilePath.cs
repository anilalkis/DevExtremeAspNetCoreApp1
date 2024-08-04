namespace DevExtremeAspNetCoreApp1.Entities
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        public string Path { get; set; }
        public int KararId { get; set; }
        public Karar Karar { get; set; }
    }
}
