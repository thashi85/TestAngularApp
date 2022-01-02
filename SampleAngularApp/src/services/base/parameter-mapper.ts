export class ParameterMapper
{
   static mapFilters(filter: any,res:string=''):string
    {      
       if (filter)
       {
           Object.keys(filter).forEach((key, index) => {
               if (filter[key]) {
                   if (res.length > 0)
                       res += '&';

                   res += key + '=' + filter[key]
               }
           });
       }
        return res;
    }
}