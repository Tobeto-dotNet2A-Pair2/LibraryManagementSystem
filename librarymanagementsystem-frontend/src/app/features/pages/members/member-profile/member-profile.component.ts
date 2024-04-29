import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetByIdMemberResponse } from '../../../models/responses/members/get-by-id-member-response';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-member-profile',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './member-profile.component.html',
  styleUrl: './member-profile.component.scss',
})
export class MemberProfileComponent implements OnInit {
  memberId!: string;
  memberByIdList: GetByIdMemberResponse[] = [];
  constructor(private httpClient: HttpClient, private route: ActivatedRoute ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.memberId = params['id'];
      console.log('Member ID:', this.memberId);
    });

    this.getMemberById();
    
  }

  getMemberById() {
    // backend'e istek atıp verileri çek
    this.httpClient.get<GetByIdMemberResponse>(`${environment.API_URL}/Members/${this.memberId}`).subscribe({
      next: (response: GetByIdMemberResponse) => {
        console.log('Backendden cevap geldi:', response);
        this.memberByIdList =[response];
      },
      error: (error) => {
        console.log('Backendden hatalı cevap geldi:', error);
      },
      complete: () => {
        console.log('Backend isteği sonlandı.');
      },
    });
  }
}
