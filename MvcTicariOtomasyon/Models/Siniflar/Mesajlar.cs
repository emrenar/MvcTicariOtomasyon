 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcTicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Gönderici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Alıcı { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Konu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Icerik { get; set; }

        [Column(TypeName = "SmallDateTime")]
        public DateTime Tarih { get; set; }
    }
}