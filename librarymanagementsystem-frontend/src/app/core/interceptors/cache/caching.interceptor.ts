import { HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, filter, of, tap } from "rxjs";

export const CachingInterceptors:HttpInterceptorFn=(req,next)=>{
  const cache: Map<string, HttpResponse<any>> =new Map();

    const isCachable=req.method=='GET';
    
    if(!isCachable){
      return next(req);
    }
    const cacheKey=req.urlWithParams;
    const cachedResponse=cache.get(cacheKey);
    
    if(cachedResponse) {
      return of(cachedResponse);
  }
  return next(req).pipe(
    filter((event:HttpEvent<any>)=>event instanceof HttpResponse && event.status==200),
    tap((event:HttpEvent<any>)=>{
      if (event instanceof HttpResponse){
      cache.set(cacheKey,event)
      }
     })
   );
}