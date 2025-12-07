import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, EmailValidator, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { validate } from 'graphql';
import { emit } from 'node:process';
import { combineLatest } from 'rxjs';
import { AuthService } from '../../services/auth.service';
import { UserVm } from '../../interfaces/user-vm';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  imports: [RouterModule , ReactiveFormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup<{
    id: FormControl<string | null>;
    firstName: FormControl<string>;
    lastName: FormControl<string>;
    email: FormControl<string>;
    password: FormControl<string | null>;
    confirmPassword: FormControl<string>;
    isActive: FormControl<boolean | null>;
  }>

  constructor(private authService: AuthService, private toastr: ToastrService) { }


  ngOnInit(): void {
    this.registerForm = new FormGroup({
      id: new FormControl('00000000-0000-0000-0000-000000000000', { nonNullable: false }),
      firstName: new FormControl('', { validators: [Validators.required, Validators.minLength(3)], nonNullable: true }),
      lastName: new FormControl('', { validators: [Validators.required, Validators.minLength(3)], nonNullable: true }),
      email: new FormControl('', { validators: [Validators.required, Validators.email,], nonNullable: true }),
      password: new FormControl('', { validators: [Validators.required, Validators.minLength(6)], nonNullable: false }),
      confirmPassword: new FormControl('', { validators: [Validators.required], nonNullable: true }),
      isActive: new FormControl(true, { nonNullable: false })
    }, { validators: this.passwordMatchValidator });
  }
  passwordMatchValidator(control: AbstractControl) {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');

    if (password && confirmPassword) {
      if (password.value !== confirmPassword.value) {
        confirmPassword.setErrors({ mismatch: true });
      }
      else {
        confirmPassword.setErrors(null);
      }
    }
    return null;
  }

  onSubmit() {
  //  this.toastr.success('Registration successful!', 'Success');
    if (this.registerForm.valid) {

      this.authService.register(this.registerForm.value as UserVm).subscribe({
        next: (res) => {
          this.toastr.success('Registration successful!', 'Success');
        },
        error: (err) => console.error('GraphQL error:', err)
      });
    } else {
      console.warn('Form invalid');
    }
  }
}
