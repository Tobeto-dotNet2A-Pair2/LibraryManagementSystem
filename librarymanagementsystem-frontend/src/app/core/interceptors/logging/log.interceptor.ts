import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpInterceptorFn } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

export const LoggingInterceptor: HttpInterceptorFn = (req, next) => {
  console.log(`Outgoing request to ${req.url}`);
  return next(req).pipe(
    tap(
      event => {
        console.log(`Incoming response from ${req.url}`, event);
      },
      error => {
        console.log(`Error response from ${req.url}`, error);
      }
    )
  );
};
