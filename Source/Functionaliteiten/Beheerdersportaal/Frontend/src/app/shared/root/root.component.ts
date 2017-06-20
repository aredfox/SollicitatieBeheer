import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.less']
})
export class RootComponent {
  vacatures: any[];
  columns: any[];
  vacatureFuncties: string[];

  ngOnInit() {
    this.vacatures = [
      { nummer: 15486, functie: 'Begeleider', afdeling: 'OOOC Potgieter' },
      { nummer: 15492, functie: 'Begeleider', afdeling: 'OOOC Jacob Jordaens' },
      { nummer: 15512, functie: 'Klusjesman', afdeling: 'Technische Dienst' },
      { nummer: 15520, functie: 'Ombuds', afdeling: 'Personeelsdienst' }
    ];
    this.vacatureFuncties = this.vacatures.map(v => v.functie);
  }
}
