import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { LocalStorageService } from '../../../core/services/concretes/local-storage.service';
import { jwtDecode } from 'jwt-decode';
import {
  JWT_EMAIL,
  JWT_ID,
  JWT_ROLES,
} from '../../../core/constants/jwtAttributes';
import { MemberListDto } from '../../../features/models/responses/members/member-list-item-dto';
import { MembersService } from '../../../features/services/concretes/members.service';
import { Router, RouterModule } from '@angular/router';
import { GetByIdMemberResponse } from '../../../features/models/responses/members/get-by-id-member-response';

@Component({
  selector: 'app-header-item-usermenu',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './header-item-usermenu.component.html',
  styleUrl: './header-item-usermenu.component.scss',
})
export class HeaderItemUsermenuComponent implements OnInit {
  tokenId!: string;
  tokenEmail!: string;
  tokenRole!: string[];
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
    private LocalStorageService: LocalStorageService,
    private router: Router
  ) {}
  readonly PAGE_SIZE = 1000000000;
  @Output() logout = new EventEmitter<void>();

  callLogoutHandler() {
    this.logout.emit();
  }

  ngOnInit(): void {
    this.printTokenFromLocalStorage();
    this.findMemberByUserId();
  }

  printTokenFromLocalStorage() {
    const token = this.LocalStorageService.getToken();

    if (token !== null) {
      const decodedToken = jwtDecode<any>(token);
      const id = decodedToken[JWT_ID];
      this.tokenId = id;
      const email = decodedToken[JWT_EMAIL];
      this.tokenEmail = email;
      const role = decodedToken[JWT_ROLES];
      this.tokenRole = role;
    }
  }

  goToProfile() {
    if (this.tokenRole.includes('Admin')) {
      this.router.navigate(['/adminpage/myprofile']);
    } else {
      this.router.navigate(['/homepage/myprofile']);
    }
  }
  goToBarrow(){
    this.router.navigate(['/homepage/myborrowed'])
  }
  findMemberByUserId() {
    if (this.tokenId !== null) {
      // Yüklenme tamamlandığında üye listesini bul
      this.membersService
        .getList({ pageIndex: 0, pageSize: this.PAGE_SIZE })
        .subscribe((response) => {
          this.memberList = response;
          const foundMember = this.memberList.items.find(
            (member) => member.userId === this.tokenId
          );
          if (foundMember) {
            this.memberByIdList = [foundMember];
            console.log('Found member:', this.memberByIdList);
          } else {
            console.log('Member not found.');
          }
        });
    }
  }
}
