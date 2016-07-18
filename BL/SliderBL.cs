using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Repositories;

namespace BL
{
    public class SliderBL
    {
        public List<Slider> GetAll()
        {
            return new SliderRepository().GetAll();
        }

        public int Save(Slider slider)
        {
            SliderRepository sliderRepository = new SliderRepository();
            if (slider.ID > 0)
                return sliderRepository.Update(slider);
            else
                return sliderRepository.Insert(slider);
        }

        public bool Delete(Slider slider)
        {
            return new SliderRepository().Delete(slider);
        }

        public Slider GetSlider(int id)
        {
            return new SliderRepository().GetByID(id);
        }

        public List<SliderItem> GetSliderItems(int sliderID)
        {
            List<QueryParameter> parameters = new List<QueryParameter>();
            parameters.Add(new QueryParameter("sliderID", sliderID));

            return new SliderItemRepository().GetByParameter("getItemsBySliderID", parameters);
        }
    }
}
