using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Slider : BaseEntity
    {
        [SqlFieldNameAttribute("name")]
        public string Name { get; set; }

        [SqlFieldNameAttribute("sliderID", "SliderItem", "id", Relation.OneToMany, "getItemsBySliderID")]
        public List<SliderItem> Items { get; set; }

        public Slider()
        {

        }

        public Slider(int id, string name, List<SliderItem> items)
        {
            this.ID = id;
            this.Name = name;
            this.Items = items;
        }
    }
}
