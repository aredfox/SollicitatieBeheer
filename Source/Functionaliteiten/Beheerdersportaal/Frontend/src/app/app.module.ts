import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { SharedModule, DataTableModule, Dropdown, SelectItem } from 'primeng/primeng';

import { RootComponent } from './shared/root/root.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { FooterComponent } from './shared/layout/footer/footer.component';

@NgModule({
  declarations: [
    RootComponent,
    HeaderComponent,
    FooterComponent,
    Dropdown
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    DataTableModule
  ],
  providers: [],
  bootstrap: [RootComponent]
})
export class AppModule { }
