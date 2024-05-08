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
import { MembersService } from '../../../core/services/concretes/members.service';
import { Router, RouterModule } from '@angular/router';

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
  @Output() logout = new EventEmitter<void>();

  callLogoutHandler() {
    this.logout.emit();
  }

  ngOnInit(): void {
    this.printTokenFromLocalStorage();
  }

  printTokenFromLocalStorage() {
    const token = this.LocalStorageService.getToken();

    if (token !== null) {
      const decodedToken = jwtDecode<any>(token);
      console.log(decodedToken);

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
}
