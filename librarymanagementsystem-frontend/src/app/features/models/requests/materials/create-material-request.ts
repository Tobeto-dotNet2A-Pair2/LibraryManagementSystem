export interface CreateMaterialRequest {
	name: string;
	description: string;
	publicationDate: string;
	punishmentAmount: number;
	isBorrowable: boolean;
	borrowDay: number;
}