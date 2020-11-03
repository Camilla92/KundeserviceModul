using System;
using System.ComponentModel.DataAnnotations;

namespace KundeserviceModul.DAL
{
    public class InnsendteSporsmal
    {
        [Key]
        public int SpmlID { get; set; }
        public string Sporsmalet { get; set; }
        public string Epost { get; set; }

    }
}
