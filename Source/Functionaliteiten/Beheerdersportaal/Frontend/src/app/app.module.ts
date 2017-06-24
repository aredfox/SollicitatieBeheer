import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RootComponent } from './shared/root/root.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { FooterComponent } from './shared/layout/footer/footer.component';

import { VacaturesModule } from './vacatures/vacatures.module';

@NgModule({
  declarations: [
    RootComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    VacaturesModule
  ],
  bootstrap: [
    RootComponent
  ]
})
export class AppModule { }
