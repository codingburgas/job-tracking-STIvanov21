import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import {NavbarComponent} from "./navbar/navbar.component";

@Component({
    selector: 'app-root',
  imports: [CommonModule, RouterOutlet, TranslateModule, NavbarComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    standalone: true,
})
export class AppComponent {
  title = 'job-training';
}
