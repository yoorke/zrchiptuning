using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SliderItem : BaseEntity
    {
        [SqlFieldNameAttribute("imageUrl")]
        public string ImageUrl { get; set; }

        [SqlFieldNameAttribute("sortIndex")]
        public int SortIndex { get; set; }

        [SqlFieldNameAttribute("url")]
        public string Url { get; set; }

        public SliderItem()
        {

        }

        public SliderItem(int id, string imageUrl, int sortIndex, string url)
        {
            this.ID = id;
            this.ImageUrl = imageUrl;
            this.SortIndex = sortIndex;
            this.Url = url;
        }
    }
}
