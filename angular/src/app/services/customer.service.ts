import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from '../../environments/environment';
import { Customer } from '../interface/customer'

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private apiUrl = environment.base_url;

  constructor(private http: HttpClient) { }

  getTasks(): Observable<Customer[]> {
    let getUrl = this.apiUrl + 'Customer/getAllCustomers';
    return this.http.get<Customer[]>(getUrl);
  }
}
