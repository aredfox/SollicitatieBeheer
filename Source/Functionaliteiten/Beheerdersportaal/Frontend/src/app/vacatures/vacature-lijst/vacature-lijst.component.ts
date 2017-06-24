import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-vacature-lijst',
  templateUrl: './vacature-lijst.component.html',
  styleUrls: ['./vacature-lijst.component.less']
})
export class VacatureLijstComponent {
  @Input()
  vacatures: any[];

  constructor() { }
}
