using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using BE;

namespace zrchiptuning
{
    public partial class models : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Page.RouteData.Values["manufacturerUrl"] != null)
                    showModels(Page.RouteData.Values["manufacturerUrl"].ToString());
                if (Page.Request.RawUrl.Contains("putnicka"))
                    lblType.Value = "putnicka";
                else if (Page.Request.RawUrl.Contains("kamioni"))
                    lblType.Value = "kamioni";
                else if (Page.Request.RawUrl.Contains("komercijalna"))
                    lblType.Value = "komercijalna";
                else if (Page.Request.RawUrl.Contains("motocikli"))
                    lblType.Value = "motocikli";
                else if (Page.Request.RawUrl.Contains("suv"))
                    lblType.Value = "suv";

                showManufacturers();
            }
        }

        private void showModels(string manufacturerUrl)
        {
            rptModels.DataSource = new ModelBL().GetByManufacturerUrl(manufacturerUrl, false, Page.RouteData.Values["typeUrl"].ToString());
            rptModels.DataBind();

            Manufacturer manufacturer = new ManufacturerBL().GetManufacturer(manufacturerUrl);
            if (manufacturer != null)
            {
                lblManufacturer.Text = new ManufacturerBL().GetManufacturer(manufacturerUrl).Name;
                Page.Title = manufacturer.Name + " | Chip tuning poslednje generacije";
            }
            else
            {
                Response.StatusCode = 404;
                Server.Transfer("~/errors/not-found.html");
            }
        }

        private void showManufacturers()
        {
            rptManufacturers.DataSource = new ManufacturerBL().GetByType(lblType.Value, false);
            rptManufacturers.DataBind();
        }

        protected void rptManufacturers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink lnkManufacturer = ((HyperLink)e.Item.FindControl("lnkManufacturer"));
                lnkManufacturer.NavigateUrl = "/vozila/" + lblType.Value + "/" + lnkManufacturer.NavigateUrl;
            }
        }
    }
}