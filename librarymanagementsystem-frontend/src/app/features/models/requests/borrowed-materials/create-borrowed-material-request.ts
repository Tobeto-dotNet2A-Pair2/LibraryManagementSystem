export interface CreateBorrowedMaterialRequest {
	borrowedDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
}
