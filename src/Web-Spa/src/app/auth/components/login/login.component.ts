import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginVm } from '../../interfaces/user-vm';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  standalone: true, 
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  dogList: any [] = [];
  constructor(private authService: AuthService, private toastr: ToastrService) {
    this.loginForm = new FormGroup({
      email: new FormControl('', { validators: [Validators.required], nonNullable: true }),
      password: new FormControl('', { validators: [Validators.required], nonNullable: true })
    })
  }

  ngOnInit(): void {
    // this.authService.test().subscribe({
    //   next: data => {
    //     this.dogList = data;
    //     console.log("Hello sweet cals", data);
    //   }
    // })
  }

  onSubmit() {
    if (this.loginForm.valid) {
       console.log(this.loginForm.valid);
      this.authService.login(this.loginForm.value as LoginVm).subscribe({
        next: data => {
          // console.log(data);
          this.toastr.success('Login successful!', 'Success');
        }
        , error: err => {
          console.log(err)
        }
      })
    }
  }


}
