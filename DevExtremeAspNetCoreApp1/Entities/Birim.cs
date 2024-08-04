using System.ComponentModel.DataAnnotations;

namespace DevExtremeAspNetCoreApp1.Entities
{
    public class Birim
    {
        public int YoksisId { get; set; }
        public string Ad { get; set; }
        public string KisaAd { get; set; }
        public string Tur { get; set; }
        public int UstYoksisId { get; set; }
        public string Durum { get; set; } 
        public string AdIng { get; set; }
        public string EnumBirimTuru { get; set; }
        public string THE { get; set; }
        public string QS { get; set; }
        public string IliskiliYoksisId { get; set; }

    }
}
