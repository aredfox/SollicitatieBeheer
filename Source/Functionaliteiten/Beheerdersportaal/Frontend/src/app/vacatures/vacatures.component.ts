import { Component } from '@angular/core';

@Component({
  selector: 'app-vacatures',
  templateUrl: './vacatures.component.html',
  styleUrls: ['./vacatures.component.less']
})
export class VacaturesComponent {
  vacatures: any[];

  constructor() {
    this.vacatures = [
      { nummer: 15486, functie: 'Begeleider', afdeling: 'OOOC Potgieter', omschrijving: '' },
      { nummer: 15492, functie: 'Begeleider', afdeling: 'OOOC Jacob Jordaens', omschrijving: 'Et harum quidem rerum facilis est et expedita distinctio.' },
      { nummer: 15512, functie: 'Klusjesman', afdeling: 'Technische Dienst', omschrijving: '' },
      { nummer: 15520, functie: 'Ombuds', afdeling: 'Personeelsdienst', omschrijving: 'At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.' }
    ];
  }

}
