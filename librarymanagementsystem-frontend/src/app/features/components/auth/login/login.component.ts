import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthBaseService } from '../../../../core/services/abstracts/auth-base.service';
import { UserForLoginRequest } from '../../../models/requests/users/user-for-login-request';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: '../../../pages/auth/auth.component.scss',
})
export class LoginComponent {
  @Input() showLoginForm: boolean = false;
  @Output() registerClicked = new EventEmitter<void>();
  
  callRegisterHandler() { //Register sayfasına gecmesini saglar
    this.registerClicked.emit(); 
  }
 
  loginForm!: FormGroup
  constructor(
    private formBuilder: FormBuilder, 
    private authService: AuthBaseService,
    private router: Router,
    private toastr: ToastrService ) { }

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      email: ["", Validators.required],
      password: ["", Validators.required]
    })
  }

  // login() {
  //   if (this.loginForm.valid) {
  //     let loginModel: UserForLoginRequest = Object.assign({}, this.loginForm.value);
  //     this.authService.login(loginModel).subscribe({
  //       error:(error)=>{
  //         alert(error.error);
  //       },
  //       complete:()=>{
  //         this.toastr.success("Başarılı", "Giris Yapıldı");
  //         alert("Giriş Yapıldı");
  //         setTimeout(()=>{
  //           this.router.navigate(["/adminpage"]);
  //           this.toastr.info("Admin Sayfasına Yönlendiriliyorsun.");
  //         },2000)
  //       }
  //     })
  //   }
  // }
  login() {
    if (this.loginForm.valid) {
      let loginModel: UserForLoginRequest = Object.assign({}, this.loginForm.value);
     this.authService.login(loginModel).subscribe({
      next: (response) => {
        // Başarılı giriş durumunda
        this.toastr.success('Giriş başarılı!', 'Başarılı');
         this.toastr.clear(); // Toast mesajını kapat
        this.toastr.info("Admin Sayfasına Yönlendiriliyorsun.");

        // İşlem tamamlandığında yönlendirme yapılabilir
        setTimeout(() => {
        
          this.router.navigate(['/adminpage']);
          
        }, 2000);
      }
    });
  } else {
    this.toastr.error('Böyle bir kullanıcı mevcut değildir.', 'Hata');
  }
}

}