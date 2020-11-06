import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NgModule } from '@angular/core';
//import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';




@Component({
  //selector: 'app-root', denne gjør ikke noe da det er routing som gjelder
  
  templateUrl: './tidligereStilteSporsmal.component.html'
  
})
export class TidligereStilteSporsmalComponent {

  public alleSporsmal: Array<SporsmalSvar>;
  
  public liker: number=0;
 
  public buttons = Array(5).fill(false);
  public laster: boolean;




  constructor(private _http: HttpClient, private router: Router, private route: ActivatedRoute) { }


  hentAlleSporsmal() {

    ;

    //HentAlle()fra controller

    this._http.get<SporsmalSvar[]>("api/KundeService")
      .subscribe(data => {
        this.alleSporsmal = data;
        console.log(this.alleSporsmal);
        
      },
        error => alert(error + " Klarte ikke hente spørsmålene."),
        () => console.log("ferdig get-/Svar")
      );

  }
 
  /*liker2() {
    
    this.click1 = !this.click1;
    this.liker++;
    //let vurdering = this.alleSporsmal.find(f => f.svarId == svarId);
    //this.lagreVurdering(svarId);
    document.getElementById('utskrift').innerHTML = "Vurderingen din er sendt. Med vurderingen: " + this.liker;
    
  }*/

  ngOnInit() {
    this.laster = true;
    this.hentAlleSporsmal();
  }

  lagreVurdering(svarId: number) {

    //const enVurdering = new SporsmalSvar();
    //må ha med svarid til svaret som blir ratet

    //buttons[indeks] = true
    //this.buttons = !this.buttons;
    //this.liker++;
    let vurdering = this.alleSporsmal.find(f => f.svarId === svarId);
    if (vurdering != null) {
      vurdering.liker++;
      this.liker = vurdering.liker;
     
    }

    //enVurdering.liker = this.liker;


    this._http.post("api/KundeService/lagreVurdering", svarId)
      .subscribe(retur => {
        
        this.router.navigate(["/"]);
      },
        error => console.log("feilen er" + error)
    );

    document.getElementById('utskrift').innerHTML = "Vurderingen din er sendt. Med vurderingen: " + this.liker;
    
  };


}

export class SporsmalSvar {
  svarId: number;
  sporsmalet: String;
  svaret: String;
  liker: number;
 

}


