export interface UpdateBorrowedMaterialRequest {
	id: string;
	borrowedDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
}

