using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BaseEntity
    {
        [SqlFieldNameAttribute("id", true)]
        public Int32 ID { get; set; }

        [SqlFieldNameAttribute("_userIDInsert")]
        public int _userIDInsert { get; set; }

        [SqlFieldNameAttribute("_userIDUpdate")]
        public int _userIDUpdate { get; set; }

        [SqlFieldNameAttribute("_insertDate")]
        public DateTime _insertDate { get; set; }

        [SqlFieldNameAttribute("_updateDate")]
        public DateTime _updateDate { get; set; }

        [SqlFieldNameAttribute("_isActive")]
        public bool _isActive { get; set; }

        public BaseEntity()
        {
            this.ID = -1;
        }

        public bool IsNew
        {
            get { return this.ID <= 0; }
        }
    }
}
