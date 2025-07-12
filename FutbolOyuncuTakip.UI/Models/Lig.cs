namespace FutbolOyuncuTakip.UI.Models
{
    public class Lig
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public ICollection<Takim> Takimlar { get; set; }
    }
}
