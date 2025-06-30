import { Component, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { JobService, JobOffer } from '../../services/job.service';

@Component({
  selector: 'app-job-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './job-create.component.html'
})
export class JobCreateComponent {
  @Output() created = new EventEmitter<void>();

  job: JobOffer = {
    title: '',
    description: '',
    location: '',
    createdBy: 'admin'
  };

  constructor(private jobService: JobService) {}

  submit() {
    if (!this.job.title || !this.job.description || !this.job.location) return;

    this.jobService.create(this.job).subscribe({
      next: () => {
        alert('Job offer created!');
        this.created.emit(); // tell dashboard to reload
        this.job = {
          title: '',
          description: '',
          location: '',
          createdBy: 'admin'
        };
      },
      error: () => alert('Failed to create job offer.')
    });
  }
}
