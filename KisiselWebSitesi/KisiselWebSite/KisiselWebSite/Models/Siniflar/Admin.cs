
using System.ComponentModel.DataAnnotations;


namespace KisiselWebSite.Models.Siniflar
{
    public class Admin
    {

        [Key]
        public int id { get; set; }

        public string kullaniciAdi { get; set; }

        public string sifre {  get; set; }
    }
}