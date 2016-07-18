using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UserRole : BaseEntity
    {
        [SqlFieldNameAttribute("name")]
        public string Name { get; set; }

        public UserRole()
        {

        }

        public UserRole(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
    }
}
