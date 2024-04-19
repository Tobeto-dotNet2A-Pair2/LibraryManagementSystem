export interface CreatedMaterialResponse {
	id: string;
	name: string;
	description: string;
	publicationDate: string;
	punishmentAmount: number;
	isBorrowable: boolean;
	borrowDay: number;
    createdDate: Date;
}