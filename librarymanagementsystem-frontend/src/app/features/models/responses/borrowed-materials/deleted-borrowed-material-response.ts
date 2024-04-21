export interface DeletedBorrowedMaterialResponse {
	id: string;
	borrowDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
    deletedDate: Date;
}