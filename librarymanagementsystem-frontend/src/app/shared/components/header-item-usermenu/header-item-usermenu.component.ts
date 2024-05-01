import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { LocalStorageService } from '../../../core/services/concretes/local-storage.service';
import { jwtDecode } from 'jwt-decode';
import {
  JWT_EMAIL,
  JWT_ID,
} from '../../../core/constants/jwtAttributes';
import { MemberListDto } from '../../../features/models/responses/members/member-list-item-dto';
import { MembersService } from '../../../core/services/concretes/members.service';

@Component({
  selector: 'app-header-item-usermenu',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header-item-usermenu.component.html',
  styleUrl: './header-item-usermenu.component.scss',
})
export class HeaderItemUsermenuComponent implements OnInit {
  tokenId!: string;
  tokenEmail!: string;
  memberList: MemberListDto={
    index:0,
    size:0,
    count:0,
    hasNext:false,
    hasPrevious:false,
    pages:0,
    items:[]
  };

  constructor(private membersService: MembersService, private LocalStorageService: LocalStorageService) {}
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
      const id = decodedToken[JWT_ID];
      this.tokenId = id;
      console.log(id)
      const email = decodedToken[JWT_EMAIL];
      this.tokenEmail = email;
    }
  }

}
