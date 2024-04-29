export interface DeletedNotificationResponse {
	id: string;
	type: string;
	sendingDate: string;
	message: string;
	status: string;
    deletedDate: Date;
}