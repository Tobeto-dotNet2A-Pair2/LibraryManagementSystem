export interface DeletedNotificationResponse {
	id: string;
	notificationType: string;
	notificationDate: string;
	message: string;
	status: string;
    deletedDate: Date;
}