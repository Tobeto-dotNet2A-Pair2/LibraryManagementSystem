export interface UpdatedPenaltyResponse {
	id: string;
	totalMaterialDebt: number;
	dayDelay: number;
	borrowedMaterialId: string;
    updatedDate: Date;
}