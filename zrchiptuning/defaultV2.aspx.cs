using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace zrchiptuning
{
    public partial class defaultV2 : System.Web.UI.Page
    {
        

        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadData loadData = new LoadData(new BL.EngineBL().LoadData);
            //loadData.BeginInvoke(null, null);
            //LoadData loadModels = new LoadData(new BL.ModelBL().LoadData);
            //loadModels.BeginInvoke(null, null);
        }
    }
}
