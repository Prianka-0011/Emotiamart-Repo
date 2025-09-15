import { Component } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { RouterLink, RouterOutlet } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
@Component({
  selector: 'app-ecommerce-layout',
  imports: [
    RouterOutlet,
    RouterLink,
    MatGridListModule,
    MatIconModule
  ],
  templateUrl: './ecommerce-layout.component.html',
  styleUrl: './ecommerce-layout.component.scss'
})
export class EcommerceLayoutComponent {

}
