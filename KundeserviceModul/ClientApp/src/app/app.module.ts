import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { TidligereStilteSporsmalComponent } from './TidligereStilteSporsmal/tidligereStilteSporsmal.component';
import { NyttSporsmalComponent } from './NyttSporsmal/nyttSporsmal.component';
import { NavigeringsMenyComponent } from './NavigeringsMeny/navigeringsMeny.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms'; 

 
@NgModule({
  declarations: [
    AppComponent,
    TidligereStilteSporsmalComponent,
    NyttSporsmalComponent,
    NavigeringsMenyComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
