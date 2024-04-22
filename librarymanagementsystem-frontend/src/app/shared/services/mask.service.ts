import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MaskService {

  maskTcNumber(value: string): string {
    let maskedValue = value.replace(/\D/g, '');
    const maxLength = 11;
    maskedValue = maskedValue.slice(0, maxLength);
    return maskedValue;
  }

  maskPhoneNumber(value: string): string {
    let maskedValue = value.replace(/\D/g, '');
    const maxLength = 12;
    maskedValue = maskedValue.slice(0, maxLength);
    maskedValue = maskedValue.replace(/(\d{3})(\d{3})(\d{4})/, '($1) $2-$3');
    return maskedValue;
  }


  // maskTcNumber(event: any, form: FormGroup) {
  //   const input = event.target as HTMLInputElement;
  //   let value = input.value.replace(/\D/g, '');
  //   const maxLength = 11;
  //   value = value.slice(0, maxLength);
  
  //   input.value = value;
  //   form.patchValue({ tc: value });
  
  //   if (value.trim() === '') {
  //     form.get('tc')?.markAsTouched();
  //   }
  // }

  // maskPhoneNumber(event: any, form: FormGroup) {
  //   const input = event.target as HTMLInputElement;
  //   let value = input.value.replace(/\D/g, '');
  //   const maxLength = 12;
  //   value = value.slice(0, maxLength);
  //   const maskedValue = value.replace(/(\d{3})(\d{3})(\d{4})/, '($1) $2-$3');
  //   input.value = maskedValue;
  //   form.patchValue({ phoneNumber: value });

  //   if (value.trim() === '') {
  //     form.get('phoneNumber')?.markAsTouched();
  //   }
  // }
}

  
  // maskTcNumber(value: string): string {
  //   let maskedValue = value.replace(/\D/g, '');
  //   const maxLength = 11;
  //   maskedValue = maskedValue.slice(0, maxLength);
  //   return maskedValue;
  // }

  // maskPhoneNumber(value: string): string {
  //   let maskedValue = value.replace(/\D/g, '');
  //   const maxLength = 12;
  //   maskedValue = maskedValue.slice(0, maxLength);
  //   maskedValue = maskedValue.replace(/(\d{3})(\d{3})(\d{4})/, '($1) $2-$3');
  //   return maskedValue;
  // }









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
