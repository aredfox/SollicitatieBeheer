import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ObjectService } from './services/utilities/object.service';

@NgModule({
    imports: [
        CommonModule,
    ],
    providers: [
        ObjectService
    ]
})
export class SharedModule { }