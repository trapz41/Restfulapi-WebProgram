using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Haberler
    {
        [Key]
        public int id { get; set; }
       
        public string baslik { get; set; }
        public string duyuru { get; set; }
    }
}
