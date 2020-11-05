import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
//import { error } from 'protractor';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  //selector: 'app-root', denne gjør ikke noe da det er routing som gjelder
  templateUrl: './nyttSporsmal.component.html'
})
export class NyttSporsmalComponent {

  //visSkjemaRegistrere: boolean;
  //visListe: boolean;
  Skjema: FormGroup;
  //innsendteSporsmal: Array<InnsendteSporsmal> = [];

  constructor(private _http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.Skjema = fb.group({

      dinEpost: ["", Validators.pattern("[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}")],
      dittSporsmal: ["", Validators.pattern("[a-zA-ZøæåØÆÅ\\-.,/? ]{10,100}")]


    });

  }

  onSubmit() {
    console.log("Spørsmålet er sendt.");
    console.log(this.Skjema);
    console.log(this.Skjema.value.dittSporsmal);
    console.log(this.Skjema.value.dinEpost);
    this.lagre();
    document.getElementById('sendt').innerHTML = "Spørsmålet ditt er nå sendt! Vi vil kontakte deg så fort vi kan. ";
  }

  lagre() {

    const etSporsmal = new InnsendteSporsmal();
    /*this.innsendteSporsmal.push(etSporsmal);
    this.sporsmalet = "";
    this.epost = "";*/
    //lagretKunde.poststed = this.skjema.value.poststed;

    etSporsmal.sporsmalet = this.Skjema.value.dittSporsmal;
    etSporsmal.epost = this.Skjema.value.dinEpost;


    //api/{KundeService}/{action}{Lagre}"

    this._http.post("api/KundeService/lagre", etSporsmal)
    .subscribe(retur => {
      this.router.navigate(['/nyttSporsmal']);
    },
      error => console.log("feilen er"+ error)
    );
    };

}

export class InnsendteSporsmal {

  spmlID: number;
  sporsmalet: String;
  epost: String;

}