import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { TokenService } from '../services/token.service';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const tokenService = inject(TokenService);

  let newRequest = req.clone({
    setHeaders: { Authorization: 'Bearer ' + tokenService.getToken() },
  });

  return next(newRequest);
};

// localStorage
// cookie
