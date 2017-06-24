import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RootComponent } from './shared/root/root.component';

import { LayoutModule } from './shared/layout/layout.module';
import { VacaturesModule } from './vacatures/vacatures.module';

@NgModule({
  declarations: [
    RootComponent
  ],
  imports: [
    BrowserModule,
    LayoutModule,
    VacaturesModule
  ],
  bootstrap: [
    RootComponent
  ]
})
export class AppModule { }
