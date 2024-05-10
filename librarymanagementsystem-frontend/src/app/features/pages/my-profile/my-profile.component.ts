import { Component, OnInit } from '@angular/core';
import { MembersService } from '../../../core/services/concretes/members.service';
import { MemberListDto } from '../../models/responses/members/member-list-item-dto';
import { LocalStorageService } from '../../../core/services/concretes/local-storage.service';
import { JWT_ID } from '../../../core/constants/jwtAttributes';
import { jwtDecode } from 'jwt-decode';
import { GetByIdMemberResponse } from '../../models/responses/members/get-by-id-member-response';
import { CommonModule } from '@angular/common';

import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { UpdateMemberRequest } from '../../models/requests/members/update-member-request';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-my-profile',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './my-profile.component.html',
  styleUrl: './my-profile.component.scss',
})
export class MyProfileComponent implements OnInit {
  tokenId!: string;
  memberByIdList: GetByIdMemberResponse[] = [];
  updateMemberForm!: FormGroup;
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
    private toastr: ToastrService
  ) {}

  readonly PAGE_SIZE = 100000;

  ngOnInit(): void {
    this.findMemberByUserId().then(() => {
      this.createUpdateMaterialForm();
    });
    
  }

  findMemberByUserId(): Promise<void> {
    return new Promise<void>((resolve, reject) => {
      const token = this.LocalStorageService.getToken();

      if (token !== null) {
        const decodedToken = jwtDecode<any>(token);
        const id = decodedToken[JWT_ID];
        this.tokenId = id;

        if (this.tokenId !== null) {
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
                resolve(); // İşlem tamamlandığında promise'i çöz
              } else {
                console.log('Member not found.');
                resolve(); // İşlem tamamlandığında promise'i çöz
              }
            });
        }
      } else {
        resolve(); // İşlem tamamlandığında promise'i çöz
      }
    });
  }
  private createUpdateMaterialForm(): void {
    this.updateMemberForm = new FormGroup({
      // profilePicture: new FormControl(''),
      firstName: new FormControl(this.memberByIdList[0]?.firstName || '', [
        Validators.required,
      ]),
      lastName: new FormControl(this.memberByIdList[0]?.lastName || '', [
        Validators.required,
      ]),
      nationalIdentity: new FormControl(
        this.memberByIdList[0]?.nationalIdentity || '',
        [Validators.required]
      ),
      phoneNumber: new FormControl(this.memberByIdList[0]?.phoneNumber || '', [
        Validators.required,
      ]),
      position: new FormControl(this.memberByIdList[0]?.position || '',[
        Validators.required,
      ]),
      birthDate: new FormControl(this.memberByIdList[0].birthDate ? this.memberByIdList[0].birthDate.split('T')[0] : ''|| ''),
    });
  }

  onSubmitUpdateMemberForm(): void {
    let updateMemberData: UpdateMemberRequest = Object.assign(
      {
        profilePicture:"assets/media/avatars/blank.png",
        id: this.memberByIdList[0]?.id,
        totalDebt: 5,
        isActive: this.memberByIdList[0]?.isActive,
        userId: this.memberByIdList[0]?.userId,
      },

      this.updateMemberForm.value
    );

    this.membersService.updateMember(updateMemberData).subscribe(
      () => {
        this.toastr.success('Profiliniz başarıyla güncellendi.', 'Success');
      },
      (error) => {
        this.toastr.error(
          'Tüm Bilgileri giriniz'

        );
        console.error(error);
      }
    );
  }
}
