import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CreateMemberRequest } from '../../../models/requests/members/create-member-request';

@Component({
  selector: 'app-member-list',
  standalone: true,
  imports: [HttpClientModule ],
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.scss'
})
export class MemberListComponent implements OnInit {
  memberList: CreateMemberRequest[] = [];

  constructor(private httpClient:HttpClient) {}

  ngOnInit(): void {
    this.getMember();
  }

  getMember() {
    // backend'e istek atıp verileri çek
    this.httpClient.get<CreateMemberRequest[]>('api/members').subscribe({
      next: (response: CreateMemberRequest[]) => {
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

  postToDo() {
    let obj = {};
    //this.httpClient.post('link', obj).subscribe();
  }

}