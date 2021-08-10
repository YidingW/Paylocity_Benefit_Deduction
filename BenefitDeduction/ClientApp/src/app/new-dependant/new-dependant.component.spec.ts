import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { NewDependantComponent } from './new-dependant.component';

describe('NewDependantComponent', () => {
  let component: NewDependantComponent;
  let fixture: ComponentFixture<NewDependantComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ NewDependantComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewDependantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
