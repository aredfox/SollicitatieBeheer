import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ObjectService } from './services/utilities/object.service';
import { SearchService } from './services/utilities/search.service';
import { VacaturesDataService } from './services/vacatures.data.service';

@NgModule({
    imports: [
        CommonModule,
    ],
    providers: [
        ObjectService,
        SearchService,
        VacaturesDataService
    ]
})
export class SharedModule { }