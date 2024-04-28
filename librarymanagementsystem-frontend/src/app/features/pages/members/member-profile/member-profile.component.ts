import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MembersService } from '../../../../core/services/concretes/members.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-member-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './member-profile.component.html',
  styleUrl: './member-profile.component.scss'
})
export class MemberProfileComponent  {
  constructor(private membersService: MembersService, private activatedRoute:ActivatedRoute) {}
  
}
