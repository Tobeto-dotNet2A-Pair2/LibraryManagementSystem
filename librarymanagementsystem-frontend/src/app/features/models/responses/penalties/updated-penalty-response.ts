export interface UpdatedPenaltyResponse {
	id: string;
	totalMaterialPenalty: number;
	dayDelay: number;
	borrowedMaterialId: string;
    updatedDate: Date;
}