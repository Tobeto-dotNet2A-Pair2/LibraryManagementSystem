export interface UpdateUserRequest {
	id: string;
	firstName: string;
	lastName: string;
	password: string;
	newPassword: string;
}

///api/Users/FromAuth