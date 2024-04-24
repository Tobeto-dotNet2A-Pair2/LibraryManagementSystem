export interface CreatedMaterialResponse {
	id: string;
	name: string;
	description: string;
	punishmentAmount: number;
	isBorrowable: boolean;
	borrowDay: number;
    createdDate: Date;
}