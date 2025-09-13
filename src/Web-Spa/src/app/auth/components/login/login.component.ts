import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AuthService, UserVm } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-login',
  imports: [
    CommonModule,
    MatGridListModule,
    MatFormFieldModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    RouterLink
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  constructor(private authService: AuthService) {

  }
  // users: UserVm[] = [];
  // ngOnInit()
  // {
  //   this.authService.getUsers().subscribe({
  //     next: data => {
  //       this.users = data;
  //       console.log( this.users)
  //     },
  //     error: err => {
  //       console.log(err);
  //     }
  //   })
  // }


}
