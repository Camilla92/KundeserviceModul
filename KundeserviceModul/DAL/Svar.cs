using System;
using System.ComponentModel.DataAnnotations;

namespace KundeserviceModul.DAL
{
    public class Svar
    {
        [Key]
        public int SvarId { get; set; }
        public virtual Sporsmal Sporsmalet { get; set; }
        public string Svaret { get; set; }
        

    }
}
