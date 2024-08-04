using DevExtremeAspNetCoreApp1.Entities;

namespace DevExtremeAspNetCoreApp1.DTOs
{
    public class KisiGorevDto
    {
        public int KisiId { get; set; }
        public Kisi kisi { get; set; }
        public int PGID { get; set; }
        public PersonelGorev personelGorev { get; set; }
        public int TanimId { get; set; }
        public Tanim tanim { get; set; }
    }
}
