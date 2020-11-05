import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NgModule } from '@angular/core';
//import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';





@Component({
  //selector: 'app-root', denne gjør ikke noe da det er routing som gjelder
  
  templateUrl: './tidligereStilteSporsmal.component.html'
})
export class TidligereStilteSporsmalComponent {

  public alleSporsmal: Array<SporsmalSvar>;
  public laster: string;
  public liker: number = 0;
  public misliker: number = 0;
  public svarID: number;
  public sporsmalet: String;
  public svaret: String;
  public click1: boolean = false;
  public click2: boolean = false;
  //public buttons = Array(10).fill(false);




  constructor(private _http: HttpClient, private router: Router, private route: ActivatedRoute) { }


  hentAlleSporsmal() {

    this.laster = "Vennligst vent";

    //HentAlle()fra controller

    this._http.get<SporsmalSvar[]>("api/KundeService")
      .subscribe(data => {
        this.alleSporsmal = data;
        console.log(this.alleSporsmal);
        this.laster = "";
      },
        error => alert(error + " Klarte ikke hente spørsmålene."),
        () => console.log("ferdig get-/Svar")
      );

  }


  skrivutSvar() {

    var vis = document.getElementById("svaret[indeks]");
    if (vis.style.display === "none") {
      vis.style.display = "block";
    } else {
      vis.style.display = "none";
    }
  }
 

  liker2() {
    
    this.click1 = !this.click1;
    this.liker++;
    //let vurdering = this.alleSporsmal.find(f => f.svarId == svarId);
    this.lagreVurdering();
    document.getElementById('utskrift').innerHTML = "Vurderingen din er sendt. Med vurderingen: " + this.liker;
    
  }

  /*ngOnInit() {
    this.route.params.subscribe(params => {
      this.lagreVurdering(params.svarId);
    })
  }*/

  lagreVurdering() {

    const enVurdering = new SporsmalSvar();
    //må ha med svarid til svaret som blir ratet

    //buttons[indeks] = true
    //this.buttons = !this.buttons;

    //let vurdering = this.alleSporsmal.find(f => f.svarId == svarId);
    //this.liker++;

    enVurdering.liker = this.liker;
    

    this._http.post("api/KundeService/lagreVurdering", enVurdering)
      .subscribe(retur => {
        this.router.navigate(["/"]);
      },
        error => console.log("feilen er" + error)
      );
  }; 

}

export class SporsmalSvar {
  svarId: number;
  sporsmalet: String;
  svaret: String;
  liker: number;
 

}


