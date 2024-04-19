export interface CreatedBorrowedMaterialResponse {
	id: string;
	borrowDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
    createdDate: Date;
}