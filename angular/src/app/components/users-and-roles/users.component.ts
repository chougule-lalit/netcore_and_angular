import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { CommonService } from '../../shared/services/common.service';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { CreateAndUpdateUserComponent } from './create-and-update-user/create-and-update-user.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit {
  displayedColumns = ['id', 'firstName', 'lastName', 'email', 'phone', 'role', 'actions'];
  dataSource: any;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private commonService: CommonService, private fb: FormBuilder, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.getUserList();
  }

  getUserList(): void {
    const input = {
      maxResultCount: 100,
      skipCount: 0,
    };
    this.commonService.fetchUserList(input).subscribe((result) => {
      console.log('fetchUserList : ', result);
      this.dataSource = result.items;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  add(): void {
    const dialogRef = this.dialog.open(CreateAndUpdateUserComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed after insert : ', result);
      if(result){
        this.getUserList();
      }
    });
  }

  edit(editData: any): void {
    console.log('Edit Data : ', editData);
    const dialogRef = this.dialog.open(CreateAndUpdateUserComponent, {
      data: editData,
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed after update : ', result);
      if(result){
        this.getUserList();
      }
    });
  }

  deleteUser(id: any): void {
    this.commonService.deleteUser(id).subscribe((data) => {
      console.log('User Delete Resp : ', data);
      this.getUserList();
    });
  }
}


