export interface PageResponse<T>{
    index:number,
    size:number,
    count:number,
    hasNext:boolean,
    hasPrevious:boolean,
    pages:number,
    items: T[];
}