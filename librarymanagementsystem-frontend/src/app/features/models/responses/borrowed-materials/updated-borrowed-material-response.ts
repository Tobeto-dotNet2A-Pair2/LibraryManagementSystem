export interface UpdatedBorrowedMaterialResponse {
	id: string;
	borrowDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
    updatedDate: Date;
}