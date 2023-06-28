import { Injectable } from '@angular/core';
import { Person } from './person';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  
  sendUser(pessoinha : Person) {
    return this.http.post('http://localhost:5283/user/login/', pessoinha)
  };

  registerUser(pessoinha : Person) {
    return this.http.post('http://localhost:5283/user/addUser/', pessoinha)
  }
}