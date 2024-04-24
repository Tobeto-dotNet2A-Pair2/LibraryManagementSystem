export interface UpdatedMemberContactResponse {
	id: string;
	askLibrarianTopic: string;
	askLibrarianDescription: string;
	message: string;
	memberId: string;
	libraryId: string;
    updatedDate: Date;
}