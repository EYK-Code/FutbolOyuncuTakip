namespace FutbolOyuncuTakip.UI.Models
{
    public class Futbolcu
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Mevki { get; set; }
        public int TakimId { get; set; }
        public Takim Takim { get; set; }
    }
}
