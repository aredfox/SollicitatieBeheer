import { Component } from '@angular/core';
import { Vacature } from './vacature.model';

@Component({
  selector: 'app-vacatures',
  templateUrl: './vacatures.component.html',
  styleUrls: ['./vacatures.component.less']
})
export class VacaturesComponent {
  vacatures: Vacature[];

  filteredVacatures: Vacature[];
  afdelingen: string[];
  selectedAfdeling: string;
  functies: string[];
  selectedFunctie: string;

  constructor() {
    this.vacatures = [
      { nummer: 15486, functie: 'Begeleider', afdeling: 'OOOC Potgieter', omschrijving: '' },
      { nummer: 15492, functie: 'Begeleider', afdeling: 'OOOC Jacob Jordaens', omschrijving: 'Et harum quidem rerum facilis est et expedita distinctio.' },
      { nummer: 15512, functie: 'Klusjesman', afdeling: 'Technische Dienst', omschrijving: '' },
      { nummer: 15520, functie: 'Ombuds', afdeling: 'Personeelsdienst', omschrijving: 'At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.' },
      { nummer: 15584, functie: 'Tuinman', afdeling: 'Technische Dienst', omschrijving: '' },
    ];
    this.afdelingen = this.createSelectList(this.vacatures, v => v.afdeling);
    this.selectedAfdeling = '*';
    this.functies = this.createSelectList(this.vacatures, v => v.functie);
    this.selectedFunctie = '*';

    this.filteredVacatures = this.vacatures;
  }

  onFilter() {
    this.filteredVacatures =
      this.vacatures
        .filter(v => this.selectedAfdeling === '*' || v.afdeling === this.selectedAfdeling)
        .filter(v => this.selectedFunctie === '*' || v.functie === this.selectedFunctie);
  }

  private createSelectList<T, TResult>(array: T[], propertySelector: (x: T) => TResult | string): TResult[] {
    return this.distinct(array
      .map(propertySelector)
      .concat('*'))
      .sort();
  }

  private distinct(array: any[]): any[] {
    return array.reduce((p, c) => {
      if (p.indexOf(c) < 0) p.push(c);
      return p;
    }, []);
  };
}
