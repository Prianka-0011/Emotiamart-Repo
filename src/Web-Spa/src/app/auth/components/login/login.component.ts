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
  dogList: any[] = [];
  constructor(private authService: AuthService, private toastr: ToastrService) {
    this.loginForm = new FormGroup({
      email: new FormControl<string>('', { validators: [Validators.required], nonNullable: true }),
      password: new FormControl<string>('', { validators: [Validators.required], nonNullable: true })
    })
  }

  ngOnInit(): void {
  }

  onSubmit() {
    console.log("Login form", this.loginForm.valid);
    if(this.loginForm.valid)
    {
      this.authService.login(this.loginForm.value as LoginVm).subscribe({
        next: ()=>{
          console.log("Login Success")
        }, error: (err)=>{
          this.toastr.error("Login Failed: " + err.message);
        }
      })
    }
  }
}
