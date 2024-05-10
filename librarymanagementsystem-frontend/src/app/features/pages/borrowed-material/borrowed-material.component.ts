import { Component, OnInit } from '@angular/core';
import { BorrowMaterialService } from '../../services/concretes/borrow-material.service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { BorrowMaterialMember } from '../../models/responses/borrowed-materials/borrow-material-member';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-borrowed-material',
  standalone: true,
  imports: [CommonModule , FormsModule, RouterModule],
  templateUrl: './borrowed-material.component.html',
  styleUrl: './borrowed-material.component.scss'
})
export class BorrowedMaterialComponent implements OnInit {
  memberId: string | null = null;
  borrowedMaterials: BorrowMaterialMember[] = [];

  constructor(
    private route: ActivatedRoute,
    private borrowMaterialService: BorrowMaterialService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.memberId = params.get('id');
      if (this.memberId) {
        this.getMemberBorrowedMaterials(this.memberId);
      }
    });
  }
  getMemberBorrowedMaterials(memberId: string): void {
    this.borrowMaterialService.getMemberBorrowedMaterials(memberId).subscribe({
      next: (borrowedMaterials: BorrowMaterialMember[]) => {
        this.borrowedMaterials = borrowedMaterials;
      },
      error: (error) => {
        console.error('Üye ödünç alınan malzemeleri alma hatası:', error);
      }
    });
  }

  
}

