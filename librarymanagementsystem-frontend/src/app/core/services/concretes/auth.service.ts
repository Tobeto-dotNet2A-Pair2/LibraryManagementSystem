import { Injectable, inject } from '@angular/core';
import { AuthBaseService } from '../abstracts/auth-base.service';
import { Observable, catchError, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { LocalStorageService } from './local-storage.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserForRegisterRequest } from '../../../features/models/requests/users/user-for-register-request';
import { UserForRegisterResponse } from '../../../features/models/responses/users/user-for-register-response';
import { UserForLoginRequest } from '../../../features/models/requests/users/user-for-login-request';
import { AccessTokenModel } from '../../../features/models/responses/users/access-token-model';
import { TokenModel } from '../../../features/models/responses/users/token-model';
import { UserRequest } from '../../../features/models/requests/users/user-request';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends AuthBaseService {
  fullname!:string;
  userId!:string;
  token:any;
  jwtHelper:JwtHelperService = new JwtHelperService;
  claims:string[]=[]
  //toaster=inject(ToastrService);

  private  apiUrl:string = `${environment.API_URL}/Auth`;

  constructor(
    private httpClient:HttpClient,
    private storageService:LocalStorageService,
    private toastr: ToastrService) {super() }

  override register(userforRegisterRequest: UserForRegisterRequest<UserRequest>)
      :Observable<UserForRegisterResponse> {

    return this.httpClient.post<UserForRegisterResponse>(`${this.apiUrl}/Register`,userforRegisterRequest)
  }

  login(userLoginRequest:UserForLoginRequest) :Observable<AccessTokenModel<TokenModel>>{
    return this.httpClient.post<AccessTokenModel<TokenModel>>(`${this.apiUrl}/Login`,userLoginRequest)
    .pipe(map(response=>{
        this.storageService.setToken(response.accessToken.token);
        //this.toaster.success("Başarılı ","Giriş Yapıldı");
        //alert("Giriş yapıldı")
        return response;
      }),
    // catchError(responseError=>{
    //   alert(responseError.error)
    //   throw responseError;})

    catchError(error => {
       // Hata durumunda uygun işlemi yap
       this.toastr.error('Lütfen giriş bilgilerini doğru şekilde doldurun.', 'Hata');
        // Hata nesnesini tekrar fırlat
        throw error;
    })
    )
  }


  getDecodedToken(){
    try{
      this.token=this.storageService.getToken();
      return this.jwtHelper.decodeToken(this.token)
    }
    catch(error){
      return error;
    }
  }

  loggedIn():boolean{
    this.token=this.storageService.getToken();
    let isExpired = this.jwtHelper.isTokenExpired(this.token);
    return !isExpired;
    
  }

  getUserName():string{
    var decoded = this.getDecodedToken();
    var propUserName = Object.keys(decoded).filter(x=>x.endsWith("/name"))[0]
    return this.fullname=decoded[propUserName];
  }

  // getUserName():string{
  //   console.log(this.fullname)
  //   return this.fullname;
  // }
  

  getCurrentUserId():string{
    var decoded = this.getDecodedToken();
    var propUserId = Object.keys(decoded).filter(x=>x.endsWith("/nameidentifier"))[0]
    return this.userId=decoded[propUserId]
  }


  logOut(){
    this.storageService.removeToken();
    alert("Çıkış yapıldı");
    setTimeout(function(){
      window.location.reload()
    },400)
  }

  getRoles():string[]{
    if(this.storageService.getToken()){
      var decoded = this.getDecodedToken()
      var role = Object.keys(decoded).filter(x=>x.endsWith("/role"))[0]
      this.claims=decoded[role]
    }
    return this.claims;
  }

  isAdmin():boolean{
    if(this.claims.includes("admin")){
      return true;
    }
    return false;
  }
  
// Kullanıcının oturum bilgilerini kontrol etmek için 
// bu.storageService.getToken() ile kullanıcının token'ını alır ve token'ın geçerliliğini kontrol eder
  isLoggedIn(): boolean {
    const token = this.storageService.getToken(); // localStorage'da saklanan token
    const isTokenValid = !!token && !this.jwtHelper.isTokenExpired(token);
    return isTokenValid;
  }
  
}