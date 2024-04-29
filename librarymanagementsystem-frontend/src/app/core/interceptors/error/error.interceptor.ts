import { HttpErrorResponse, HttpInterceptorFn } from "@angular/common/http";
import { catchError, throwError } from "rxjs";

export const ErrorInterceptors:HttpInterceptorFn=(req,next)=>{

  return next(req).pipe(
    catchError((err: any)=>{
      if (err instanceof HttpErrorResponse){
        if (err.status==401){
          console.error('Unauthorized request: ',err);
        } else {
          console.error('Http error:',err);
        }
      } else {
        console.error('An error occured:',err);
      }
      return throwError(()=>err);
    })
  );;
};

 
