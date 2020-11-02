import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TidligereStilteSporsmalComponent } from './TidligereStilteSporsmal/tidligereStilteSporsmal.component';
import { NyttSporsmalComponent } from './NyttSporsmal/nyttSporsmal.component';
import { ReactiveFormsModule } from '@angular/forms'; 
const appRoots: Routes = [
  { path: 'nyttSporsmal', component: NyttSporsmalComponent },
  { path: '', component: TidligereStilteSporsmalComponent },
 
  
]

@NgModule({
  imports: [
    RouterModule.forRoot(appRoots),
    ReactiveFormsModule
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
