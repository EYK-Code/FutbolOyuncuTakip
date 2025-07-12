namespace FutbolOyuncuTakip.UI.Models
{
    public class Takim
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int LigId { get; set; }
        public Lig Lig { get; set; }
        public ICollection<Futbolcu> Futbolcular { get; set; }
    }
}
