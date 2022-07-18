import {Component, OnInit, ViewChild} from '@angular/core';
import {FormBuilder} from '@angular/forms';
import {MatDialog} from '@angular/material/dialog';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {CommonService} from 'src/app/shared/services/common.service';
import {PropertyFormComponent} from './property-form/property-form.component';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html'
})
export class PropertyComponent implements OnInit {
  displayedColumns = ['id', 'propertyOwnerName', 'propertyBuyerName', 'propertyType', 'propertyStatus', 'cityName', 'pincode', 'actions'];
  dataSource: any;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  selectedPropertyType!: string;
  selectedPropertyStatus!: string;
  propertyStatusHolder: any[] = [];
  propertyTypeHolder: any[] = [];
  selectedCity!: string;
  cityDropdownHolder: any[] = [];

  constructor(private commonService: CommonService, private fb: FormBuilder, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.getPropertyStatus();
    this.getPropertyType();
    this.getCityDropdown();
    this.loadData();
  }

  fetchData(): void {
    this.getData();
  }

  getPropertyStatus(): void {
    this.commonService.getRequest('Property/getPropertyStatus').subscribe((result) => {
      this.propertyStatusHolder = result;
      console.log('PropertyStatusHolder : ', this.propertyStatusHolder);

    });
  }

  getPropertyType(): void {
    this.commonService.getRequest('Property/getPropertyType').subscribe((result) => {
      this.propertyTypeHolder = result;
      console.log('PropertyTypeHolder : ', this.propertyTypeHolder);
    });
  }

  getCityDropdown(): void {
    this.commonService.getRequest('StateCity/getCityDropdown').subscribe((result) => {
      this.cityDropdownHolder = result;
      console.log('PropertyTypeHolder : ', this.propertyTypeHolder);
    });
  }

  loadData(): void {
    const input = {
      maxResultCount: 100,
      skipCount: 0,
    };
    this.commonService.postRequest('Property/fetchPropertyList', input).subscribe((result) => {
      console.log('Get Data : ', result);
      this.dataSource = result.items;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }
  getData(): void {
    const input = {
      maxResultCount: 100,
      skipCount: 0,
      cityId: this.selectedCity,
      propertyTypeId: this.selectedPropertyType,
      propertyStatusId: this.selectedPropertyStatus
    };
    this.commonService.postRequest('Property/fetchPropertyList', input).subscribe((result) => {
      console.log('Get Data : ', result);
      this.dataSource = result.items;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  add(): void {
    const dialogRef = this.dialog.open(PropertyFormComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed after insert : ', result);
      if (result) {
        this.getData();
      }
    });
  }

  edit(editData: any): void {
    console.log('Edit Data : ', editData);
    const dialogRef = this.dialog.open(PropertyFormComponent, {
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
    this.commonService.deleteRequestWithId('Property/delete', id).subscribe((data) => {
      console.log('Delete Resp : ', data);
      this.getData();
    });
  }


}
