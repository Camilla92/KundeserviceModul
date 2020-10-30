using System;
using System.ComponentModel.DataAnnotations;

namespace KundeserviceModul.DAL
{
    public class Sporsmal
    {
        [Key]
        public int SpmlID { get; set; }
        public string Sporsmalet { get; set; }

    }
}
