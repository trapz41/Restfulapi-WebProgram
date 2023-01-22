using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Admin
    {
        [Key]
        public int id { get; set; }
        public string kullaniciadi { get; set; }
        public string sifre { get; set; }
    }
}
