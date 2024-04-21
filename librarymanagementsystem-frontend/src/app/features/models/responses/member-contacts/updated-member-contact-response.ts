export interface UpdatedMemberContactResponse {
	id: string;
	askLibrarianTopic: string;
	askLibrarianDescription: string;
	messages: string;
	memberId: string;
	libraryId: string;
    updatedDate: Date;
}