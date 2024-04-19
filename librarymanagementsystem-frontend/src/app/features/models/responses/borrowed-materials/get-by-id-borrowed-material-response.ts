export interface GetByIdBorrowedMaterialResponse {
	id: string;
	borrowDate: string;
	returnDate: string;
	isReturned: boolean;
	memberId: string;
	materialCopyId: string;
}