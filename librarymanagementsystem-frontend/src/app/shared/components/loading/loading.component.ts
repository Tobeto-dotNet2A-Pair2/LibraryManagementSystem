import { Component } from '@angular/core';
import { LoadingService } from '../../../core/services/concretes/loading.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-loading',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './loading.component.html',
  styleUrl: './loading.component.scss'
})
export class LoadingComponent {
  constructor(private loadingService: LoadingService) {}


  get loadingStatus() {
    return this.loadingService.isLoading;
  }
}
