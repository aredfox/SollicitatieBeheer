import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { VacaturesComponent } from './vacatures.component';
import { VacatureLijstComponent } from './vacature-lijst/vacature-lijst.component';
import { VacatureLijstItemComponent } from './vacature-lijst/vacature-lijst-item/vacature-lijst-item.component';
import { VacatureDetailComponent } from './vacature-detail/vacature-detail.component';


@NgModule({
    declarations: [
        VacaturesComponent,
        VacatureLijstComponent,
        VacatureLijstItemComponent,
        VacatureDetailComponent
    ],
    imports: [
        CommonModule,
        FormsModule
    ],
    exports: [
        VacaturesComponent
    ]
})
export class VacaturesModule { }