using System;
using System.ComponentModel.DataAnnotations;

namespace KundeserviceModul.DAL
{
    public class SporsmalSvar
    {
        [Key]
        public int SvarId { get; set; }
        public string Sporsmalet { get; set; }
        public string Svaret { get; set; }
        public int Liker { get; set; }
        
        
        

    }
}
