
using Magazine_Web_Api.Enums;
using Magazine_Web_Api.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Magazine_Web_Api.Models
{
    public class Dergi
    {
        [Key]
        public int DergiId { get; set; }
        [Required(ErrorMessage = "Lütfen Dergi Adı Alanını Doldurun")]
        public string DergiAdi { get; set; }
        // public int YayıneviId { get; set; }
        [Required(ErrorMessage = "Lütfen İmtiyaz Sahibi Alanını Doldurun")]
        public string İmtiyazSahibi { get; set; }
      
        public YayinTuru YayinTuru { get; set; }
        
        public YayinPeriyodu YayinPeriyodu{ get; set; }
    }
}
