using System;
using System.ComponentModel.DataAnnotations;

namespace KundeserviceModul.Model
{
    public class InnsendteSporsmal
    {
        
        public int spmlID { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-.,/?]{10,100}")]
        public string sporsmalet { get; set; }
        [RegularExpression(@"[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}")]
        public string epost { get; set; }
    }
}
