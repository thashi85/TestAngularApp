using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.UserGroup
{
    public class UserGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserGroupId { get; set; }
        public string GroupName { get; set; }
        public virtual List<User.User> Users { get; set; }
        public virtual List<UserGroupAccessRule> AccessRules { get; set; }
    }
}
