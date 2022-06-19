import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  constructor(private http: HttpClient) {}
  baseURL = environment.base_url;
  fetchUserList(person: any): Observable<any> {
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(person);
    console.log(body);
    return this.http.post(this.baseURL + 'UserMaster/fetchUserList', body, {
      headers: headers,
    });
  }

  createOrUpdate(person: any): Observable<any> {
    const headers = { 'content-type': 'application/json' };
    const body = JSON.stringify(person);
    console.log(body);
    return this.http.post(this.baseURL + 'UserMaster/createOrUpdate', body, {
      headers: headers,
    });
  }

  deleteuser(id: any): Observable<any> {
    const headers = { 'content-type': 'application/json' };
    return this.http.delete(this.baseURL + 'UserMaster/delete?id=' + id);
  }
}
