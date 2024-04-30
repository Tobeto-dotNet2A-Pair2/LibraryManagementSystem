export interface UserForRegisterRequest<T> {
  
  user: T;
  firstName: string;
  lastName: string;
  nationalIdentity: string;
  phoneNumber: string;
}