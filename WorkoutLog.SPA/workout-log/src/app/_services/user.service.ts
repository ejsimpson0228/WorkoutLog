import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { IdentityUser } from '../_models/User/identity-user';
import { environment } from 'src/environments/environment';
import { LoginModel } from '../_models/User/login-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  headers = new HttpHeaders({'Access-Control-Allow-Origin': '*'});
  controller = 'User/';

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  register(identityUser: IdentityUser) {
    return this.http.post(
      environment.baseUrl + this.controller + 'Register', identityUser, {headers: this.headers});
  }

  login(loginModel: LoginModel) {
    this.headers.append('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE, PATCH, OPTIONS');
    this.headers.append('Access-Control-Allow-Headers', 'X-Requested-With, content-type, Authorization');
    console.log(environment.baseUrl + 'Login');
    return this.http.post(
      environment.baseUrl + this.controller + 'Login', loginModel, {headers: this.headers});
  }
}
