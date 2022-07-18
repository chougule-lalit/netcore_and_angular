import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { CommonService } from 'src/app/shared/services/common.service';
import { CityFormComponent } from './city-form/city-form.component';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html'
})
export class CityComponent implements OnInit {

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
    this.commonService.postRequest('StateCity/fetchCityMasterList', input).subscribe((result) => {
      console.log('Get Data : ', result);
      this.dataSource = result.items;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  add(): void {
    const dialogRef = this.dialog.open(CityFormComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed after insert : ', result);
      if (result) {
        this.getData();
      }
    });
  }

  edit(editData: any): void {
    console.log('Edit Data : ', editData);
    const dialogRef = this.dialog.open(CityFormComponent, {
      data: editData,
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed after update : ', result);
      if (result) {
        this.getData();
      }
    });
  }

  delete(id: any): void {
    this.commonService.deleteRequestWithParams('StateCity/deleteCity', id).subscribe((data) => {
      console.log('Delete Resp : ', data);
      this.getData();
    });
  }

}
