import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetByIdMemberResponse } from '../../../models/responses/members/get-by-id-member-response';
import { HttpClientModule } from '@angular/common/http';
import {MemberGetbyidService} from '../../../../features/services/concretes/member-getbyid.service'
import { UserGetByIdResponse } from '../../../models/responses/users/user-getbyid';
import { UserGetbyidService } from '../../../services/concretes/user-getbyid.service';

@Component({
  selector: 'app-member-profile',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  templateUrl: './member-profile.component.html',
  styleUrl: './member-profile.component.scss',
})
export class MemberProfileComponent implements OnInit {
  memberId!: string;
  userById!:string;
  memberByIdList: GetByIdMemberResponse[] = [];
 
  userByIdList: UserGetByIdResponse[] = [];

  constructor(
    private route: ActivatedRoute,
    private memberGetByIdService: MemberGetbyidService,
    private userGetByIdService: UserGetbyidService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.memberId = params['id'];
      this.getMemberById();
      this.getUserId();
    });
  }

  getMemberById(): void {
    this.memberGetByIdService.getMemberById(this.memberId).subscribe({
      next: (response: GetByIdMemberResponse) => {
        console.log('Backendden cevap geldi:', response);
        this.memberByIdList = [response];
      },
      error: (error) => {
        console.log('Backendden hatalı cevap geldi:', error);
      },
      complete: () => {
        console.log('Backend isteği sonlandı.');
      },
    });
  }

  getUserId(): void {
    this.userGetByIdService.getUserById('bbbe358f-c023-49da-c89d-08dc6786575e').subscribe({
      next: (response: UserGetByIdResponse) => {
        console.log('User ID:', response.id);
        this.userByIdList = [response];
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
