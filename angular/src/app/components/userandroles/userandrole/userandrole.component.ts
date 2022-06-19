import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { CommonService } from '../../common.service';

@Component({
  selector: 'app-userandrole',
  templateUrl: './userandrole.component.html',
  styleUrls: ['./userandrole.component.css'],
})
export class UserandroleComponent implements OnInit {
  displayedColumns = [
    'id',
    'firstName',
    'lastName',
    'email',
    'phone',
    'actions',
  ];
  dataSource: any;

  constructor(private commonService: CommonService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.getUserlist();
  }

  getUserlist() {
    let input = {
      maxResultCount: 100,
      skipCount: 0,
    };
    this.commonService.fetchUserList(input).subscribe((data) => {
      console.log(data);
      this.dataSource = data.items;
    });
  }

  add() {}
  edit(input: any) {}

  deleteItem(id: any) {
    this.commonService.deleteuser(id).subscribe((data) => {
      console.log(data);
      this.getUserlist();
    });
  }
}
