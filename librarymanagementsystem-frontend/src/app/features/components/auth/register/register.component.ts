import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../../../core/services/concretes/auth.service';
import { Router } from '@angular/router';
import { MaskService } from '../../../../shared/services/mask.service';
import { UserForRegisterRequest } from '../../../models/requests/users/user-for-register-request';
import { UserRequest } from '../../../models/requests/users/user-request';

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
 
  callLoginHandler() {
    this.loginClicked.emit();  // Giriş sayfasını aç
  }
  
  registerForm!:FormGroup
  constructor(
    private formBuilder:FormBuilder,
    private authService:AuthService,
    private router:Router,
    private maskService:MaskService) {}

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
        alert("Kayıt Başarılı");

        //Kayıt başarılı ise formu temzile ve giriş formunu aç
        this.registerForm.reset();
        this.callLoginHandler();
        //
       
      }, (errorResponse: any) => { 
          errorResponse.error.Errors.forEach((error: any) => {
            console.error("Kayıt hatası:", errorResponse);
            console.error(`Property: ${error.Property}`);
            error.Errors.forEach((errorMessage: string) => {
              alert(`Error: ${errorMessage}`);
            });
          });
        })
    }
  }

}





