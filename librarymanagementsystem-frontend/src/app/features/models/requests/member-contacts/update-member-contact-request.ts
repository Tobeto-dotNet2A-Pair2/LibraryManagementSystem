export interface UpdateMemberContactRequest {
	id: string;
	askLibrarianTopic: string;
	askLibrarianDescription: string;
	messages: string;
	memberId: string;
	libraryId: string;
}