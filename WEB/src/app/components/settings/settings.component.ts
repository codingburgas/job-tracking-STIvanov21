import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './settings.component.html'
})
export class SettingsComponent implements OnInit {
  darkMode: boolean = false;
  displayName: string = '';
  emailNotifications: boolean = true;

  ngOnInit() {
    // Read saved value but do NOT apply class immediately
    const saved = localStorage.getItem('darkMode');
    this.darkMode = saved === 'true';

    // Don't call applyDarkMode() here — let user toggle first
  }

  toggleDarkMode() {
    this.darkMode = !this.darkMode;
    this.applyDarkMode(this.darkMode);
  }

  saveSettings() {
    localStorage.setItem('darkMode', String(this.darkMode));
    this.applyDarkMode(this.darkMode);
    alert('Settings saved!');
  }
  applyDarkMode(enabled: boolean) {
    if (enabled) {
      document.body.classList.add('dark-theme');
    } else {
      document.body.classList.remove('dark-theme');
    }
  }

}
