import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessRightComponent } from './access-right.component';

describe('AccessRightComponent', () => {
  let component: AccessRightComponent;
  let fixture: ComponentFixture<AccessRightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccessRightComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
