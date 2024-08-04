
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevExtremeAspNetCoreApp1.Entities
{
    public class PersonelGorev
    {
        [Key]
        public int PGID { get; set; }

        [ForeignKey("Kisi")]
        public int KisiId { get; set; }
        public Kisi Kisi { get; set; }

        [ForeignKey("Tanim")]
        public int TanimId { get; set; }
        public Tanim Tanim { get; set; }

        public int BirimId { get; set; }

        public DateTime BaslamaTarih { get; set; }
        public DateTime BitisTarih { get; set; }
    }
}
