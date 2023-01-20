import { ViewEncapsulation, Component, ViewChild, OnInit, ElementRef } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ReportService } from './report.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { T } from '@angular/cdk/keycodes';
import { UtilitiesService } from 'app/Services/utilities.service';
import { LoaderService } from '../../../Services/loader.service';
import * as XLSX from 'xlsx';
import { DatePipe } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { DateAdapter } from '@angular/material/core';

import {

    FormControl,

    NgForm,
    FormArray
} from '@angular/forms';
@Component({
    selector: 'app-reports',
    templateUrl: './report.component.html',
    styleUrls: ['./report.component.scss'],
    providers: [DatePipe],
    //encapsulation: ViewEncapsulation.None
})
export class ReportComponent implements OnInit {
    horizontalStepperForm: FormGroup;
    constructor(public reportService: ReportService, private _matDialog: MatDialog, private dateAdapter: DateAdapter<Date>,
        private utilitiesService: UtilitiesService, public spinner: LoaderService, public datepipe: DatePipe, private _formBuilder: FormBuilder) {

        this.dateAdapter.setLocale('en-GB'); //dd/MM/yyyy
    }

    patientsappointments: any = [];
    displayedColumns: string[] = ['Patient ARCID', 'SL', 'Patient', 'Mobile', 'Service Name', 'Last Visit', 'Visit Count', 'Payment', 'ModeofPayment'];
    @ViewChild(MatSort) sort: MatSort;
    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild('TABLE') table: ElementRef;
    searchKey: string;
    loginDetails: any;
    roleID: any;
    registrationID: any;
    patientList: any = [];
    patientTotalAmount: number = 0;

    Screen: any = 1;

    patientName: string;
    PatientID: any;
    AppointmentID: any;
    vitalsID: any;
    complaintsXML: any = [];
    items: FormArray;
    medicationitems: FormArray;
    appt: any = {};
    //appFromDate: string;
    // appToDate: string;
    appFromDate: Date;
    appToDate: Date;


    ExportTOExcel() {

        const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(this.table.nativeElement);
        const wb: XLSX.WorkBook = XLSX.utils.book_new();
        XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');

        //let bur=XLSX.write(wb,{cellStyles:})


        /* save to file */
        XLSX.writeFile(wb, 'SheetJS.xlsx');

    }


    ngOnInit(): void {
        debugger;
        this.loginDetails = JSON.parse(localStorage.getItem('loginDetails'));
        if (this.loginDetails) {
            this.roleID = this.loginDetails.roleID;
            this.registrationID = this.loginDetails.registrationID;
        }
        const dateforToday = new Date();
        this.appFromDate = new Date();
        this.appToDate = new Date();
        this.GetPatientData(this.appFromDate, this.appToDate);
        // this.appFromDate = this.datepipe.transform(dateforToday, 'd MMM yyyy');
        //  this.appToDate = this.datepipe.transform(dateforToday, 'd MMM yyyy');
        //  this.GetAllAppointments();
        // Horizontal stepper form

    }
    // public onDateChange(event: MatDatepickerInputEvent<Date>): void {
    //     console.log('Teste', event.value);
    //   }
    onDateChange(data) {
        debugger;
        //var s=data
        // this.appFromDate= this.datepipe.transform(data.value, 'dd/MM/yyyy');
        //this.datepipe.transform(from, 'd MMM yyyy');
    }

    GetPatientData(from, to) {
        //this.appt.FromDate=from;
        // this.appt.ToDate=to;

        this.appt.FromDate = this.datepipe.transform(from, 'd MMM yyyy');
        this.appt.ToDate = this.datepipe.transform(to, 'd MMM yyyy');

        // let arr = [];
        // arr.push({ fromDate: from })
        // arr.push({ toDate: to })

        debugger;
        this.reportService.getReportPatientList(this.appt).subscribe(
            (data) => {
                debugger;
                if (data) {
                    if (this.roleID == 2) {
                        this.patientsappointments = data;
                        this.patientsappointments = this.patientsappointments.filter((a) => a.doctorID == this.registrationID);
                    }
                    else {
                        this.patientsappointments = data;
                    }
                    this.patientList = data;

                    this.patientsappointments = new MatTableDataSource(this.patientsappointments);                   
                    this.patientsappointments.sort = this.sort;
                    this.patientsappointments.paginator = this.paginator;
                    this.totalPrice();
                }
            },

            () => {

            }

        );

    }

    totalPrice() {
        let total = Number(0);
        for (let data of this.patientList) {
            total =total+ Number(data.payment);
        }      
        this.patientTotalAmount=Number(total);  
    }
    // GetAllAppointments() {

    //     this.reportService.getReportPatientList().subscribe(
    //         (data) => {
    //             debugger;
    //             if (data) {
    //                 if(this.roleID == 2)
    //                 this.patientsappointments = data.filter((a) => a.doctorID == this.registrationID);
    //                 else
    //                 this.patientsappointments = data;
    //             }

    //             // this.patientsappointments = this.patientsappointments.filter(
    //             //     (thing, i, arr) => arr.findIndex(t => t.mobile === thing.mobile && t.patient === thing.patient && t.serviceDate === thing.serviceDate)  === i
    //             // );    
    //             this.patientsappointments = this.patientsappointments.filter(
    //                 (thing, i, arr) => arr.findIndex(t => t.mobile === thing.mobile && t.patient === thing.patient )  === i
    //             );            
    //             this.patientsappointments = new MatTableDataSource(this.patientsappointments);
    //            //this.sort.sort()
    //             this.patientsappointments.sort = this.sort;
    //            // this.sort.active='appointmentID';
    //           //  this.sort.direction = 'desc';




    //             // const sortState: MatSort = {active: 'appointmentID', direction: 'desc'};
    //             // this.sort.active = sortState.active;
    //             // this.sort.direction = sortState.direction;
    //             // this.sort.sortChange.emit(sortState);

    //             this.patientsappointments.paginator = this.paginator;
    //         },

    //         () => {

    //         }

    //     );
    // }
    onSearchClear() {
        this.searchKey = "";
        this.applyFilter();
    }
    applyFilter() {
        this.patientsappointments.filter = this.searchKey.trim().toLowerCase();
    }



    appoinmentLink() {
        //this._router.navigate(['/Appointments']);
        this.Screen = 1;
    }



}
