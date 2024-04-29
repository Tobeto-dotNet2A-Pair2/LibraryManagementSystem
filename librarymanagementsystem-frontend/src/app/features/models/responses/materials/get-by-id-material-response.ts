export interface GetByIdMaterialResponse {
	id: string;
	name: string;
	description: string;
	punishmentAmount: number;
	isBorrowable: boolean;
	borrowDay: number;
}