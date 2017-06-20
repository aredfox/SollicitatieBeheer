import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { RootComponent } from './shared/root/root.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { FooterComponent } from './shared/layout/footer/footer.component';

@NgModule({
  declarations: [
    RootComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule    
  ],
  providers: [],
  bootstrap: [RootComponent]
})
export class AppModule { }
