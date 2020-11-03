import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';



@Component({
  //selector: 'app-root', denne gjør ikke noe da det er routing som gjelder
  templateUrl: './tidligereStilteSporsmal.component.html'
})
export class TidligereStilteSporsmalComponent {

  public alleSporsmal: Array<SporsmalSvar>;
  public laster: string;


  constructor(private _http: HttpClient) { }


  hentAlleSporsmal() {

    this.laster = "Vennligst vent";
    
    //HentAlle()fra controller

    this._http.get<SporsmalSvar[]>("api/KundeService")
      .subscribe(data => {
        this.alleSporsmal = data;
        console.log(this.alleSporsmal);
        this.laster = "";
      },
        error => alert(error+" Klarte ikke hente spørsmålene."),
        () => console.log("ferdig get-/Svar")
    );
    
  }

  skrivutSvar() {
    /*console.log("Spørsmålet er sendt.");*/
  
  
    var vis = document.getElementById("svaret");
   
    
    if (vis.style.display === "none") {
      vis.style.display = "block";
    } else {
      vis.style.display = "none";
    }

  
  }
  
}

export class SporsmalSvar {
  svarId: number;
  //Spørsmål
  sporsmalet: String;
  //Svar
  svaret: String;

}