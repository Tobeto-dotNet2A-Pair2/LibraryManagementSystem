import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { environment } from '../../../../../environments/environment';

@Component({
  selector: 'app-add-member-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, HttpClientModule],
  templateUrl: './add-member-form.component.html',
  styleUrl: './add-member-form.component.scss',
})
export class AddMemberFormComponent implements OnInit {
  memberForm!: FormGroup;
  constructor(private formBuilder: FormBuilder, private http: HttpClient) {}

  ngOnInit(): void {
    this.memberForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      tc: ['', Validators.required],
      position: ['admin', Validators.required],
    });
  }

  onSubmit() {
    if (this.memberForm.valid) {
      // Form verilerini al
      const formData = this.memberForm.value;

      // POST isteği için endpoint ve veri hazırlığı
      const url = `${environment.API_URL}/members`;
      const postData = {
        firstName: formData.firstName,
        lastName: formData.lastName,
        tc: formData.tc,
        phoneNumber: '05545478586', // Telefon numarası bilgisi yok, boş bırakıyoruz
        photo: 'sss', // Fotoğraf bilgisi yok, boş bırakıyoruz
        position: formData.position,
        totalDebt: 0, // Toplam borç bilgisi yok, 0 olarak atıyoruz
        userId: '1b9d6bcd-bbfd-4b2d-9b5d-ab8dfbbd4bed', // Kullanıcı kimliği bilgisi yok, boş bırakıyoruz
        isActive: true, // Yeni eklenen üye varsayılan olarak aktif olacak
      };

      // POST isteği gönder
      this.http.post(url, postData).subscribe({
        next: (response) => {
          console.log('Başarılı:', response);
          // Başarılı işlem sonrası işlemleri buraya ekleyebilirsiniz
        },
        error: (error) => {
          console.error('Hata:', error);
          // Hata durumunda yapılacak işlemleri buraya ekleyebilirsiniz
        },
      });
    } else {
      console.error('Form geçersiz.');
    }
  }
}
