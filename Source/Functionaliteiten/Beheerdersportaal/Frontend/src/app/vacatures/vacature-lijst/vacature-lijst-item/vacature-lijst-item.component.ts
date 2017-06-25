import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Vacature } from '../../vacature.model';

@Component({
  selector: 'app-vacature-lijst-item',
  templateUrl: './vacature-lijst-item.component.html',
  styleUrls: ['./vacature-lijst-item.component.less']
})
export class VacatureLijstItemComponent {
  @Input()
  vacature: Vacature;
  @Output()
  edit = new EventEmitter();
  @Output()
  delete = new EventEmitter();

  constructor() { }

}
