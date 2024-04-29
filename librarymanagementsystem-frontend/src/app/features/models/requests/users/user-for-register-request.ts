export interface UserForRegisterRequest {
    user: {
      email: string;
      password: string;
    };
    firstName: string;
    lastName: string;
    birthDate: string;
    nationalIdentity: string;
  }
  