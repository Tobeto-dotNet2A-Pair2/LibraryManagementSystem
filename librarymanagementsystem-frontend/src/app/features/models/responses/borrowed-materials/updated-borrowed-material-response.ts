export interface UpdatedBorrowedMaterialResponse {
	id: string;
	borrowedDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
    updatedDate: Date;
}