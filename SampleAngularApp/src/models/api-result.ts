export class APIResult<T>
{
    data:T
    totalResultCount:number
    status:APIResultStatus
    /**
     *
     */
    constructor() {
        this.status=new APIResultStatus();        
    }
}
export class APIResultStatus
{
    isError:boolean
    errorCode:string
    errorMessage:string
}