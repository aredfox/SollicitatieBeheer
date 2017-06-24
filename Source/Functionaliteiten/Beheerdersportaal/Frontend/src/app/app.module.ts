import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { RootComponent } from './shared/root/root.component';
import { HeaderComponent } from './shared/layout/header/header.component';
import { FooterComponent } from './shared/layout/footer/footer.component';
import { VacaturesComponent } from './vacatures/vacatures.component';
import { VacatureLijstComponent } from './vacatures/vacature-lijst/vacature-lijst.component';
import { VacatureLijstItemComponent } from './vacatures/vacature-lijst/vacature-lijst-item/vacature-lijst-item.component';
import { VacatureDetailComponent } from './vacatures/vacature-detail/vacature-detail.component';

@NgModule({
  declarations: [
    RootComponent,
    HeaderComponent,
    FooterComponent,
    VacaturesComponent,
    VacatureLijstComponent,
    VacatureLijstItemComponent,
    VacatureDetailComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [RootComponent]
})
export class AppModule { }
