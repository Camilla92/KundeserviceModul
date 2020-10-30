import { Component } from '@angular/core';
import { Svar } from "./Svar";

@Component({
  //selector: 'app-root', denne gjør ikke noe da det er routing som gjelder
  templateUrl: './tidligereStilteSporsmal.component.html'
})
export class TidligereStilteSporsmalComponent {

 // public alleSporsmal: Array<Svar>;
 // public laster: string;

 /*constructor(private _http: HttpClient) { }

  hentAlleSporsmal() {
    this.laster = "Vennligst vent";
    this._http.get<SporsmalSvar[]>("DAL/Svar/")
      .subscribe(data => {
        this.alleSporsmal = data;
        this.laster = "";
      },
        error => alert(error),
        () => console.log("ferdig get-/Svar")
      );
  }
  */


}