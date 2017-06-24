import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VacatureLijstComponent } from './vacature-lijst.component';

describe('VacatureLijstComponent', () => {
  let component: VacatureLijstComponent;
  let fixture: ComponentFixture<VacatureLijstComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VacatureLijstComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VacatureLijstComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
