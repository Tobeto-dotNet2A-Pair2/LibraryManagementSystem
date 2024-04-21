export interface DeletedMemberContactResponse {
	id: string;
	askLibrarianTopic: string;
	askLibrarianDescription: string;
	messages: string;
	memberId: string;
	libraryId: string;
    deletedDate: Date;
}