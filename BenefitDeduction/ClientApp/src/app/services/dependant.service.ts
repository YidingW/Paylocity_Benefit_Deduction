import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Employee} from "../models/employee";
import {Dependant} from "../models/dependant";

@Injectable({
  providedIn: 'root'
})
export class DependantService {

  private apiUrl = "https://localhost:5001/Dependant"
  constructor(private http: HttpClient) { }

  newDependant(dependant: Dependant) {
    return this.http.post(this.apiUrl, dependant);
  }

}
