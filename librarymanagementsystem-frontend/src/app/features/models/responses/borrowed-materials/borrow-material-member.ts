export type BorrowMaterialMember = Root2[]

export interface Root2 {
  material: Material
  delayDay: number
  daysToRefund: number
  totalDept: number
}

export interface Material {
  id: string
  name: string
  description: string
  authorMaterials: AuthorMaterial[]
  materialImages: MaterialImage[]
  materialPropertyValues: MaterialPropertyValue[]
}

export interface AuthorMaterial {
  firstName: string
  lastName: string
}

export interface MaterialImage {
  url: string
}

export interface MaterialPropertyValue {
  materialProperty: MaterialProperty
  content: string
}

export interface MaterialProperty {
  name: string
}
