import { Component, OnInit } from '@angular/core';
import { CommonModule }    from '@angular/common';
import { FormsModule }     from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { AuthService, RegisterForm } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
  form: RegisterForm = {
    firstName:  '',
    lastName:   '',
    username:   '',
    email:      '',
    password:   '',
    age:        0
    // optional: middleName and role omitted for default handling
  };

  error: string = '';

  constructor(
    private auth: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    console.log('RegisterComponent initialized');
  }

  register(): void {
    console.log('Payload:', this.form);
    this.auth.register(this.form).subscribe({
      next: () => this.router.navigate(['/login']),
      error: err => {
        console.error('Registration error:', err);
        if (err.status === 400 && err.error) {
          this.error = 'Validation failed. Please check your inputs.';
        } else {
          this.error = err.error?.message || 'Registration failed.';
        }
      }
    });
  }
}
