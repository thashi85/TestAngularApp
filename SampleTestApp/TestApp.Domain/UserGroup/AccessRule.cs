using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.UserGroup
{
    public class AccessRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccessRuleId { get; set; }
        public string AccessRuleName { get; set; }
       // public virtual List<UserGroupAccessRule> UserGroups { get; set; }

    }
}
