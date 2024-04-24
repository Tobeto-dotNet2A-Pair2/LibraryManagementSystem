export interface DeletedMaterialPropertyValueResponse {
	id: string;
	content: string;
	materialId: string;
	materialTypeId: string;
	materialPropertyId: string;
    deletedDate: Date;
}