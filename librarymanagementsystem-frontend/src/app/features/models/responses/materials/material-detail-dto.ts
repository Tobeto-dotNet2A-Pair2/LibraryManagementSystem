export interface MaterialDetailDto {
  authors: Author[]
  publishers: Publisher[]
  languages: Language[]
  translators: Translator[]
  materialCopies: MaterialCopy[]
  genres: Genre[]
  materialProperties: MaterialProperty[]
}

export interface Author {
  firstName: string
  lastName: string
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
}

export interface MaterialCopy {
  status: string
  isReserved: boolean
  isReservable: boolean
  branch: Branch
  location: Location
}

export interface Branch {
  name: string
}

export interface Location {
  fullLocationMap: string
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