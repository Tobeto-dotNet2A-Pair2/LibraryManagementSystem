export interface UpdatedMaterialResponse {
	id: string;
	name: string;
	description: string;
	publicationDate: string;
	punishmentAmount: number;
	isBorrowable: boolean;
	borrowDay: number;
    updatedDate: Date;
}