export interface CreatedPenaltyResponse {
	id: string;
	totalMaterialDebt: number;
	dayDelay: number;
	borrowedMaterialId: string;
    createdDate: Date;
}