import {Pay} from "./Pay";

export interface Paycheck {
  totalPay: number;
  totalPayAfterCost: number;
  employeeBenefitCost: number;
  dependantBenefitCost: number;
  totalCost: number;
  pays: Pay[];
}
