import { Injectable } from '@angular/core';
import {Employee} from "../models/employee";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private apiUrl = "https://localhost:5001/Employee"
  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }

  getEmployee(id: number | any): Observable<Employee> {
    return this.http.get<Employee>(this.apiUrl + '/' + id);
  }
}
