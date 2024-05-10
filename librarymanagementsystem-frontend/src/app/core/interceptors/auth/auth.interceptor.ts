import { HttpInterceptorFn } from '@angular/common/http';

import { inject } from '@angular/core';
import { LocalStorageService } from '../../services/concretes/local-storage.service';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

  const storageService = inject(LocalStorageService);
  const token = storageService.getToken();

  console.log("token::"+token);
  const authRequest = req.clone({
    setHeaders:{
      Authorization:`Bearer ${token}`
      
    }
  })

  return next(authRequest);
};
