export interface DeletedMaterialProperty {
	id: string;
	materialPropertyValueName: string;
	materialId: string;
	materialTypeId: string;
	materialPropertyId: string;
    deletedDate: Date;
}