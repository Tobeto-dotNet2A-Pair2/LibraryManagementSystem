export interface UpdateMaterialCopyRequest {
	id: string;
	dateReceipt: string;
	status: string;
	isReserved: boolean;
	isReservable: boolean;
	materialId: string;
	branchId: string;
	locationId: string;
}
