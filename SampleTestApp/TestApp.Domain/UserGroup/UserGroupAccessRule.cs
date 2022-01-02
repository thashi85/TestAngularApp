using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.UserGroup
{
    public class UserGroupAccessRule
    {
       
        public int UserGroupId { get; set; }
        
        public int AccessRuleId { get; set; }

        //Not sure why this boolean flag is needed, we can identify user group has access to the rule or not,
        //based on access rules linked to the user group, if user rules is added user has access to it otherwise user does not have access
        //Other option is all access rules are added to user group and it is control using Permission bool
        public bool Permission { get; set; }
    }
}
