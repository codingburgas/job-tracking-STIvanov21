import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { AuthService, User } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './login.component.html'
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  error: string = '';

  constructor(
    private auth: AuthService,
    private router: Router
  ) {}

  login(): void {
    this.auth.login(this.username, this.password).subscribe({
      next: (user: User) => {
        // On successful login, navigate to the main menu
        this.error = '';
        this.router.navigate(['/main-menu']);
      },
      error: err => {
        console.error('Login error:', err);
        this.error = 'Invalid username or password.';
      }
    });
  }
}
