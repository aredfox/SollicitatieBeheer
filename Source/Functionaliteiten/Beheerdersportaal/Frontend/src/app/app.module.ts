import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RootComponent } from './root/root.component';

import { SharedModule } from './shared/shared.module';
import { LayoutModule } from './layout/layout.module';
import { VacaturesModule } from './vacatures/vacatures.module';

@NgModule({
  declarations: [
    RootComponent
  ],
  imports: [
    BrowserModule,
    SharedModule,
    LayoutModule,
    VacaturesModule
  ],
  bootstrap: [
    RootComponent
  ]
})
export class AppModule { }
