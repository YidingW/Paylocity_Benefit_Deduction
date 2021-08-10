import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {EmployeesComponent} from "./employees/employees.component";
import {EmployeeComponent} from "./employee/employee.component";

const routes: Routes = [
  {path: 'employees', component: EmployeesComponent, data: {breadcrumb: 'All Employees'}},
  {path: 'employee/:id', component: EmployeeComponent, data: {breadcrumb: 'Employee'} },
  {path: '', redirectTo: '/employees', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
