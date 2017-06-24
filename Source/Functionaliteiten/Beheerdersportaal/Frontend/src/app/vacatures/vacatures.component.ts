import { Component } from '@angular/core';
import { Vacature } from './vacature.model';
import { SelectList } from '../shared/models/select-list.model';
import { IPropertySelector } from '../shared/models/property-selector.model';
import { ObjectService } from '../shared/services/utilities/object.service';
import { SearchService } from '../shared/services/utilities/search.service';

@Component({
  selector: 'app-vacatures',
  templateUrl: './vacatures.component.html',
  styleUrls: ['./vacatures.component.less']
})
export class VacaturesComponent {
  vacatures: Vacature[];

  filteredVacatures: Vacature[];
  zoekparameter: string = '';
  vacatureProperties: string[];
  afdelingen: SelectList<string>;
  functies: SelectList<string>;

  constructor(
    private objectService: ObjectService, private searchService: SearchService) {
    this.vacatures = [
      { nummer: 15486, functie: 'Begeleider (m/v)', afdeling: 'OOOC Potgieter', omschrijving: '' },
      { nummer: 15492, functie: 'Begeleider (m/v)', afdeling: 'OOOC Jacob Jordaens', omschrijving: 'Et harum quidem rerum facilis est et expedita distinctio.' },
      { nummer: 15512, functie: 'Klusjesman', afdeling: 'Technische Dienst', omschrijving: '' },
      { nummer: 15520, functie: 'Ombuds', afdeling: 'Personeelsdienst', omschrijving: 'At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident.' },
      { nummer: 15584, functie: 'Tuinman', afdeling: 'Technische Dienst', omschrijving: '' },
      { nummer: 15624, functie: 'Nachtbegeleider (m/v)', afdeling: 'OOOC Potgieter', omschrijving: 'Je staat in voor de begeleiding van minderjarigen in onze orthopedagogische residentie volgens een volcontinu systeem.' },
      { nummer: 15637, functie: 'Begeleider (m/v)', afdeling: 'OOOC Jacob Jordaens', omschrijving: 'Et harum quidem rerum facilis est et expedita distinctio.' },
      { nummer: 15639, functie: 'Schoonmaak', afdeling: 'Technische Dienst', omschrijving: '' },
      { nummer: 15658, functie: 'Maatschappelijk Assistent (m/v)', afdeling: 'OOOC Harmonie', omschrijving: 'Je concentreert je binnen de voorziening op het thuismilieu van de jongere. Via gesprekken, huisbezoeken en vragenlijsten ga je samen met het cliëntsysteem op zoek naar hun sterke punten en hun werkpunten. Je legt ook contacten met significante derden (vorige hulpverlening, familieleden, OCMW,…). Je bundelt al deze informatie en legt deze samen met de informatie van de andere leden van het Multidisciplinair team. Je werkt mee aan het proces van adviesvorming en kan daarna jouw informatie in een degelijk diagnostisch verslag formuleren. Binnen de voorziening heb je een verantwoordelijke functie op vlak van administratie, dossierkennis, -opbouw en –beheer. Je bent ook verantwoordelijk voor de opbouw van contacten tussen de jongere en zijn gezin binnen de residentiele dossiers.' },
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

  private searchFilter(vacature: Vacature, searchTerm: string, propertySelectors: IPropertySelector<Vacature>[]): boolean {
    if (!this.vacatureProperties) {
      this.vacatureProperties = this.objectService.extractPropertyNames(propertySelectors);
    }
    return this.searchService.containsInAny(vacature, searchTerm, this.vacatureProperties);
  }
}
