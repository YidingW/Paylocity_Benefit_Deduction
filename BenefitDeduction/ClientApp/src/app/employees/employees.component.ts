import { Component } from '@angular/core';
import {Employee} from "../models/employee";
import {EmployeeService} from "../services/employee.service";

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {
  listOfEmployee: Employee[] = [];

  constructor(private dataService: EmployeeService) {
  }
  ngOnInit() {
    this.dataService.getEmployees()
      .subscribe(value => {
        this.listOfEmployee = value;
    })
  }

  gotoEmployee() {
    return;
  }
}
