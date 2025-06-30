import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { JobsComponent } from './jobs/jobs.component';
import {NavbarComponent} from "./navbar/navbar.component";
import {LoginComponent} from "./pages/login/login.component";
import {RegisterComponent} from "./pages/register/register.component";
import {MainMenuComponent} from "./pages/main-menu/main-menu.component";

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'jobs', component: JobsComponent },
  { path: '**', redirectTo: '' },
  { path: 'navbar', component: NavbarComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'main-menu',  component: MainMenuComponent },
];
