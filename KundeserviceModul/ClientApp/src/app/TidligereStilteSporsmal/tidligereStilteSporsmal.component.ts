import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NgModule } from '@angular/core';
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

   
    this._http.get<SporsmalSvar[]>("api/KundeService")
      .subscribe(data => {
        this.alleSporsmal = data;
        console.log(this.alleSporsmal);
        
      },
        error => alert(error + " Klarte ikke hente spørsmålene."),
        () => console.log("ferdig get-/Svar")
      );

  }


  ngOnInit() {
    this.laster = true;
    this.hentAlleSporsmal();
  }

  lagreVurdering(svarId: number) {

 
    let vurdering = this.alleSporsmal.find(f => f.svarId === svarId);
    if (vurdering != null) {
      vurdering.liker++;
      
    }

   

    this._http.post("api/KundeService/lagreVurderingLiker", svarId)
      .subscribe(retur => {
        
        this.router.navigate(["/"]);
      },
        error => console.log("feilen er" + error)
    );

  };




  lagreVurderingMisliker(svarId: number) {

    let vurdering = this.alleSporsmal.find(f => f.svarId === svarId);
    if (vurdering != null) {
      vurdering.misliker++;
     
    }

    this._http.post("api/KundeService/lagreVurderingMisliker", svarId)
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
  misliker: number;
 

}


