import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../../services/concretes/auth.service';

export const loginGuard: CanActivateFn = (route:ActivatedRouteSnapshot, state:RouterStateSnapshot) => {

  const authService = inject(AuthService);
  const router = inject(Router);

  if(authService.loggedIn()) {
    return true;
  }
  else{
    router.navigate(["login"]);
    alert("You must log in to view this page!")
    return false;
  }

};
