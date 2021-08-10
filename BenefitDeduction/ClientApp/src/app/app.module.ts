import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NzLayoutModule} from "ng-zorro-antd/layout";
import {NzBreadCrumbModule} from "ng-zorro-antd/breadcrumb";
import {NzMenuModule} from "ng-zorro-antd/menu";
import { EmployeesComponent } from './employees/employees.component';
import {NzDividerModule} from "ng-zorro-antd/divider";
import {NzTableModule} from "ng-zorro-antd/table";
import {NzIconModule} from "ng-zorro-antd/icon";
import {NzButtonModule} from "ng-zorro-antd/button";
import { EmployeesHeaderComponent } from './employees-header/employees-header.component';
import {NzPageHeaderModule} from "ng-zorro-antd/page-header";
import {NzDescriptionsModule} from "ng-zorro-antd/descriptions";
import { EmployeeComponent } from './employee/employee.component';
import {NzStatisticModule} from "ng-zorro-antd/statistic";
import {NzGridModule} from "ng-zorro-antd/grid";
import { NewDependantComponent } from './new-dependant/new-dependant.component';
import {NzModalModule} from "ng-zorro-antd/modal";
import {NzFormModule} from "ng-zorro-antd/form";
import {NzInputModule} from "ng-zorro-antd/input";
import {NzRadioModule} from "ng-zorro-antd/radio";
import {NzMessageModule} from "ng-zorro-antd/message";

registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    EmployeesHeaderComponent,
    EmployeeComponent,
    NewDependantComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NzLayoutModule,
    NzBreadCrumbModule,
    NzMenuModule,
    NzDividerModule,
    NzTableModule,
    NzIconModule,
    NzButtonModule,
    NzPageHeaderModule,
    NzDescriptionsModule,
    NzStatisticModule,
    NzGridModule,
    NzModalModule,
    NzFormModule,
    NzInputModule,
    NzRadioModule,
    NzMessageModule
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US }],
  bootstrap: [AppComponent]
})
export class AppModule { }
