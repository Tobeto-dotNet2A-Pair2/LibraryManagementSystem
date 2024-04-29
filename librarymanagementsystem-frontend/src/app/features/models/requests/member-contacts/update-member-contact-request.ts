export interface UpdateMemberContactRequest {
	id: string;
	askLibrarianTopic: string;
	askLibrarianDescription: string;
	message: string;
	memberId: string;
	libraryId: string;
}