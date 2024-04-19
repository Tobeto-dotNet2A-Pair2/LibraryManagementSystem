export interface CreatedMemberResponse {
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
    createdDate: Date;
}