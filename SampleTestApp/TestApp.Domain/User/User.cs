using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domain.User
{
    public class User:Person
    {
        public Customer Customer { get; set; }
        public int? UserGroupId { get; set; }
        [ForeignKey("UserGroupId")]
        public virtual UserGroup.UserGroup UserGroup { get; set; }
    }
}
