export interface DeletedMemberContactResponse {
	id: string;
	askLibrarianTopic: string;
	askLibrarianDescription: string;
	message: string;
	memberId: string;
	libraryId: string;
    deletedDate: Date;
}