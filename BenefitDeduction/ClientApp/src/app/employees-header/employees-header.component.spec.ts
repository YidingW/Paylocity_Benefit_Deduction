import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { EmployeesHeaderComponent } from './employees-header.component';

describe('EmployeesHeaderComponent', () => {
  let component: EmployeesHeaderComponent;
  let fixture: ComponentFixture<EmployeesHeaderComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeesHeaderComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeesHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
