import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpModule, JsonpModule } from '@angular/http';

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
    HttpModule,
    JsonpModule,
    SharedModule,
    LayoutModule,
    VacaturesModule
  ],
  bootstrap: [
    RootComponent
  ]
})
export class AppModule { }
