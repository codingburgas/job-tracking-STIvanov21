import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterOutlet, RouterModule, Router} from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import {NavbarComponent} from "./navbar/navbar.component";

@Component({
    selector: 'app-root',
  imports: [CommonModule, RouterOutlet, RouterModule, TranslateModule, NavbarComponent],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    standalone: true,
})
export class AppComponent {
  title = 'job-training';
}
