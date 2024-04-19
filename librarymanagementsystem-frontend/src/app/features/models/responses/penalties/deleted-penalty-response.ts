export interface DeletedPenaltyResponse {
	id: string;
	totalMaterialPenalty: number;
	dayDelay: number;
	borrowedMaterialId: string;
    deletedDate: Date;
}