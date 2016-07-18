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
using BE;
using BL;

namespace zrchiptuning
{
    public partial class customPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string url=string.Empty;
                if (Page.RouteData.Values["url"] != null)
                    url = Page.RouteData.Values["url"].ToString();
                if (url != string.Empty)
                    loadCustomPage(url);
            }
        }

        private void loadCustomPage(string url)
        {
            CustomPageBL customPageBL = new CustomPageBL();
            CustomPage customPage = customPageBL.GetCustomPage(url);
            if (customPage != null)
            {
                Page.Title = customPage.Title;
                ViewState.Add("pageTitle", customPage.Title);
                lblHeading.Text = customPage.Heading;
                divContent.InnerHtml = customPage.Content;
                lblHeader.Text = customPage.Head;
                lblFooter.Text = customPage.Footer;
            }
            else
                Server.Transfer("~/errors/not-found.html");
        }
    }
}
