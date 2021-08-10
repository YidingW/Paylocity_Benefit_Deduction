import {Dependant} from "./dependant";
import {Paycheck} from "./Paycheck";

export interface Employee {
  id: number;
  firstName: string;
  lastName: string;
  numberOfDependants: number;
  dependants: Dependant[];
  paycheck: Paycheck;
}
