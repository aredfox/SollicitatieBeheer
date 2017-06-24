import { Component } from '@angular/core';

@Component({
  selector: 'app-vacatures',
  templateUrl: './vacatures.component.html',
  styleUrls: ['./vacatures.component.less']
})
export class VacaturesComponent {
  vacatures: any[];
  afdelingen: string[];
  selectedAfdeling: string;
  functies: string[];
  selectedFunctie: string;

  filteredVacatures: any[];

  constructor() {
    this.vacatures = [
      { nummer: 15486, functie: 'Begeleider', afdeling: 'OOOC Potgieter', omschrijving: '' },
      { nummer: 15492, functie: 'Begeleider', afdeling: 'OOOC Jacob Jordaens', omschrijving: 'Et harum quidem rerum facilis est et expedita distinctio.' },
      { nummer: 15512, functie: 'Klusjesman', afdeling: 'Technische Dienst', omschrijving: '' },
      { nummer: 15520, functie: 'Ombuds', afdeling: 'Personeelsdienst', omschrijving: 'At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.' },
      { nummer: 15584, functie: 'Tuinman', afdeling: 'Technische Dienst', omschrijving: '' },
    ];
    this.afdelingen = this.createSelectList(this.vacatures, 'afdeling');
    this.selectedAfdeling = '*';
    this.functies = this.createSelectList(this.vacatures, 'functie');
    this.selectedFunctie = '*';

    this.filteredVacatures = this.vacatures;
  }

  onFilter() {
    this.filteredVacatures =
      this.vacatures
        .filter(v => this.selectedAfdeling === '*' || v.afdeling === this.selectedAfdeling)
        .filter(v => this.selectedFunctie === '*' || v.functie === this.selectedFunctie);
  }

  private createSelectList(array: any[], property: string): string[] {
    return this.distinct(array
      .map(x => x[property])
      .concat('*'))
      .sort();
  }

  private distinct = function (array: any[]): any[] {
    return array.reduce(function (p, c) {
      if (p.indexOf(c) < 0) p.push(c);
      return p;
    }, []);
  };
}
