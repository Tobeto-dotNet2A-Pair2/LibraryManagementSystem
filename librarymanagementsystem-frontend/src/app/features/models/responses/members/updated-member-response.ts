export interface UpdatedMemberResponse {
	id: string;
	firstName: string;
	lastName: string;
	tc: string;
	phoneNumber: string;
	photo: string;
	position: string;
	totalDebt: number;
	userId: string;
	isActive: boolean;
    updatedDate: Date;
}