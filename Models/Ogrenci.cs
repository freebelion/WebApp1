namespace WebApp1.Models
{
    public class Ogrenci
    {
        private string ogrNumara;
        public int Id { get; set; }
        public string No
        {
            get { return ogrNumara; }
        }
        public string? Ad { get; set; }

        public int VizeNot { get; set; }
        public int FinalNot { get; set; }

        public Ogrenci()
        {
            ogrNumara = "22701" + Id.ToString("000");
            Ad = null;
        }
    }
}
