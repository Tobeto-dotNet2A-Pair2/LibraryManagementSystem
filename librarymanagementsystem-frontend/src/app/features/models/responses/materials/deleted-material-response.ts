export interface DeletedMaterialResponse {
	id: string;
	name: string;
	description: string;
	punishmentAmount: number;
	isBorrowable: boolean;
	borrowDay: number;
    deletedDate: Date;
}