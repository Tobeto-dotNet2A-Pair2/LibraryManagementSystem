export interface GetByIdBorrowedMaterialResponse {
	id: string;
	borrowedDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
}