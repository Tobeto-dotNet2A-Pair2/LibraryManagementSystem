export interface DeletedBorrowedMaterialResponse {
	id: string;
	borrowedDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
    deletedDate: Date;
}