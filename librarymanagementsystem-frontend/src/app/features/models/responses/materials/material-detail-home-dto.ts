export interface MaterialDetailHomeDto {
  id: string
  status: string
  isReserved: boolean
  isReservable: boolean
  name: string
  description: string
  punishmentAmount: number
  isBorrowable: boolean
  borrowDay: number
  authors: Author[]
  publishers: Publisher[]
  languages: Language[]
  translators: Translator[]
  genres: Genre[]
  materialProperties: MaterialProperty[]
  materialImages: MaterialImage[]
}

export interface Author {
  firstName: string
  lastName: string
  country: any
}

export interface Publisher {
  name: string
  publicationPlace: string
}

export interface Language {
  name: string
}

export interface Translator {
  name: string
  description: any
}

export interface Genre {
  name: string
}

export interface MaterialProperty {
  name: string
  propertyValue: PropertyValue
}

export interface PropertyValue {
  content: string
  materialType: MaterialType
}

export interface MaterialType {
  name: string
}

export interface MaterialImage {
  url: string
}
