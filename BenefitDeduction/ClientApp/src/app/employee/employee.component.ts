import {Component, OnInit, ViewContainerRef} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {map} from "rxjs/operators";
import {EmployeeService} from "../services/employee.service";
import {Employee} from "../models/employee";
import {NzModalService} from "ng-zorro-antd/modal";
import {NewDependantComponent} from "../new-dependant/new-dependant.component";
import {NzMessageService} from "ng-zorro-antd/message";

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  employee: Employee | undefined;

  constructor(private route: ActivatedRoute,
              private service: EmployeeService,
              private modal: NzModalService,
              private viewContainer: ViewContainerRef,
              private message: NzMessageService) {
  }

  ngOnInit(): void {
    this.route.params.pipe(map(p => p.id)).subscribe(id => {

      this.service.getEmployee(id).subscribe(result => {
        this.employee = result;
      })
    })
  }

  createNewDependantModal(): void {
    this.modal.create({
      nzTitle: "New Dependant",
      nzContent: NewDependantComponent,
      nzViewContainerRef: this.viewContainer,
      nzComponentParams: {
        employeeId: this.employee?.id
      },
      nzOkText: 'Save',
      nzOnOk: (instance) => instance.handleOk().subscribe(() => {
          this.message.create('success', `Successfully saved dependant for employee ${this.employee?.firstName} ${this.employee?.lastName}!`);
          this.service.getEmployee(this.employee?.id)
            .subscribe(result => {
              this.employee = result;
            });
        }
      )
    });
  }
}
