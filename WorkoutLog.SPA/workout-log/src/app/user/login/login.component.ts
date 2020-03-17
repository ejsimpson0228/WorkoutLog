import { Component, OnInit } from '@angular/core';
import { NgForm, Validators, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../user.component.css']
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });

  constructor(private service: UserService, private router: Router) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null) {
      this.router.navigateByUrl('/home');
    }
  }

  onSubmit() {
    this.service.login(this.loginForm.value).subscribe(
      (response: any) => {
        localStorage.setItem('token', response.token);
        this.router.navigateByUrl('/home');
      },
      error => {
        alert(error.error.message);
      }
    );
  }

}
