using System;
namespace KundeserviceModul.Model
{
    public class SporsmalSvar
    {
        

          public int id { get; set; }
          //Spørsmål
          public string sporsmalet { get; set; }
          //Svar
          public string svaret { get; set; }

          //for rating  
          public int liker { get; set; }
          public int misliker { get; set; }


    }
}
