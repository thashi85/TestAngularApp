import { Injectable } from '@angular/core';
import {
    HttpClient,
    HttpRequest, HttpHandler, HttpEvent,
    HttpInterceptor,
    HttpResponse, HttpErrorResponse, HttpEventType, HTTP_INTERCEPTORS
} from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Observable, throwError } from 'rxjs';
import { map, catchError, switchMap, tap, mergeMap } from 'rxjs/operators';

@Injectable()
export class APIRequestHandler implements HttpInterceptor {

    constructor(private _http: HttpClient) {
    }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      
        request = request.clone({
            setHeaders: {
                'Token':'',
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        });

        return next.handle(request).pipe(tap((event: HttpEvent<any>) => {
            if (event instanceof HttpResponse) {             
            }
            return event;
        }, ((err: any) => {           
            return (err);

        }), () => {

        }), catchError((err) => {
          
            if (err instanceof HttpErrorResponse) {
                if (err.status === 401) {

                   //log out user
                } else {
                    return throwError(err);
                }

            } else {
                return throwError(err);
            }
        })
        );

    }

}

export const testHttpProvider = {
    provide: HTTP_INTERCEPTORS,
    useClass: APIRequestHandler,
    multi: true
};
