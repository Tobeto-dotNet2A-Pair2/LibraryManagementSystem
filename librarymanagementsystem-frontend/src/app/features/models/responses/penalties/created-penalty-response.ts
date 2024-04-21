export interface CreatedPenaltyResponse {
	id: string;
	totalMaterialPenalty: number;
	dayDelay: number;
	borrowedMaterialId: string;
    createdDate: Date;
}