export interface CreatedBorrowedMaterialResponse {
	id: string;
	borrowedDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
    createdDate: Date;
}