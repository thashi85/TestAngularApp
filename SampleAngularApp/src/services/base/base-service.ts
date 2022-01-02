import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';

import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class BaseService {

    constructor(private _http: HttpClient) {

    }
    //Web API    
   
    WebAPIGet(url: string, isobserve: boolean=true): any {
        if(isobserve)
            return this._http.get(environment.webApiUrl + url, { observe: 'response' });
        else
            return this._http.get(environment.webApiUrl + url);
    } 
  
    WebAPIPOST(url: string, body: string, isobserve: boolean=true): any {
        return this._http.post((environment.webApiUrl + url), body, { observe: 'response' });
    }

    WebAPIPATCH(url: string, body: string): any {
        return this._http.patch((environment.webApiUrl + url), body,{ observe: 'response' });
    }
    WebAPIDELETE(url: string): any {
        return this._http.delete((environment.webApiUrl + url), { observe: 'response' });
    }
   
    
}