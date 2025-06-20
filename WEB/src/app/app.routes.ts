import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { JobsComponent } from './jobs/jobs.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'jobs', component: JobsComponent },
  { path: '**', redirectTo: '' }
];
