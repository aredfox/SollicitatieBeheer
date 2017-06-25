import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Vacature } from '../vacature.model';
import { SelectList } from '../../shared/models/select-list.model';

@Component({
  selector: 'app-vacature-detail',
  templateUrl: './vacature-detail.component.html',
  styleUrls: ['./vacature-detail.component.less']
})
export class VacatureDetailComponent {
  @Input()
  vacature: Vacature;
  @Input()
  afdelingen: string[];
  @Input()
  functies: string[];

  @Output()
  cancelled = new EventEmitter();
  @Output()
  saved = new EventEmitter<Vacature>();

  constructor() {
  }

  onCancel() {
    this.cancelled.emit();
  }
  onSave() {
    this.saved.emit(this.vacature);
  }
}
