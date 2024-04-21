import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserForRegisterRequest } from '../../../features/models/requests/users/user-for-register-request';
import { UserForRegisterResponse } from '../../../features/models/responses/users/user-for-register-response';
import { UserForLoginRequest } from '../../../features/models/requests/users/user-for-login-request';
import { AccessTokenModel } from '../../../features/models/responses/users/access-token-model';
import { TokenModel } from '../../../features/models/responses/users/token-model';

@Injectable()
export abstract class AuthBaseService {
  abstract register(
    userforRegisterRequest: UserForRegisterRequest
  ): Observable<UserForRegisterResponse>;
  abstract login(
    userLoginRequest: UserForLoginRequest
  ): Observable<AccessTokenModel<TokenModel>>;
  abstract getDecodedToken(): void;
  abstract loggedIn(): boolean;
  abstract getUserName(): string;
  abstract getCurrentUserId(): string;
  abstract logOut(): void;
  abstract getRoles(): string[];
  abstract isAdmin(): boolean;
}
