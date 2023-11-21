import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleModifyComponent } from './vehicle-modify.component';

describe('VehicleModifyComponent', () => {
  let component: VehicleModifyComponent;
  let fixture: ComponentFixture<VehicleModifyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VehicleModifyComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(VehicleModifyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
