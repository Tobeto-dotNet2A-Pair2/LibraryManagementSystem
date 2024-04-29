export interface DeletedPenaltyResponse {
	id: string;
	totalMaterialDebt: number;
	dayDelay: number;
	borrowedMaterialId: string;
    deletedDate: Date;
}