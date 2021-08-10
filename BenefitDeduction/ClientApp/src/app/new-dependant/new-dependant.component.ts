import {Component, Input} from '@angular/core';
import {Dependant} from "../models/dependant";
import {DependantService} from "../services/dependant.service";

@Component({
  selector: 'app-new-dependant',
  templateUrl: './new-dependant.component.html'
})
export class NewDependantComponent {
  @Input() employeeId?: number;

  dependant: Dependant = new Dependant(0);
  constructor(private service : DependantService) {

  }
  ngOnInit() {
    this.dependant.employeeId = this.employeeId;
  }
  handleOk() {
    return this.service.newDependant(this.dependant);
  }
}
