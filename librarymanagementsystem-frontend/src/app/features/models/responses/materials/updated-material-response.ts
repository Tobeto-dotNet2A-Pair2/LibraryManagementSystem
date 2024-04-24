export interface UpdatedMaterialResponse {
	id: string;
	name: string;
	description: string;
	punishmentAmount: number;
	isBorrowable: boolean;
	borrowDay: number;
    updatedDate: Date;
}