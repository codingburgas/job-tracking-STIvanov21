import { Component, OnInit } from '@angular/core';
import { JobService, JobOffer } from '../../services/job.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {JobCreateComponent} from "../job-create/job-create.component";
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule, JobCreateComponent],
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  jobOffers: JobOffer[] = [];
  showCreate = false;

  constructor(private jobService: JobService) {}

  ngOnInit() {
    this.loadJobs();
  }

  loadJobs() {
    this.jobService.getAll().subscribe(jobs => this.jobOffers = jobs);
  }

  toggleCreate() {
    this.showCreate = !this.showCreate;
  }

  apply(job: JobOffer) {
    alert(`You applied for ${job.title}`);
    // Connect to application logic here
  }
}
