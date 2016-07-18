using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace zrchiptuning
{
    public partial class manufacturers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Page.RouteData.Values["typeUrl"] != null)
                    showManufacturers(Page.RouteData.Values["typeUrl"].ToString());
            }
        }

        private void showManufacturers(string typeUrl)
        {
            rptManufacturers.DataSource = new ManufacturerBL().GetByType(typeUrl, false);
            rptManufacturers.DataBind();

            BE.Type type = new TypeBL().GetTypeByUrl(typeUrl);
            if(type != null)
                lblTypeName.Text = type.Name;
            else
            {
                Response.StatusCode = 404;
                Server.Transfer("~/errors/not-found.html");
            }
        }
    }
}