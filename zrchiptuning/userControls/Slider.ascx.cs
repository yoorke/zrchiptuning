using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BL;
using BE;

namespace zrchiptuning.userControls
{
    public partial class Slider : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadSlider();
        }

        private void loadSlider()
        {
            rptSlider.DataSource = new SliderBL().GetSliderItems(1);
            rptSlider.DataBind();
        }
    }
}