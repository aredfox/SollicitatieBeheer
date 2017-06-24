import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VacatureDetailComponent } from './vacature-detail.component';

describe('VacatureDetailComponent', () => {
  let component: VacatureDetailComponent;
  let fixture: ComponentFixture<VacatureDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VacatureDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VacatureDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
