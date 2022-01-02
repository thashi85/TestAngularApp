import { Injectable } from '@angular/core';
import { HttpResponse } from '@angular/common/http';

import { Observable, of } from "rxjs";
import { map, catchError, switchMap } from "rxjs/operators";

import {BaseService} from 'src/services/base/base-service';
import {ParameterMapper} from 'src/services/base/parameter-mapper';
import {BaseParam} from 'src/models/base-param';
import {APIResult, APIResultStatus} from 'src/models/api-result';
import {User,Person} from 'src/models/user/user';
import {UserGroup} from 'src/models/user/user-group';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private _baseService: BaseService) { }

  getUsers(baseParam: BaseParam):Observable<APIResult<User[]>>{
    var filter = "";
    if (baseParam) {
        filter = ParameterMapper.mapFilters(baseParam.filter);
        filter = ParameterMapper.mapFilters(baseParam.paging, filter);
        if (baseParam.sort) {
            if (filter.length > 0) filter += "&";
            filter += "sort=" + baseParam.sort;
        }
    }
    return this._baseService.WebAPIGet("api/v1.0/users?"+filter, true).pipe(
        map((response: HttpResponse<any>) => {
            var json = (response.body);
            var _res=new APIResult<User[]>();
            _res.status.isError=json.status.isError;

            if(!json.status.isError){
              _res.data=[];
              json.data?.forEach((c, i) => {
                _res.data.push((c as User));
              });
              _res.totalResultCount=json.totalResultCount;
            }else{
              _res.status.errorCode=json.status.errorCode;
              _res.status.errorMessage=json.status.errorMessage;
            }
           
            return _res;
        }));
  }
    
    saveUser(param:Person):Observable<APIResult<User>>{
      return this._baseService.WebAPIPOST("api/v1.0/users",JSON.stringify(param),true).pipe(
          map((response: HttpResponse<any>) => {
              var json = (response.body);
              // need to do mapping
              return (json as APIResult<User>)
          }));
    }

    deleteUser(id:number):Observable<APIResult<boolean>>{
      return this._baseService.WebAPIDELETE("api/v1.0/users/"+id).pipe(
          map((response: HttpResponse<any>) => {
              var json = (response.body);
              // need to do mapping
              return (json as APIResult<boolean>)
          }));
    }

    //User Groups
    getUserGroups():Observable<APIResult<UserGroup[]>>{
      return this._baseService.WebAPIGet("api/v1.0/users/groups", true).pipe(
          map((response: HttpResponse<any>) => {
            var json = (response.body);
            var _res=new APIResult<UserGroup[]>();
            _res.status.isError=json.status.isError;

            if(!json.status.isError){
              _res.data=[];
              json.data?.forEach((c, i) => {
                _res.data.push((c as UserGroup));
              });
              _res.totalResultCount=json.totalResultCount;
            }else{
              _res.status.errorCode=json.status.errorCode;
              _res.status.errorMessage=json.status.errorMessage;
            }
           
            return _res;
          }));
    }

    saveUserGroup(param:UserGroup):Observable<APIResult<UserGroup>>{
      return this._baseService.WebAPIPOST("api/v1.0/users/groups",JSON.stringify(param),true).pipe(
          map((response: HttpResponse<any>) => {
              var json = (response.body);
              // need to do mapping
              return (json as APIResult<User>)
          }));
    }

    deleteUserGroup(id:number):Observable<APIResult<boolean>>{
      return this._baseService.WebAPIDELETE("api/v1.0/users/groups/"+id).pipe(
          map((response: HttpResponse<any>) => {
              var json = (response.body);
              // need to do mapping
              return (json as APIResult<boolean>)
          }));
    }
}
    

