export interface UpdatePenaltyRequest {
	id: string;
	totalMaterialPenalty: number;
	dayDelay: number;
	borrowedMaterialId: string;
}