import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // ✅ import this for ngIf, ngFor, etc.

@Component({
  selector: 'app-profile',
  standalone: true, // ✅ if you're using standalone components
  imports: [CommonModule], // ✅ fix goes here
  templateUrl: './profile.component.html',
})
export class ProfileComponent implements OnInit {
  user: any = null;

  ngOnInit(): void {
    const storedUser = localStorage.getItem('currentUser');
    if (storedUser) {
      this.user = JSON.parse(storedUser);
    }
  }
}
