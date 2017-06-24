import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VacatureLijstItemComponent } from './vacature-lijst-item.component';

describe('VacatureLijstItemComponent', () => {
  let component: VacatureLijstItemComponent;
  let fixture: ComponentFixture<VacatureLijstItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VacatureLijstItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VacatureLijstItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
