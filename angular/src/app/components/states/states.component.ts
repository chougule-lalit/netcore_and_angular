import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { CommonService } from 'src/app/shared/services/common.service';
import { StateFormComponent } from './state-form/state-form.component';

@Component({
  selector: 'app-states',
  templateUrl: './states.component.html'
})
export class StatesComponent implements OnInit {

  
  displayedColumns = ['id', 'name', 'actions'];
  dataSource: any;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private commonService: CommonService, private fb: FormBuilder, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.getData();
  }

  getData(): void {
    const input = {
      maxResultCount: 100,
      skipCount: 0,
    };
    this.commonService.postRequest('StateCity/fetchStateMasterList', input).subscribe((result) => {
      this.dataSource = result.items;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  add(): void {
    const dialogRef = this.dialog.open(StateFormComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getData();
      }
    });
  }

  edit(editData: any): void {
    const dialogRef = this.dialog.open(StateFormComponent, {
      data: editData,
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.getData();
      }
    });
  }

  delete(id: any): void {
    this.commonService.deleteRequestWithParams('StateCity/deleteState', id).subscribe((data) => {
      this.getData();
    });
  }

}
