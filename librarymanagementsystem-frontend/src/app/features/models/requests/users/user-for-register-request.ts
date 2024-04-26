export interface UserForRegisterRequest {
	
  user:{
    email: string;
	password: string;
};
	firstName: string;
	lastName: string;
	nationalIdentity: string;
	phoneNumber: string;
}