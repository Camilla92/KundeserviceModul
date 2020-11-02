import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';


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

  onSubmit() {
    console.log("Spørsmålet er sendt.");
    //svaret.innerHTML({{ svarene.svaret }});
    var app = angular.module("minKlasse", ['ngSanitize']);
    app.controller("myCtrl", function ($scope) {
    $scope.svaret = "GeeksForGeeks: <h1>Hello!</h1>";
    }); 
  
    
  }
  
}

export class SporsmalSvar {
  svarId: number;
  //Spørsmål
  sporsmalet: String;
  //Svar
  svaret: String;

}