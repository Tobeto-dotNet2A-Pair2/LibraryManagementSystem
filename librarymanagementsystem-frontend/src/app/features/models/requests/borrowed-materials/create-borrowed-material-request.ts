export interface CreateBorrowedMaterialRequest {
	borrowDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
}