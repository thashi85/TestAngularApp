import {AccessRule} from 'src/models/user/access-rule'
export class UserGroup
{
userGroupId:number;
groupName:string;
accessRules:AccessRule[];
}