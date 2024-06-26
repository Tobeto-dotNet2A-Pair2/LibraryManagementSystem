import { CanActivateFn, Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { JWT_ROLES } from '../constants/jwtAttributes';
import { inject } from '@angular/core';
import { TokenService } from '../services/token.service';

export const roleGuard: CanActivateFn = (route, state) => {
  // token'ı elde et?
  let router = inject(Router);
  let token = inject(TokenService).getToken();

  if (token == null) return false;
  let decodedToken = jwtDecode<any>(token);
  
  let userRoles: string[] =
  typeof decodedToken[JWT_ROLES] == typeof ''
    ? [decodedToken[JWT_ROLES]]
    : decodedToken[JWT_ROLES];

  let requiredRoles: string[] = route.data['requiredRoles'] || [];//data yoksa boş dön

  let hasRole = false;

  requiredRoles.forEach((role) => {
    if (userRoles.includes(role)) hasRole = true;
  });

  if (!hasRole) router.navigateByUrl('/homepage');

  return hasRole;
};
