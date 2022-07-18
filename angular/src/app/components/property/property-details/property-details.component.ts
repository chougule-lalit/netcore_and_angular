import { Component, OnInit } from '@angular/core';
import {CommonService} from "../../../shared/services/common.service";

@Component({
  selector: 'app-property-details',
  templateUrl: './property-details.component.html'
})
export class PropertyDetailsComponent implements OnInit {

  dataSource: any[] = [];
  constructor(private commonService: CommonService) { }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(): void {
    const input = {
      maxResultCount: 100,
      skipCount: 0,
    };
    this.commonService.postRequest('Property/fetchPropertyList', input).subscribe((result) => {
      console.log('Get Data : ', result);
      this.dataSource = result.items;
    });
  }

}
