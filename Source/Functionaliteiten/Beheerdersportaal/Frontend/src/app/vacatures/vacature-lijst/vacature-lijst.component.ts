import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Vacature } from '../vacature.model';

@Component({
  selector: 'app-vacature-lijst',
  templateUrl: './vacature-lijst.component.html',
  styleUrls: ['./vacature-lijst.component.less']
})
export class VacatureLijstComponent {
  @Input()
  vacatures: Vacature[];
  @Output()
  vacatureSelected = new EventEmitter<Vacature>();

  constructor() { }

  onSelect(vacature: Vacature) {
    this.vacatureSelected.emit(vacature);
  }
}
