import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../../../core/services/concretes/auth.service';
import { Router } from '@angular/router';
import { MaskService } from '../../../../shared/services/mask.service';

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
    this.loginClicked.emit();
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
      nationalIdentity: ["", [Validators.required, Validators.minLength(11), Validators.maxLength(11), Validators.pattern('^[0-9]*$')]],
      phoneNumber: ["", [Validators.required, Validators.pattern('^[0-9]*$')]],
      email: ["", Validators.required, Validators.email],
      password: ["", Validators.required],
      confirmPassword: ["", Validators.required]
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
    this.registerForm.get('tc')?.setValue(this.maskService.maskTcNumber(value));
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
      console.log(this.registerForm.value);
      let registerModel = Object.assign({},this.registerForm.value);
      this.authService.register(registerModel).subscribe((response)=>{
        alert("Kayıt Başarılı")
        this.router.navigate(['login']);
      }, (errorResponse: any) => { 
          errorResponse.error.Errors.forEach((error: any) => {
            console.error(`Property: ${error.Property}`);
            error.Errors.forEach((errorMessage: string) => {
              alert(`Error: ${errorMessage}`);
            });
          });
        })
    }
  }

  


}





  // maskTcNumber(event: any) {
  //   const input = event.target as HTMLInputElement;
  //   let value = input.value.replace(/\D/g, '');
  //   const maxLength = 11;
  //   value = value.slice(0, maxLength);
  
  //   input.value = value;
  //   this.registerForm.patchValue({ tc: value });
  
  //   if (value.trim() === '') {
  //     this.registerForm.get('tc')?.markAsTouched();
  //   }
  // }
  // maskPhoneNumber(event: any) {
  //   const input = event.target as HTMLInputElement;
  //   let value = input.value.replace(/\D/g, '');
  //   const maxLength = 12;
  //   value = value.slice(0, maxLength);
  //   const maskedValue = value.replace(/(\d{3})(\d{3})(\d{4})/, '($1) $2-$3');
  //   input.value = maskedValue;
  //   this.registerForm.patchValue({ phoneNumber: value });

  //   if (value.trim() === '') {
  //     this.registerForm.get('phoneNumber')?.markAsTouched();
  //   }
  // }

