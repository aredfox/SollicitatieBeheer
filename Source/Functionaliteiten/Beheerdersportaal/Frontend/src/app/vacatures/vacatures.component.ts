import { Component } from '@angular/core';
import { Vacature } from './vacature.model';
import { SelectList } from '../shared/models/select-list.model';
import { ObjectService } from '../shared/services/utilities/object.service';

@Component({
  selector: 'app-vacatures',
  templateUrl: './vacatures.component.html',
  styleUrls: ['./vacatures.component.less']
})
export class VacaturesComponent {
  vacatures: Vacature[];

  filteredVacatures: Vacature[];
  zoekparameter: string;
  vacatureProperties: string[];
  afdelingen: SelectList<string>;
  functies: SelectList<string>;

  constructor(private objectService: ObjectService) {
    this.vacatures = [
      { nummer: 15486, functie: 'Begeleider', afdeling: 'OOOC Potgieter', omschrijving: '' },
      { nummer: 15492, functie: 'Begeleider', afdeling: 'OOOC Jacob Jordaens', omschrijving: 'Et harum quidem rerum facilis est et expedita distinctio.' },
      { nummer: 15512, functie: 'Klusjesman', afdeling: 'Technische Dienst', omschrijving: '' },
      { nummer: 15520, functie: 'Ombuds', afdeling: 'Personeelsdienst', omschrijving: 'At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.' },
      { nummer: 15584, functie: 'Tuinman', afdeling: 'Technische Dienst', omschrijving: '' },
    ];

    this.afdelingen = SelectList.createSelectList(this.vacatures, v => v.afdeling);
    this.functies = SelectList.createSelectList(this.vacatures, v => v.functie);

    this.filteredVacatures = this.vacatures;
  }

  onFilter() {
    this.filteredVacatures =
      this.vacatures
        .filter(v => this.afdelingen.selectedItem === '*' || v.afdeling === this.afdelingen.selectedItem)
        .filter(v => this.functies.selectedItem === '*' || v.functie === this.functies.selectedItem)
        .filter(v => this.searchFilter(v, this.zoekparameter, [v => v.nummer, v => v.afdeling, v => v.functie, v => v.omschrijving]));
  }
  onFilterReset() {
    this.afdelingen.selectedItem = '*';
    this.functies.selectedItem = '*';
    this.zoekparameter = '';
    this.onFilter();
  }

  private searchFilter(vacature: Vacature, q: string, propertySelectors: ((x: Vacature) => any | string)[]): boolean {
    if (q === '') return true;

    q = q.trim().toLowerCase();

    if (!this.vacatureProperties) {
      this.vacatureProperties = this.objectService.extractPropertyNames(propertySelectors);
    }

    for (let property of this.vacatureProperties) {
      if (vacature[property].toString().toLowerCase().indexOf(q) >= 0) {
        return true;
      }
    }

    return false;
  }
}
