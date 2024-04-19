export interface DeletedPaymentMethodResponse {
	id: string;
	branchId: string;
	paymentMethodName: string;
    deletedDate: Date;
}