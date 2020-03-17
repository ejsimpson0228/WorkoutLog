import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { UserService } from 'src/app/_services/user.service';
import { Router } from '@angular/router';
import { IdentityUser } from 'src/app/_models/User/identity-user';
import { LoginModel } from 'src/app/_models/User/login-model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm = new FormGroup({
    username: new FormControl('', {validators: [Validators.required, this.newUser.bind(this)]}),
    email: new FormControl('', Validators.email),
    password: new FormControl('', [Validators.required, Validators.minLength(environment.passwordMinLenth)]),
    confirmPassword: new FormControl(
      '', [Validators.required, Validators.minLength(environment.passwordMinLenth)]
      )
  }, {validators: this.passwordsMatch.bind(this)});
  usernames: string[] = [];

  constructor(public userService: UserService,
              private router: Router) { }

  ngOnInit() {
    this.registerForm.reset();
  }

  onSubmit() {
    const identityUser = new IdentityUser(
      this.registerForm.value.username, this.registerForm.value.email, this.registerForm.value.password
      );
    this.userService.register(identityUser).subscribe(
      (result: any) => {
        this.loginAfterRegister(new LoginModel(identityUser.username, identityUser.password));
      },
      error => {
        alert('Error registering new user');
      }
    );
  }

  private loginAfterRegister(loginModel: LoginModel) {
    localStorage.clear();
    this.userService.login(loginModel).subscribe(
      (response: any) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['home']);
      },
      error => {
        if (error.status === 400) {
          console.log('Invalid credentials!');
        } else {
          console.log(error);
        }
      }
    );
  }

  passwordsMatch(group: FormGroup) {
    const password = group.get('password').value;
    const confirmPassword = group.get('confirmPassword').value;
    if (password !== confirmPassword) {
      return {passwordsNotSame: true};
    }
    return {};
  }

  newUser(control: FormControl) {
    if (this.usernames && this.getIndexOfString(this.usernames, control.value) >= 0) {
      return {existingUser: true};
    }
    return null;
  }

  private getIndexOfString(array: string[], value: string) {
    for (let i = 0; i < array.length; i++) {
      if (array[i].toLowerCase() === value.toLowerCase()) {
        return i;
      }
    }
    return -1;
  }

}
