import { Component, OnInit } from '@angular/core';
import { MembersService } from '../../../core/services/concretes/members.service';
import { ActivatedRoute } from '@angular/router';
import { PageRequest } from '../../../core/models/page/page-request';
import { MemberListDto } from '../../models/responses/members/member-list-item-dto';
import { LocalStorageService } from '../../../core/services/concretes/local-storage.service';
import { JWT_ID } from '../../../core/constants/jwtAttributes';
import { jwtDecode } from 'jwt-decode';
import { GetByIdMemberResponse } from '../../models/responses/members/get-by-id-member-response';

@Component({
  selector: 'app-my-profile',
  standalone: true,
  imports: [],
  templateUrl: './my-profile.component.html',
  styleUrl: './my-profile.component.scss',
})
export class MyProfileComponent implements OnInit {
  tokenId!: string;
  memberByIdList: GetByIdMemberResponse[] = [];
  memberList: MemberListDto = {
    index: 0,
    size: 0,
    count: 0,
    hasNext: false,
    hasPrevious: false,
    pages: 0,
    items: [],
  };

  constructor(
    private membersService: MembersService,
    private LocalStorageService: LocalStorageService
  ) {}

  readonly PAGE_SIZE = 1000000000;

  ngOnInit(): void {
    this.findMemberByUserId();
  }

  findMemberByUserId() {
    const token = this.LocalStorageService.getToken();
  
    if (token !== null) {
      const decodedToken = jwtDecode<any>(token);
      const id = decodedToken[JWT_ID];
      this.tokenId = id;
      //console.log("token:"+this.tokenId);
      if (this.tokenId !== null) {
        // Yüklenme tamamlandığında üye listesini bul
        this.membersService.getList({ pageIndex: 0, pageSize: this.PAGE_SIZE }).subscribe(response => {
          this.memberList = response;
          const foundMember = this.memberList.items.find((member) => member.userId === this.tokenId);
          if (foundMember) {
            this.memberByIdList=[foundMember];
            console.log('Found member:', this.memberByIdList);
          } else {
            console.log('Member not found.');
          }
        });
      }
    }
  }
}
