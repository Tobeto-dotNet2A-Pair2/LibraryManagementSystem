export interface UpdatedMemberResponse {
	id: string;
	firstName: string;
	lastName: string;
	nationalIdentity: string;
	birthDate: string;
	phoneNumber: string;
	profilePicture: string;
	position: string;
	totalDebt: number;
	isActive: boolean;
	userId: string;
    updatedDate: Date;
}