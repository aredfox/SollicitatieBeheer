import { Component, Input } from '@angular/core';
import { Vacature } from '../../vacature.model';

@Component({
  selector: 'app-vacature-lijst-item',
  templateUrl: './vacature-lijst-item.component.html',
  styleUrls: ['./vacature-lijst-item.component.less']
})
export class VacatureLijstItemComponent {
  @Input()
  vacature: Vacature;

  constructor() { }

}
