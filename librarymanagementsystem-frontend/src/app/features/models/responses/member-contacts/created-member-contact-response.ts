export interface CreatedMemberContactResponse {
	id: string;
	askLibrarianTopic: string;
	askLibrarianDescription: string;
	messages: string;
	memberId: string;
	libraryId: string;
    createdDate: Date;
}