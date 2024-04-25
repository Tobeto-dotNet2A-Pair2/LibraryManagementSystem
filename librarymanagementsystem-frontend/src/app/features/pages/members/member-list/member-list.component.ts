import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CreateMemberRequest } from '../../../models/requests/members/create-member-request';
import { environment } from '../../../../../environments/environment';
import { CreateCityRequest } from '../../../models/requests/cities/create-city-request';

@Component({
  selector: 'app-member-list',
  standalone: true,
  imports: [HttpClientModule ],
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.scss'
})
export class MemberListComponent implements OnInit {
  memberList: CreateCityRequest[] = [];

  constructor(private httpClient:HttpClient) {}

  ngOnInit(): void {
    this.getMember();
  }
  //${environment.API_URL}/members?PageIndex=1&PageSize=1
  getMember() {
    // backend'e istek atıp verileri çek
    this.httpClient.get<CreateCityRequest[]>(`http://localhost:60805/api/Cities?PageIndex=1&PageSize=2`).subscribe({
      next: (response: CreateCityRequest[]) => {
        console.log('Backendden cevap geldi:', response);
        this.memberList = response;
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