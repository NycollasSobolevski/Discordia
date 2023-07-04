import { Injectable } from '@angular/core';
import { Jwt, LoginData } from './person';
import { Person } from './Model'
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  
  sendUser(pessoinha : LoginData) {
    return this.http.post<Jwt>('http://localhost:5283/user/login/', pessoinha)
  };

  registerUser(pessoinha : Person) {
    return this.http.post('http://localhost:5283/user/addUser/', pessoinha)
  }
}
