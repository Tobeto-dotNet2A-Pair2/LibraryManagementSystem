export interface GetListMaterialCopyResponse {
	imageUrls: string[]
	id: string
	name: string
	fullLocationMap: string
	description: string
	borrowDay: number
	punishmentAmount: number
	isBorrowable: boolean
}