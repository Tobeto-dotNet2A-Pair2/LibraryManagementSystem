import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../../../core/services/concretes/auth.service';
import { Router } from '@angular/router';
import { MaskService } from '../../../../shared/services/mask.service';
import { UserForRegisterRequest } from '../../../models/requests/users/user-for-register-request';
import { UserRequest } from '../../../models/requests/users/user-request';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrl: '../../../pages/auth/auth.component.scss',
})
export class RegisterComponent {
  @Input() showRegisterForm: boolean = false;
  @Output() loginClicked = new EventEmitter<void>();
  
  //toaster=inject(ToastrService);

  callLoginHandler() {
    this.loginClicked.emit();  // Giriş sayfasını aç
  }
  
  registerForm!:FormGroup
  constructor(
    private formBuilder:FormBuilder,
    private authService:AuthService,
    private router:Router,
    private maskService:MaskService,
    private toastr: ToastrService) {}

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      firstName: ["", Validators.required],
      lastName: ["", Validators.required],
      // nationalIdentity: ["", [Validators.required, Validators.minLength(11), Validators.maxLength(11), Validators.pattern('^[0-9]*$')]],
      // phoneNumber: ["", [Validators.required, Validators.pattern('^[0-9]*$')]],
      phoneNumber: ["", [Validators.required]],
      nationalIdentity: ["", [Validators.required]],
      email: ["", Validators.required],
      password: ["", Validators.required],
      confirmPassword: ["" ]
    }, {
      validators: this.passwordMatchValidator 
    });
  }

  passwordMatchValidator(formGroup: FormGroup) {
    const password = formGroup.get('password')?.value;
    const confirmPassword = formGroup.get('confirmPassword')?.value;
    if (password !== confirmPassword) {
      formGroup.get('confirmPassword')?.setErrors({ passwordMismatch: true });
    } else {
      formGroup.get('confirmPassword')?.setErrors(null);
    }
  }


  maskTcNumber(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.registerForm.get('nationalIdentity')?.setValue(this.maskService.maskTcNumber(value));
  }
  
  maskPhoneNumber(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.registerForm.get('phoneNumber')?.setValue(this.maskService.maskPhoneNumber(value));
  }
  onSubmit() {
    if (this.registerForm.valid) {
      console.log("Form is valid. Submitting...");
    } else {
      console.log("Form is invalid. Cannot submit.");
    }

  }
  register(){
    if(this.registerForm.valid){
      console.log("register1  içinde");
      console.log(this.registerForm.value);
  
      // let registerModel = Object.assign({},this.registerForm.value);
     
      const registerModel: UserForRegisterRequest<UserRequest> = {
        user: {
          email: this.registerForm.value.email,
          password: this.registerForm.value.password
        },
        firstName: this.registerForm.value.firstName,
        lastName: this.registerForm.value.lastName,
        nationalIdentity: this.registerForm.value.nationalIdentity,
        phoneNumber: this.registerForm.value.phoneNumber,
      };
      console.log(registerModel, "Model içinde");

      this.authService.register(registerModel).subscribe((response)=>{
        
        //alert("Kayıt Başarılı");
       this.toastr.success('Kayıt Başarılı', 'Başarılı');
       setTimeout(() => {
        //Kayıt başarılı ise formu temzile ve giriş formunu aç
        this.registerForm.reset();
        this.callLoginHandler();}, 
        2000);
       },
       ///normal.........
      //  (errorResponse: any) => { 
      //     errorResponse.error.Errors.forEach((error: any) => {
      //       console.error("Kayıt hatası:", errorResponse);
      //       console.error(`Property: ${error.Property}`);
      //       error.Errors.forEach((errorMessage: string) => {
      //         alert(`Error: ${errorMessage}`);
      //       });
      //normal............
      (errorResponse: any) => {
        errorResponse.error.Errors.forEach((error: any) => {
          console.error("Kayıt hatası:", errorResponse);
          console.error(`Property: ${error.Property}`);
          error.Errors.forEach((errorMessage: string) => {
            if (errorMessage.includes('required')) {
              this.toastr.error('Lütfen gerekli alanları doldurun', 'Hata');
            } else {
              this.toastr.error(errorMessage, 'Hata');
            }
          });

          });
        })
    }
    else {
      // Form geçerli değil, hata mesajları gösterilmeli
      this.toastr.error('Lütfen formu doğru şekilde doldurun', 'Hata');
      // İsim alanı kontrolü
      if (this.registerForm.get('firstName')?.hasError('required')) {
        this.toastr.error('İsim alanı boş bırakılamaz', 'Hata');
      }
      // Soyisim alanı kontrolü
      if (this.registerForm.get('lastName')?.hasError('required')) {
        this.toastr.error('Soyisim alanı boş bırakılamaz', 'Hata');
      }
      // TC alanı kontrolü
      if (this.registerForm.get('nationalIdentity')?.hasError('required')) {
        this.toastr.error('TC alanı boş bırakılamaz', 'Hata');
      } else if (this.registerForm.get('nationalIdentity')?.hasError('minlength') || this.registerForm.get('nationalIdentity')?.hasError('maxlength') || this.registerForm.get('nationalIdentity')?.hasError('pattern')) {
        this.toastr.error('Geçerli bir TC kimlik numarası giriniz', 'Hata');
      }
      // Email alanı kontrolü
      if (this.registerForm.get('email')?.hasError('required')) {
        this.toastr.error('Email alanı boş bırakılamaz', 'Hata');
      } else if (this.registerForm.get('email')?.hasError('email')) {
        this.toastr.error('Geçerli bir email adresi giriniz', 'Hata');
      }
      // Şifre alanı kontrolü
      if (this.registerForm.get('password')?.hasError('required')) {
        this.toastr.error('Şifre alanı boş bırakılamaz', 'Hata');
      }
      // Tekrar Şifre alanı kontrolü
      if (this.registerForm.get('confirmPassword')?.hasError('required')) {
        this.toastr.error('Tekrar Şifre alanı boş bırakılamaz', 'Hata');
      } else if (this.registerForm.hasError('passwordMismatch')) {
        this.toastr.error('Şifreler eşleşmiyor', 'Hata');
      }

  }}

}





