import {UserGroup} from 'src/models/user/user-group'
export class Person{
    id:number;
    firstName:string;
    lastName:string;
    emailAddress:string;
    userGroup:UserGroup;    
}

export class User extends Person{
  userGrops:UserGroup[]
}
export class Admin extends Person{
  privillage:string;
}