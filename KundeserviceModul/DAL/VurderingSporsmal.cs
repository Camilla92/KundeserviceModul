using System;
using System.ComponentModel.DataAnnotations;

namespace KundeserviceModul.DAL
{
    public class VurderingSporsmal
    {
        
        [Key]
        public int VurderingsNr { get; set; }
        public virtual SporsmalSvar SvarId { get; set; }
        public int Liker { get; set; }
        public int Misliker { get; set; }
    }
}
