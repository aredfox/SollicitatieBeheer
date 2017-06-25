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
  vacatureEdit = new EventEmitter<Vacature>();
  @Output()
  vacatureDeleted = new EventEmitter<Vacature>();

  constructor() { }

  onEdit(vacature: Vacature) {
    this.vacatureEdit.emit(vacature);
  }
  onDelete(vacature: Vacature) {
    this.vacatureDeleted.emit(vacature);
  }
}
