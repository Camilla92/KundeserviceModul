import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  //selector: 'app-root', denne gjør ikke noe da det er routing som gjelder
  templateUrl: './nyttSporsmal.component.html'
})
export class NyttSporsmalComponent {
  Skjema: FormGroup;
  constructor(private fb: FormBuilder)
  {
    this.Skjema = fb.group({

      dinEpost: ["", Validators.pattern("[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}")],
      dittSporsmal: ["Spørsmålet må være mellom 10 og 300 tegn.", Validators.pattern("[a-zA-Z .,\?\-]{10,50}")]


    });

  }

  onSubmit() {
    console.log("Spørsmålet er sendt.");
    console.log(this.Skjema);
    console.log(this.Skjema.value.dittSporsmal);
    console.log(this.Skjema.value.dinEpost);
  }
}