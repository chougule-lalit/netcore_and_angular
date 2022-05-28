import { Component, OnInit } from '@angular/core';
import { Customer } from './interface/customer';
import { CustomerService } from './services/customer.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'angular';
  customers: Customer[] = [];
  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.getCustomers();
    console.log(this.customers);
  }

  getCustomers() {
    this.customerService.getTasks().subscribe(result => {
      this.customers = result;
    })
  }
}
